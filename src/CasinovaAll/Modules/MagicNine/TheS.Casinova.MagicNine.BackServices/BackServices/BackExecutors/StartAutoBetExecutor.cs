using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.MagicNine.Commands;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.MagicNine.DAL;
using TheS.Casinova.MagicNine.Models;

namespace TheS.Casinova.MagicNine.BackServices.BackExecutors
{
    public class StartAutoBetExecutor
        : SynchronousCommandExecutorBase<StartAutoBetCommand>
    {
        private IAutoBetEngine _iAutoBetEngine;

        private IUpdatePlayerInfoBalance _iUpdatePlayerInfoBalance;

        private IGetPlayerInfo _iGetPlayerInfo;

        public StartAutoBetExecutor(IAutoBetEngine svc, IMagicNineGameDataAccess dac, IMagicNineGameDataBackQuery dqr)
        {
            _iAutoBetEngine = svc;

            _iUpdatePlayerInfoBalance = dac;

            _iGetPlayerInfo = dqr;
        }

        protected override void ExecuteCommand(StartAutoBetCommand command)
        {
            GetPlayerInfoCommand getPlayerInfoCmd = new GetPlayerInfoCommand {
                UserName = command.GamePlayAutoBetInfo.UserName,
            };

            getPlayerInfoCmd.PlayerInfo = _iGetPlayerInfo.Get(getPlayerInfoCmd);

            if (getPlayerInfoCmd.PlayerInfo.Balance >= command.GamePlayAutoBetInfo.Amount) {
                getPlayerInfoCmd.PlayerInfo.Balance -= command.GamePlayAutoBetInfo.Amount;

                PlayerInformation playerInfo = new PlayerInformation();

                UpdatePlayerInfoBalanceCommand updatePlayerInfoBalanceCmd = new UpdatePlayerInfoBalanceCommand {
                    BetInfo = new BetInformation{
                    UserName = playerInfo.UserName = getPlayerInfoCmd.PlayerInfo.UserName,
                    },
                    Balance = playerInfo.Balance = getPlayerInfoCmd.PlayerInfo.Balance,
                };

                _iUpdatePlayerInfoBalance.ApplyAction(playerInfo, updatePlayerInfoBalanceCmd);

                _iAutoBetEngine.StartAutoBet(command);
            }
            else {
                Console.WriteLine("๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑  เงินไม่พอ  ๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑");
            }
        }
    }
}
