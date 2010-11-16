using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.TwoWins.Commands;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.TwoWins.DAL;
using TheS.Casinova.TwoWins.Models;
using TheS.Casinova.PlayerProfile.Models;

namespace TheS.Casinova.TwoWins.BackServices.BackExecutors
{
    public class BetColorExecutor
        : SynchronousCommandExecutorBase<BetCommand>
    {
        private IUpdatePlayerInfoBalance _iUpdatePlayerInfoBalance;
        private ICreatePlayerActionInfo _iCreatePlayerActionInfo;

        private IGetPlayerInfo _iGetPlayerInfo;

        public BetColorExecutor(IColorsGameDataAccess dac, IColorsGameDataBackQuery dqr)
        {
            _iUpdatePlayerInfoBalance = dac;
            _iCreatePlayerActionInfo = dac;

            _iGetPlayerInfo = dqr;
        }

        protected override void ExecuteCommand(BetCommand command)
        {
            double playerBalance;

            #region Update balance

            //ดึงข้อมูลผู้เล่นเพื่อหักเงิน
            GetPlayerInfoCommand getPlayerInfoCmd = new GetPlayerInfoCommand {
                UserName = command.UserName,
            };

            getPlayerInfoCmd.UserProfile = _iGetPlayerInfo.Get(getPlayerInfoCmd);
            playerBalance = getPlayerInfoCmd.UserProfile.NonRefundable + getPlayerInfoCmd.UserProfile.Refundable;

            //บันทึกข้อมูลผู้เล่นที่ถูกหักเงิน
            UpdatePlayerInfoBalanceCommand updateBalanceCmd = new UpdatePlayerInfoBalanceCommand();

            if (getPlayerInfoCmd.UserProfile.NonRefundable < command.Amount) {
                getPlayerInfoCmd.UserProfile.Refundable -= command.Amount - getPlayerInfoCmd.UserProfile.NonRefundable;
                getPlayerInfoCmd.UserProfile.NonRefundable = 0;

                updateBalanceCmd.UserName = command.UserName;

                //หักเงินผู้เล่นตามเงินที่ต้องการลงพนัน
                updateBalanceCmd.NonRefundable = getPlayerInfoCmd.UserProfile.NonRefundable;
                updateBalanceCmd.Refundable = getPlayerInfoCmd.UserProfile.Refundable;

                _iUpdatePlayerInfoBalance.ApplyAction(getPlayerInfoCmd.UserProfile, updateBalanceCmd);
            }
            else if (getPlayerInfoCmd.UserProfile.NonRefundable >= command.Amount) {
                getPlayerInfoCmd.UserProfile.NonRefundable -= command.Amount;

                updateBalanceCmd.UserName = command.UserName;

                //หักเงินผู้เล่นตามเงินที่ต้องการลงพนัน
                updateBalanceCmd.NonRefundable = getPlayerInfoCmd.UserProfile.NonRefundable;
                updateBalanceCmd.Refundable = getPlayerInfoCmd.UserProfile.Refundable;

                _iUpdatePlayerInfoBalance.ApplyAction(getPlayerInfoCmd.UserProfile, updateBalanceCmd);
            }
            else {
                Console.WriteLine("๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑  เงินไม่พอ  ๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑");
            }


            #endregion Update balance

            #region Create player action information

            //บันทึกข้อมูลการดำเนินงานของผู้เล่น
            PlayerActionInformation playerActionInfo = new PlayerActionInformation();
            CreatePlayerActionInfoCommand createPlayerActionInfoCmd = new CreatePlayerActionInfoCommand {
                UserName = playerActionInfo.UserName = command.UserName,
                RoundID = playerActionInfo.RoundID = command.RoundID,
                ActionType = playerActionInfo.ActionType = command.Color,
                Amount = playerActionInfo.Amount = command.Amount,
            };

            _iCreatePlayerActionInfo.Create(playerActionInfo, createPlayerActionInfoCmd);

            #endregion Create player action information
        }
    }
}
