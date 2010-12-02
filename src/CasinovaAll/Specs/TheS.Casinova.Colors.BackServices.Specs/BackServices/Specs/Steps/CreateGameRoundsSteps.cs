using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TheS.Casinova.Colors.Models;
using Rhino.Mocks;
using TheS.Casinova.Colors.BackServices.Specs;
using TheS.Casinova.Colors.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TheS.Casinova.Colors.BackServices
{
    [Binding]
    public class CreateGameRoundsSteps
        : ColorsGameStepsBase
    {
        private IEnumerable<GameRoundConfiguration> _roundConfig;
        private IEnumerable<GameRoundInformation> _activeRound;
        private GameRoundConfiguration _expectConfig;

        [Given(@"server has GameRoundConfiguration information as:")]
        public void GivenServerHasGameRoundConfigurationInformationAs(Table table)
        {
            _roundConfig = (from item in table.Rows
                            select new GameRoundConfiguration {
                                ConfigName = item["Name"],
                                TableAmount = Convert.ToInt32(item["TableAmount"]),
                                GameDuration = Convert.ToInt32(item["GameDuration"]),
                                Interval = Convert.ToInt32(item["Interval"]),
                                BufferRoundsCount = Convert.ToInt32(item["BufferRoundsCount"]),
                            });
        }

         [Given(@"server should recieved the active game round data as:")]
        public void GivenServerShouldRecievedTheActiveGameRoundDataAs(Table table)
        {
            _activeRound = (from item in table.Rows
                            select new GameRoundInformation {
                                RoundID = Convert.ToInt32(item["RoundID"]),
                                StartTime = DateTime.Parse(item["StartTime"]),
                                EndTime = DateTime.Parse(item["EndTime"]),
                            });
            SetupResult.For(Dqr_ListActiveGameRounds.List(new ListActiveGameRoundCommand()))
                .IgnoreArguments().Return(_activeRound);
        }

         [Given(@"sent Name: '(.*)', the GameRoundConfiguration should recieved")]
         public void GivenSentNameXTheGameRoundConfigurationShouldRecieved(string name)
         {
            _expectConfig = (from item in _roundConfig
                             where item.ConfigName == name
                             select item).FirstOrDefault();

            SetupResult.For(Dqr_GetGameRoundConfiguration.Get(new GetGameRoundConfigurationCommand()))
                .IgnoreArguments().Return(_expectConfig);
        }

        [Given(@"Expect result should be create as:")]
        public void GivenExpectResultShouldBeCreateAs(Table table)
        {
            var qry = (from item in table.Rows                                      
                                      select new GameRoundInformation {
                                          RoundID = Convert.ToInt32(item["RoundID"]),
                                          StartTime = DateTime.Parse(item["StartTime"]),
                                          EndTime = DateTime.Parse(item["EndTime"]),
                                      });

            Queue<GameRoundInformation> expect = new Queue<GameRoundInformation>(qry);
            Func<GameRoundInformation, CreateGameRoundCommand, GameRoundInformation> checkdata = (gameRoundInfo, cmd) => {
                var exp = expect.Dequeue();
                Assert.AreEqual(exp.RoundID, gameRoundInfo.RoundID, "RoundID");
                Assert.AreEqual(exp.StartTime, gameRoundInfo.StartTime, "StartTime");
                Assert.AreEqual(exp.EndTime, gameRoundInfo.EndTime, "EndTime");
                return gameRoundInfo;
            };

            Dac_CreateGameRound.Create(new GameRoundInformation(), new CreateGameRoundCommand());
            LastCall.IgnoreArguments().Do(checkdata);
        }

        [Given(@"Expect result should be create at datetime \((.*)\):")]
        public void GivenExpectResultShouldBeCreateAtDatetimeX(string dateTime, Table table)
        {
            GameRoundInformation gameRound = new GameRoundInformation();

            var qry = (from item in table.Rows
                       select new GameRoundInformation {
                           RoundID = Convert.ToInt32(item["RoundID"]),
                           StartTime = DateTime.Parse(item["StartTime"]),
                           EndTime = DateTime.Parse(item["EndTime"]),
                       });

            Queue<GameRoundInformation> expect = new Queue<GameRoundInformation>(qry);
            Func<GameRoundInformation, CreateGameRoundCommand, GameRoundInformation> checkdata = (gameRoundInfo, cmd) => {

                if (expect.Count() ==  _expectConfig.TableAmount + _expectConfig.BufferRoundsCount) {
                    gameRoundInfo.StartTime = gameRound.StartTime = DateTime.Parse(dateTime);
                    gameRoundInfo.EndTime = gameRound.EndTime = gameRoundInfo.StartTime.AddMinutes(_expectConfig.GameDuration);
                }
                else {
                    gameRoundInfo.StartTime = gameRound.StartTime = gameRound.StartTime.AddMinutes(_expectConfig.Interval);
                    gameRoundInfo.EndTime = gameRound.StartTime.AddMinutes(_expectConfig.GameDuration);                    
                }

                var exp = expect.Dequeue();
                Assert.AreEqual(exp.RoundID, gameRoundInfo.RoundID, "RoundID");
                Assert.AreEqual(exp.StartTime, gameRoundInfo.StartTime, "StartTime");
                Assert.AreEqual(exp.EndTime, gameRoundInfo.EndTime, "EndTime");
                return gameRoundInfo;
            };

            Dac_CreateGameRound.Create(new GameRoundInformation(), new CreateGameRoundCommand());
            LastCall.IgnoreArguments().Do(checkdata);
        }

        [When(@"call CreateGameRound\(ConfigName: '(.*)'\)")]
        public void WhenCallCreateGameRoundConfigNameX(string configName)
        {
            CreateGameRoundCommand cmd = new CreateGameRoundCommand {
                GameRoundConfigName = new GameRoundConfiguration {
                    ConfigName = configName
                },
            };
            CreateGameRoundsExecutor.Execute(cmd, (x) => { });            
        }

        [Then(@"the result should be create data as:")]
        public void ThenTheResultShouldBeCreateDataAs(Table table)
        {
            Assert.IsTrue(true, "Expectation has been verified in the end of block When.");
        }

        [Then(@"the result should be same as old")]
        public void ThenTheResultShouldBeSameAsOld()
        {
            Assert.IsTrue(true, "Expectation has been verified in the end of block When.");
        }
    }
}
