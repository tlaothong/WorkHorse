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
    public class SingleBetExecutor
        : SynchronousCommandExecutorBase<SingleBetCommand>
    {
        private ISingleBet _iSingleBet;
        private IUpdatePlayerInfoBalance _iUpdatePlayerInfoBalance;
        private IUpdateGameRoundPot _iUpdateGameRoundPot;

        private IGetPlayerInfo _iGetPlayerInfo;
        private IGetGameRoundPot _iGetGameRoundPot;                

        private const double _betFee = 1;

        public SingleBetExecutor(IMagicNineGameDataAccess dac, IMagicNineGameDataBackQuery dqr)
        {
            _iSingleBet = dac;
            _iUpdatePlayerInfoBalance = dac;
            _iUpdateGameRoundPot = dac;

            _iGetPlayerInfo = dqr;
            _iGetGameRoundPot = dqr;
        }

        protected override void ExecuteCommand(SingleBetCommand command)
        {
            GetPlayerInfoCommand getPlayerInfoCmd = new GetPlayerInfoCommand {
                UserName = command.BetInfo.UserName,
            };

            getPlayerInfoCmd.PlayerInfo = _iGetPlayerInfo.Get(getPlayerInfoCmd);

            if (getPlayerInfoCmd.PlayerInfo.Balance >= _betFee) {
                getPlayerInfoCmd.PlayerInfo.Balance -= _betFee;

                PlayerInformation playerInfo = new PlayerInformation();

                UpdatePlayerInfoBalanceCommand updatePlayerInfoBalanceCmd = new UpdatePlayerInfoBalanceCommand {
                    BetInfo = new BetInformation{
                    UserName = playerInfo.UserName = getPlayerInfoCmd.PlayerInfo.UserName,
                    },
                    Balance = playerInfo.Balance = getPlayerInfoCmd.PlayerInfo.Balance,
                };

                _iUpdatePlayerInfoBalance.ApplyAction(playerInfo, updatePlayerInfoBalanceCmd);
            }
            else {
                Console.WriteLine("๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑  เงินไม่พอ  ๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑");
            }

            GetGameRoundPotCommand getGameRoundPotCmd = new GetGameRoundPotCommand {
                RoundID = command.BetInfo.Round,
            };

            getGameRoundPotCmd.Pot = _iGetGameRoundPot.Get(getGameRoundPotCmd);


            BetInformation betInfo = new BetInformation {
                Round = command.BetInfo.Round,
                UserName = command.BetInfo.UserName,
                BetTrackingID = command.TrackingID,
            };

            GameRoundInformation gameRoundInfo = new GameRoundInformation();

            UpdateGameRoundPotCommand updateGameRoundPotCmd = new UpdateGameRoundPotCommand {
                BetInfo = new BetInformation{
                Round = gameRoundInfo.Round = command.BetInfo.Round,
                },
                //GamePot = gameRoundInfo.GamePot = betInfo.BetOrder = getGameRoundPotCmd.Pot + 1,
            };

            _iUpdateGameRoundPot.ApplyAction(gameRoundInfo, updateGameRoundPotCmd);

            _iSingleBet.Create(betInfo, command);
        }
    }
}
