using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.TwoWins.Commands;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.TwoWins.DAL;
using TheS.Casinova.PlayerProfile.Models;
using TheS.Casinova.TwoWins.Models;
using PerfEx.Infrastructure;
using PerfEx.Infrastructure.Validation;

namespace TheS.Casinova.TwoWins.BackServices.BackExecutors
{
    public class SingleBetExecutor
        : SynchronousCommandExecutorBase<SingleBetCommand>
    {
        private ICreateBetInfo _iCreateBetInfo;
        private ICreateActionLogInfo _iCreateActionLogInfo;
        private IGetRoundInfo _iGetRoundInfo;
        private IUpdateRoundInfo _iUpdateRoundInfo;
        private IGetUserProfile _iGetUserProfile;
        private IUpdateUserProfile _iUpdateUserProfile;
        private IDependencyContainer _container;

        private string _handStatus;

        public SingleBetExecutor(IDependencyContainer container, ITwowinsDataAccess dac, ITwowinsDataBackQuery dqr)
        {
            _iCreateActionLogInfo = dac;
            _iCreateBetInfo = dac;
            _iGetRoundInfo = dqr;
            _iUpdateRoundInfo = dac;
            _iGetUserProfile = dqr;
            _iUpdateUserProfile = dac;
            _container = container;
        }

        protected override void ExecuteCommand(SingleBetCommand command)
        {
            command.BetInfo.BetDateTime = DateTime.Now; //กำหนดเวลาที่ลงพนัน
            
            //ดึงข้อมูลโต๊ะเกม
            GetRoundInfoCommand getRoundInfoCmd = new GetRoundInfoCommand { RoundID = command.BetInfo.RoundID };
            getRoundInfoCmd.RoundInfo = _iGetRoundInfo.Get(getRoundInfoCmd);

            getRoundInfoCmd.RoundInfo.Pot += command.BetInfo.Amount;

            //อัพเดทข้อมูลโต๊ะเกม
            UpdateRoundInfoCommand updateRoundCmd = new UpdateRoundInfoCommand { RoundInfo = getRoundInfoCmd.RoundInfo };
            _iUpdateRoundInfo.ApplyAction(updateRoundCmd.RoundInfo, updateRoundCmd);

            //ดึงข้อมูลชิฟของผู้เล่น
            GetUserProfileCommand getUserProfileCmd = new GetUserProfileCommand { UserName = command.BetInfo.UserName };
            getUserProfileCmd.UserProfile = _iGetUserProfile.Get(getUserProfileCmd);

            ValidationErrorCollection errorValidations = new ValidationErrorCollection();

            //คำนวณชิฟของผู้เล่นว่าพอมั้ย
            ValidationHelper.Validate(_container, getUserProfileCmd.UserProfile, command, errorValidations);

            //เช็คเวลาว่ายังลงพนันได้หรือไม่
            ValidationHelper.Validate(_container, command.BetInfo, command, errorValidations);

            if (errorValidations.Any()) {
                throw new ValidationErrorException(errorValidations);
            }

            //คำนวณชิฟที่ต้องหักจากผู้เล่น
            if (getUserProfileCmd.UserProfile.NonRefundable < command.BetInfo.Amount) {
                getUserProfileCmd.UserProfile.Refundable -= command.BetInfo.Amount - getUserProfileCmd.UserProfile.NonRefundable;
                getUserProfileCmd.UserProfile.NonRefundable = 0;

                command.BetInfo.BonusChips = getUserProfileCmd.UserProfile.NonRefundable;
                command.BetInfo.Chips = command.BetInfo.Amount - getUserProfileCmd.UserProfile.NonRefundable;
            }
            else if (getUserProfileCmd.UserProfile.NonRefundable >= command.BetInfo.Amount) {
                getUserProfileCmd.UserProfile.NonRefundable -= command.BetInfo.Amount;

                command.BetInfo.BonusChips = command.BetInfo.Amount;
                command.BetInfo.Chips = 0;
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

            //คำนวณสถานะที่พนัน
            if (command.BetInfo.BetDateTime < getRoundInfoCmd.RoundInfo.CriticalDateTime) {
                _handStatus = "Normal";
            }
            else {
                _handStatus = "Critical";
            }

            //บันทึกประวัติการดำเนินการ
            CreateActionLogInfoCommand createActionLogInfoCmd = new CreateActionLogInfoCommand {
                ActionLogInfo = new ActionLogInformation {
                    UserName = command.BetInfo.UserName,
                    ActionType = "SingleBet",
                    Amount = command.BetInfo.Amount,
                    OldAmount = -1,
                    ActionDateTime = command.BetInfo.BetDateTime,
                    RoundID = command.BetInfo.RoundID,
                    CanChange = true,
                    
                    //TODO : waiting for create HandID logic
                    HandStatus = _handStatus,
                },
            };
            _iCreateActionLogInfo.Create(createActionLogInfoCmd.ActionLogInfo, createActionLogInfoCmd);

            //บันทึกข้อมูลการลงพนัน
            CreateBetInfoCommand createBetInfoCmd = new CreateBetInfoCommand { BetInfo = command.BetInfo };
            createBetInfoCmd.BetInfo.BonusChips = command.BetInfo.BonusChips;
            createBetInfoCmd.BetInfo.Chips = command.BetInfo.Chips;
            createBetInfoCmd.BetInfo.BetDateTime = createBetInfoCmd.BetInfo.BetDateTime;
            createBetInfoCmd.BetInfo.CanChange = true;
            createBetInfoCmd.BetInfo.HandStatus = _handStatus;

            _iCreateBetInfo.Create(createBetInfoCmd.BetInfo, createBetInfoCmd);
        }
    }
}
