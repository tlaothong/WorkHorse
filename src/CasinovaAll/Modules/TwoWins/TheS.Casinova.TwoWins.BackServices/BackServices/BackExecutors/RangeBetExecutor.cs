using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.TwoWins.Commands;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.TwoWins.DAL;
using PerfEx.Infrastructure;
using TheS.Casinova.TwoWins.Models;
using TheS.Casinova.PlayerProfile.Models;
using PerfEx.Infrastructure.Validation;

namespace TheS.Casinova.TwoWins.BackServices.BackExecutors
{
    public class RangeBetExecutor
        : SynchronousCommandExecutorBase<RangeBetCommand>
    {
        private IGetRoundInfo _iGetRoundInfo;
        private IUpdateRoundInfo _iUpdateRoundInfo;
        private IGetUserProfile _iGetUserProfile;
        private IUpdateUserProfile _iUpdateUserProfile;
        private ICreateActionLogInfo _iCreateActionLogInfo;
        private ICreateBetInfo _iCreateBetInfo;
        private ICreateRangeBetInfo _iCreateRangeBetInfo;
        private IDependencyContainer _container;

        public RangeBetExecutor(IDependencyContainer container, ITwowinsDataAccess dac, ITwowinsDataBackQuery dqr)
        {
            _iGetRoundInfo = dqr;
            _iUpdateRoundInfo = dac;
            _iGetUserProfile = dqr;
            _iUpdateUserProfile = dac;
            _iCreateActionLogInfo = dac;
            _iCreateBetInfo = dac;
            _iCreateRangeBetInfo = dac;
            _container = container;
        }

        protected override void ExecuteCommand(RangeBetCommand command)
        {
            ValidationErrorCollection errorValidations = new ValidationErrorCollection();
            List<BetInformation> betInfos = new List<BetInformation>();
            List<BetInformation> paidBetInfos = new List<BetInformation>();
            string handStatus;

            command.RangeBetInfo.RangeBetDateTime = DateTime.Now; //กำหนดเวลาที่ลงพนัน

            //ดึงข้อมูลโต๊ะเกม
            GetRoundInfoCommand getRoundInfoCmd = new GetRoundInfoCommand { RoundID = command.RangeBetInfo.RoundID };
            getRoundInfoCmd.RoundInfo = _iGetRoundInfo.Get(getRoundInfoCmd);

            //แบ่งมือที่ลงพนัน
            for (double i = command.RangeBetInfo.FromAmount; i <= command.RangeBetInfo.ThruAmount; i++) {
                BetInformation betInfo = new BetInformation {
                    RoundID = command.RangeBetInfo.RoundID,
                    UserName = command.RangeBetInfo.UserName,
                    Amount = i,  
                };
                betInfos.Add(betInfo);
            }

            //ดึงข้อมูลชิฟของผู้เล่น
            GetUserProfileCommand getUserProfileCmd = new GetUserProfileCommand { UserName = command.RangeBetInfo.UserName };
            getUserProfileCmd.UserProfile = _iGetUserProfile.Get(getUserProfileCmd);

            //คำนวณชิฟของผู้เล่นว่าพอมั้ย (อย่างน้อยต้องพอกับการลงพนันมือแรก)
            ValidationHelper.Validate(_container, getUserProfileCmd.UserProfile, getUserProfileCmd, errorValidations);
            //เช็คเวลาว่ายังลงพนันได้หรือไม่
            ValidationHelper.Validate(_container, command.RangeBetInfo, command, errorValidations);

            if (errorValidations.Any()) {
                throw new ValidationErrorException(errorValidations);
            }

            //คำนวณชิฟที่ต้องหักจากผู้เล่น
            foreach (var item in betInfos) {
                if ((getUserProfileCmd.UserProfile.NonRefundable < item.Amount) && (getUserProfileCmd.UserProfile.Refundable > item.Amount)) {
                    item.BonusChips = getUserProfileCmd.UserProfile.NonRefundable;
                    item.Chips = item.Amount - getUserProfileCmd.UserProfile.NonRefundable;

                    getUserProfileCmd.UserProfile.Refundable -= item.Amount - getUserProfileCmd.UserProfile.NonRefundable;
                    getUserProfileCmd.UserProfile.NonRefundable = 0;

                    paidBetInfos.Add(item);
                }
                else if (getUserProfileCmd.UserProfile.NonRefundable >= item.Amount) {
                    getUserProfileCmd.UserProfile.NonRefundable -= item.Amount;

                    item.BonusChips = item.Amount;
                    item.Chips = 0;
                    paidBetInfos.Add(item);
                }
                else {
                    break;
                }       
            }

            //อัพเดทข้อมูลโต๊ะเกม
            getRoundInfoCmd.RoundInfo.Pot += paidBetInfos.Select(x => x.Amount).Sum();
            UpdateRoundInfoCommand updateRoundCmd = new UpdateRoundInfoCommand { RoundInfo = getRoundInfoCmd.RoundInfo };
            _iUpdateRoundInfo.ApplyAction(updateRoundCmd.RoundInfo, updateRoundCmd);

            //คำนวณสถานะที่พนัน
            if (command.RangeBetInfo.RangeBetDateTime < getRoundInfoCmd.RoundInfo.CriticalDateTime) {
                handStatus = "Normal";
            }
            else {
                handStatus = "Critical";
            }
            foreach (var item in paidBetInfos) {
                item.HandStatus = handStatus;
            }

            //หักชิฟผู้เล่นตามเงินที่ต้องการลงพนัน
            UpdateUserProfileCommand updateUserProfileCmd = new UpdateUserProfileCommand {
                UserProfile = new UserProfile {
                    UserName = getUserProfileCmd.UserProfile.UserName,
                    NonRefundable = getUserProfileCmd.UserProfile.NonRefundable,
                    Refundable = getUserProfileCmd.UserProfile.Refundable,
                },
            };
            _iUpdateUserProfile.ApplyAction(updateUserProfileCmd.UserProfile, updateUserProfileCmd);

            //บันทึกประวัติการดำเนินการ
            CreateActionLogInfoCommand createActionLogInfoCmd = new CreateActionLogInfoCommand {
                ActionLogInfo = new ActionLogInformation {
                    UserName = command.RangeBetInfo.UserName,
                    Amount = paidBetInfos.Select(x => x.Amount).Sum(),
                    OldAmount = -1,
                    DateTime = command.RangeBetInfo.RangeBetDateTime,
                    RoundID = command.RangeBetInfo.RoundID,
                    Change = false,
                    HandStatus = handStatus,
                },
            };
            _iCreateActionLogInfo.Create(createActionLogInfoCmd.ActionLogInfo, createActionLogInfoCmd);

            //บันทึกข้อมูลการลงพนันหลายมือ
            CreateRangeBetInfoCommand createRangeBetInfoCmd = new CreateRangeBetInfoCommand {
                RangeBetInfo = command.RangeBetInfo
            };

            _iCreateRangeBetInfo.Create(createRangeBetInfoCmd.RangeBetInfo, createRangeBetInfoCmd);

            //บันทึกข้อมูลการลงพนันทีละมือ
            foreach (var item in paidBetInfos) {
                CreateBetInfoCommand createBetInfoCmd = new CreateBetInfoCommand { BetInfo = item };
                createBetInfoCmd.BetInfo.BetTrackingID = command.RangeBetInfo.BetTrackingID;
                createBetInfoCmd.BetInfo.BetDateTime = command.RangeBetInfo.RangeBetDateTime;
                createBetInfoCmd.BetInfo.CanChange = true;

                _iCreateBetInfo.Create(createBetInfoCmd.BetInfo, createBetInfoCmd);
            }
        }
    }
}
