using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.ColorsGame.Commands;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.ColorsGame.DAL;
using TheS.Casinova.ColorsGame.Models;

namespace TheS.Casinova.ColorsGame.BackServices.BackExecutors
{
    public class CreateGameRoundExecutor
        : SynchronousCommandExecutorBase<CreateGameRoundCommand>
    {
        private IColorsGameDataAccess _dac;
        private IColorsGameDataBackQuery _dqr;

        public CreateGameRoundExecutor(IColorsGameDataAccess dac, IColorsGameDataBackQuery dqr)
        {
            _dac = dac;
            _dqr = dqr;
        }

        protected override void ExecuteCommand(CreateGameRoundCommand command)
        {
            //CreateGameRoundCommand cmd = new CreateGameRoundCommand();
            var lstTable = _dqr.List(new ListGameTableConfigurationsCommand {
                Name = command.Name,
            });
            var lstActiveRound = _dqr.List(new Commands.ListActiveGameRoundsCommand {
                FromTime = new DateTime(2010, 9, 8, 10, 00, 00)
            });

            //Find amount Round that must create
            int nOfRoundToCreate = lstTable.Count() - lstActiveRound.Count() + command.BufferRoundsCount;

            //Find last ActiveRound item
            GameRoundInformation lastActiveItem;
            TableConfiguration lastTableConfig;

            if (lstActiveRound.Count() == 0) {
                lastActiveItem = new GameRoundInformation {
                    TableID = 0,
                    RoundID = 0,
                    StartTime = DateTime.Today + TimeSpan.Parse("10:00"),                    
                };
                lastTableConfig = new TableConfiguration {
                    TableID = 1,
                    Interval = lstTable.Where(x => x.TableID == 1).Select(y => y.Interval).FirstOrDefault(),
                };
            }
            else {
                lastActiveItem = lstActiveRound.LastOrDefault();
                lastTableConfig = lstTable.Where(x => x.TableID == lastActiveItem.TableID).FirstOrDefault();
            }

            //Create Round
            for (int i = 0; i < nOfRoundToCreate; i++) {

                //if (nextRound.TableID == lstTable.Count()) {
                if (lastActiveItem.TableID >= lstTable.Count()) {
                    lastActiveItem.TableID = 0;
                }               

                //Setup
                lastActiveItem.RoundID += 1;
                lastActiveItem.TableID += 1;

                if (lstActiveRound.Count() == 0 && i == 0) { }
                else {
                    lastActiveItem.StartTime = lastActiveItem.StartTime.AddMinutes(lastTableConfig.Interval);
                }
                var gameDuration = lstTable.Where(x => x.TableID == lastActiveItem.TableID).Select(y => y.GameDuration).FirstOrDefault();
                lastActiveItem.EndTime = lastActiveItem.StartTime.AddMinutes(gameDuration);

                lastTableConfig = new TableConfiguration {
                    TableID = lastActiveItem.TableID,
                    Interval = lstTable.Where(x => x.TableID == lastActiveItem.TableID).Select(y => y.Interval).FirstOrDefault(),
                };

                //nextRound = new GameRoundInformation {
                command.GameRoundInformation = new GameRoundInformation {
                    TableID = lastActiveItem.TableID,
                    RoundID = lastActiveItem.RoundID,
                    StartTime = lastActiveItem.StartTime,
                    EndTime = lastActiveItem.EndTime,
                };
                //_dac.Create(nextRound, cmd);
                _dac.Create(command.GameRoundInformation, command);
            }
        }
    }
}
