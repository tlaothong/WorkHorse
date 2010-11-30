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
    public class CreateGameRoundExecutor
        : SynchronousCommandExecutorBase<CreateGameRoundCommand>
    {
        private IListActiveGameRounds _iListActiveGameRounds;
        private IGetGameRoundConfiguration _iGetGameRoundConfig;
        private ICreateGameRound _iCreateGameRound;

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
            listActiveGameRoundsCmd.ActiveGameRoundInfo = _iListActiveGameRounds.List(listActiveGameRoundsCmd);

            GetGameRoundConfigurationCommand getGameRoundConfigCmd = new GetGameRoundConfigurationCommand {
                GameRoundConfig = command.GameRoundConfigName,
            };

            //ดึงข้อมูลการตั้งค่าที่ต้องการ
            getGameRoundConfigCmd.GameRoundConfig = _iGetGameRoundConfig.Get(getGameRoundConfigCmd);

            //กำหนดจำนวนโต๊ะเกมที่ต้องสร้างเพิ่ม
            int nOfRoundToCreate = getGameRoundConfigCmd.GameRoundConfig.TableAmount - listActiveGameRoundsCmd.ActiveGameRoundInfo.Count() 
                + getGameRoundConfigCmd.GameRoundConfig.BufferRoundsCount;

            //ตรวจสอบว่ามีโต๊ะเกมที่ต้องสร้างใหม่หรือไม่
            if (nOfRoundToCreate > 0) {
                GameRoundInformation lastActiveRound = listActiveGameRoundsCmd.ActiveGameRoundInfo.LastOrDefault();

            GameRoundInformation nextRound = new GameRoundInformation();

                for (int i = 0; i < nOfRoundToCreate; i++) {
                    if (listActiveGameRoundsCmd.ActiveGameRoundInfo.Count() > 0) {
                        lastActiveRound.StartTime = lastActiveRound.StartTime.AddMinutes(getGameRoundConfigCmd.GameRoundConfig.Interval);
                        lastActiveRound.EndTime = lastActiveRound.StartTime.AddMinutes(getGameRoundConfigCmd.GameRoundConfig.GameDuration);
                        lastActiveRound.RoundID += 1;
                    }
                    else {
                        lastActiveRound = new GameRoundInformation();
                        lastActiveRound.StartTime = DateTime.Now;
                        lastActiveRound.EndTime = lastActiveRound.StartTime.AddMinutes(getGameRoundConfigCmd.GameRoundConfig.GameDuration);
                        lastActiveRound.RoundID += 1;

                        List<GameRoundInformation> list = new List<GameRoundInformation>();
                        list.Add(lastActiveRound);
                        listActiveGameRoundsCmd.ActiveGameRoundInfo = list;
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
}
