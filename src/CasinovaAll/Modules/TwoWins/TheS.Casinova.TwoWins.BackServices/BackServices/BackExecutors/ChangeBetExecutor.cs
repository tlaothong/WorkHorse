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
    public class ChangeBetExecutor
        : SynchronousCommandExecutorBase<ChangeBetInfoCommand>
    {
        private IGetUserProfile _iGetUserProfile;
        private IGetBetInfo _iGetBetInfo;
        private IGetRoundInfo _iGetRoundInfo;
        private IChangeBetInfo _iChangeBetInfo;
        private IUpdateRoundInfo _iUpdateRoundInfo;
        private ICreateActionLogInfo _iCreateActionLogInfo;
        private IUpdateUserProfile _iUpdateUserProfile;
        private IDependencyContainer _container;
        private string _handStatus;

        public ChangeBetExecutor(IDependencyContainer container, ITwowinsDataAccess dac, ITwowinsDataBackQuery dqr)
        {
            _iGetUserProfile = dqr;
            _iGetBetInfo = dqr;
            _iGetRoundInfo = dqr;
            _iUpdateRoundInfo = dac;
            _iCreateActionLogInfo = dac;
            _iUpdateUserProfile = dac;
            _iChangeBetInfo = dac;
            _container = container;
        }

        protected override void ExecuteCommand(ChangeBetInfoCommand command)
        {
            command.BetInfo.BetDateTime = DateTime.Now; //กำหนดเวลาที่แก้ไข
            ValidationErrorCollection errorValidations = new ValidationErrorCollection();

            //ดึงข้อมูลลงพนันเดิม
            GetBetInfoCommand getBetInfoCmd = new GetBetInfoCommand { 
                HandID = command.BetInfo.HandID
            };
            getBetInfoCmd.BetInfo = _iGetBetInfo.Get(getBetInfoCmd);

            command.netAmount = command.BetInfo.Amount - getBetInfoCmd.BetInfo.Amount;

            //ดึงข้อมูลชิฟของผู้เล่น
            GetUserProfileCommand getUserProfileCmd = new GetUserProfileCommand { UserName = command.BetInfo.UserName };
            getUserProfileCmd.UserProfile = _iGetUserProfile.Get(getUserProfileCmd);

            ValidationHelper.Validate(_container, getUserProfileCmd.UserProfile, command, errorValidations);
            ValidationHelper.Validate(_container, getBetInfoCmd.BetInfo, command, errorValidations);
            if (errorValidations.Any()) {
                throw new ValidationErrorException(errorValidations);
            }

            //ดึงข้อมูลโต๊ะเกม
            GetRoundInfoCommand getRoundInfoCmd = new GetRoundInfoCommand { RoundID = command.BetInfo.RoundID };
            getRoundInfoCmd.RoundInfo = _iGetRoundInfo.Get(getRoundInfoCmd);

            getRoundInfoCmd.RoundInfo.Pot += command.netAmount;

            //อัพเดทข้อมูลโต๊ะเกม
            UpdateRoundInfoCommand updateRoundCmd = new UpdateRoundInfoCommand { RoundInfo = getRoundInfoCmd.RoundInfo };
            _iUpdateRoundInfo.ApplyAction(updateRoundCmd.RoundInfo, updateRoundCmd);

            //คำนวณสถานะที่พนัน
            if (command.BetInfo.BetDateTime < getRoundInfoCmd.RoundInfo.CriticalDateTime) {
                _handStatus = "Normal";
                command.BetInfo.CanChange = true;
            }
            else {
                _handStatus = "Critical";
                command.BetInfo.CanChange = false;
            }

            //บันทึกประวัติการดำเนินการ
            CreateActionLogInfoCommand createActionLogInfoCmd = new CreateActionLogInfoCommand {
                ActionLogInfo = new ActionLogInformation {
                    UserName = command.BetInfo.UserName,
                    Amount = command.BetInfo.Amount,
                    OldAmount = getBetInfoCmd.BetInfo.Amount,
                    DateTime = command.BetInfo.BetDateTime,
                    RoundID = command.BetInfo.RoundID,
                    Change = true,
                    HandID = command.BetInfo.HandID,
                    HandStatus = _handStatus,
                },
            };
            _iCreateActionLogInfo.Create(createActionLogInfoCmd.ActionLogInfo, createActionLogInfoCmd);

            //คำนวณชิฟที่ต้องหักจากผู้เล่น
            if (getUserProfileCmd.UserProfile.NonRefundable < command.netAmount) {
                getBetInfoCmd.BetInfo.BonusChips += getUserProfileCmd.UserProfile.NonRefundable;
                getBetInfoCmd.BetInfo.Chips += command.netAmount - getUserProfileCmd.UserProfile.NonRefundable;

                getUserProfileCmd.UserProfile.Refundable -= command.netAmount - getUserProfileCmd.UserProfile.NonRefundable;
                getUserProfileCmd.UserProfile.NonRefundable = 0;
            }
            else if (getUserProfileCmd.UserProfile.NonRefundable >= command.netAmount) {
                getUserProfileCmd.UserProfile.NonRefundable -= command.netAmount;

                getBetInfoCmd.BetInfo.BonusChips += command.netAmount;
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

            //อัพเดทข้อมูลการลงพนัน
            command.BetInfo.BonusChips = getBetInfoCmd.BetInfo.BonusChips;
            command.BetInfo.Chips = getBetInfoCmd.BetInfo.Chips;
            command.BetInfo.HandStatus = _handStatus;            
            _iChangeBetInfo.ApplyAction(command.BetInfo, command);
        }
    }
}
