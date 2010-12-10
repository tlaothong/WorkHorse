using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.TwoWins.Commands;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.TwoWins.DAL;
using TheS.Casinova.PlayerProfile.Models;
using TheS.Casinova.TwoWins.Models;

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

        public SingleBetExecutor(ITwowinsDataAccess dac, ITwowinsDataBackQuery dqr)
        {
            _iCreateActionLogInfo = dac;
            _iCreateBetInfo = dac;
            _iGetRoundInfo = dqr;
            _iUpdateRoundInfo = dac;
            _iGetUserProfile = dqr;
            _iUpdateUserProfile = dac;
        }

        protected override void ExecuteCommand(SingleBetCommand command)
        {
            //ดึงข้อมูลโต๊ะเกม
            GetRoundInfoCommand getRoundInfoCmd = new GetRoundInfoCommand { RoundID = command.BetInfo.RoundID };
            getRoundInfoCmd.RoundInfo = _iGetRoundInfo.Get(getRoundInfoCmd);

            getRoundInfoCmd.RoundInfo.Pot += command.BetInfo.Amount;

            //อัพเดทข้อมูลโต๊ะเกม
            UpdateRoundCommand updateRoundCmd = new UpdateRoundCommand { RoundInfo = getRoundInfoCmd.RoundInfo };
            _iUpdateRoundInfo.ApplyAction(updateRoundCmd.RoundInfo, updateRoundCmd);

            //ดึงข้อมูลชิฟของผู้เล่น
            GetUserProfileCommand getUserProfileCmd = new GetUserProfileCommand { UserName = command.BetInfo.UserName };

            getUserProfileCmd.UserProfile = _iGetUserProfile.Get(getUserProfileCmd);

            //TODO : คำนวณชิฟของผู้เล่นว่าพอมั้ย

            //คำนวณชิฟที่ต้องหักจากผู้เล่น
            if (getUserProfileCmd.UserProfile.NonRefundable < command.BetInfo.Amount) {
                getUserProfileCmd.UserProfile.Refundable -= command.BetInfo.Amount - getUserProfileCmd.UserProfile.NonRefundable;
                getUserProfileCmd.UserProfile.NonRefundable = 0;
            }
            else if (getUserProfileCmd.UserProfile.NonRefundable >= command.BetInfo.Amount) {
                getUserProfileCmd.UserProfile.NonRefundable -= command.BetInfo.Amount;
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
                    UserName = command.BetInfo.UserName,
                    ActionType = "SingleBet",
                    Amount = command.BetInfo.Amount,
                    DateTime = DateTime.Now,
                    RoundID = command.BetInfo.RoundID,
                },
            };
            _iCreateActionLogInfo.Create(createActionLogInfoCmd.ActionLogInfo, createActionLogInfoCmd);

            //บันทึกข้อมูลการลงพนัน
            CreateBetInfoCommand createBetInfoCmd = new CreateBetInfoCommand { BetInfo = command.BetInfo };
            createBetInfoCmd.BetInfo.BonusChips = updateUserProfileCmd.UserProfile.NonRefundable;
            createBetInfoCmd.BetInfo.Chips = updateUserProfileCmd.UserProfile.Refundable;
            createBetInfoCmd.BetInfo.BetDateTime = DateTime.Now;
            createBetInfoCmd.BetInfo.CanChange = true;

            _iCreateBetInfo.Create(createBetInfoCmd.BetInfo, createBetInfoCmd);
        }
    }
}
