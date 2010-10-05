using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.Colors.Commands;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.Colors.DAL;
using TheS.Casinova.Colors.Models;

namespace TheS.Casinova.Colors.BackServices.BackExecutors
{
    public class BetColorsExecutor
        : SynchronousCommandExecutorBase<BetCommand>
    {
        private IUpdatePlayerInfoBalance _iUpdatePlayerInfoBalance;
        private ICreatePlayerActionInfo _iCreatePlayerActionInfo;

        private IGetPlayerInfo _iGetPlayerInfo;

        public BetColorsExecutor(IColorsGameDataAccess dac, IColorsGameDataBackQuery dqr)
        {
            _iUpdatePlayerInfoBalance = dac;
            _iCreatePlayerActionInfo = dac;

            _iGetPlayerInfo = dqr;
        }

        protected override void ExecuteCommand(BetCommand command)
        {
            #region Update balance

            GetPlayerInfoCommand getPlayerInfoCmd = new GetPlayerInfoCommand { 
                UserName = command.PlayerActionInfo.UserName,
            };

            getPlayerInfoCmd.PlayerInfo = _iGetPlayerInfo.Get(getPlayerInfoCmd);

            getPlayerInfoCmd.PlayerInfo.Balance -= command.Amount;

            UpdatePlayerInfoBalanceCommand updateBalanceCmd = new UpdatePlayerInfoBalanceCommand {
                PlayerInfo = new PlayerInformation {
                    UserName = command.UserName,
                    Balance = getPlayerInfoCmd.PlayerInfo.Balance,
                }
            };

            _iUpdatePlayerInfoBalance.ApplyAction(updateBalanceCmd.PlayerInfo, updateBalanceCmd);

            #endregion Update balance

            #region Create player action information

            CreatePlayerActionInfoCommand createPlayerActionInfoCmd = new CreatePlayerActionInfoCommand {
                PlayerActionInfo = new PlayerActionInformation {
                    UserName = command.UserName,
                    RoundID = command.RoundID,
                    ActionType = command.Color,
                    Amount = command.Amount,
                }
            };

            _iCreatePlayerActionInfo.Create(createPlayerActionInfoCmd.PlayerActionInfo, createPlayerActionInfoCmd);

            #endregion Create player action information
        }
    }
}
