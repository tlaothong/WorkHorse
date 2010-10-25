using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.TwoWins.Commands;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.TwoWins.DAL;
using TheS.Casinova.TwoWins.Models;

namespace TheS.Casinova.TwoWins.BackServices.BackExecutors
{
    public class CreateGameRoundExecutor
        : SynchronousCommandExecutorBase<CreateGameRoundCommand>
    {
        private IListActiveGameRounds _iListActiveGameRounds;
        private IGetGameRoundConfiguration _iGetGameRoundConfig;
        private ICreateGameRound _iCreateGameRound;

        const int bufferRoundsCount = 1;

        public CreateGameRoundExecutor(IColorsGameDataAccess dac, IColorsGameDataBackQuery dqr)
        {
            _iCreateGameRound = dac;
            _iListActiveGameRounds = dqr;
            _iGetGameRoundConfig = dqr;
        }

        protected override void ExecuteCommand(CreateGameRoundCommand command)
        {
            ListActiveGameRoundCommand listActiveGameRoundsCmd = new ListActiveGameRoundCommand {
                FromTime = DateTime.Now,
            };

            //ดึงข้อมูลโต๊ะเกมที่สามารถเล่นได้
            listActiveGameRoundsCmd.ActiveRounds = _iListActiveGameRounds.List(listActiveGameRoundsCmd);

            GetGameRoundConfigurationCommand getGameRoundConfigCmd = new GetGameRoundConfigurationCommand {
                Name = command.ConfigName,
            };

            //ดึงข้อมูลการตั้งค่าที่ต้องการ
            getGameRoundConfigCmd.GameRoundConfiguration = _iGetGameRoundConfig.Get(getGameRoundConfigCmd);

            //กำหนดจำนวนโต๊ะเกมที่ต้องสร้างเพิ่ม
            int nOfRoundToCreate = getGameRoundConfigCmd.GameRoundConfiguration.TableAmount - listActiveGameRoundsCmd.ActiveRounds.Count() + bufferRoundsCount;

            GameRoundInformation lastActiveRound = listActiveGameRoundsCmd.ActiveRounds.LastOrDefault();

            GameRoundInformation nextRound = new GameRoundInformation();

            for (int i = 0; i < nOfRoundToCreate; i++) {
                if (listActiveGameRoundsCmd.ActiveRounds.Count() > 0) {
                    lastActiveRound.StartTime = lastActiveRound.StartTime.AddMinutes(getGameRoundConfigCmd.GameRoundConfiguration.Interval);
                    lastActiveRound.EndTime = lastActiveRound.StartTime.AddMinutes(getGameRoundConfigCmd.GameRoundConfiguration.GameDuration);
                    lastActiveRound.RoundID += 1;
                }
                else {
                    lastActiveRound = new GameRoundInformation();
                    lastActiveRound.StartTime = new DateTime(2553,3,12,10,0,0);
                    lastActiveRound.EndTime = lastActiveRound.StartTime.AddMinutes(getGameRoundConfigCmd.GameRoundConfiguration.GameDuration);
                    lastActiveRound.RoundID += 1;

                    List<GameRoundInformation> list = new List<GameRoundInformation>();
                    list.Add(lastActiveRound);
                    listActiveGameRoundsCmd.ActiveRounds = list;
                }

                nextRound = new GameRoundInformation {
                    RoundID = lastActiveRound.RoundID,
                    StartTime = lastActiveRound.StartTime,
                    EndTime = lastActiveRound.EndTime,
                };
                

                _iCreateGameRound.Create(nextRound, command);
            }
        }
    }
}
