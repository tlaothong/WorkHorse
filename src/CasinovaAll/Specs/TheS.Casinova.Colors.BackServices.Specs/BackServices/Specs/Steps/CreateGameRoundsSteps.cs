﻿using System;
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

        [Given(@"server has GameRoundConfigName information as:")]
        public void GivenServerHasGameRoundConfigurationInformationAs(Table table)
        {
            _roundConfig = (from item in table.Rows
                            select new GameRoundConfiguration {
                                Name = item["Name"],
                                TableAmount = Convert.ToInt32(item["TableAmount"]),
                                GameDuration = Convert.ToInt32(item["GameDuration"]),
                                Interval = Convert.ToInt32(item["Interval"]),
                            });
        }

         [Given(@"server should recieved the active game round data as:")]
        public void GivenServerShouldRecievedTheActiveGameRoundDataAs(Table table)
        {
            _activeRound = (from item in table.Rows
                            select new GameRoundInformation {
                                RoundID = Convert.ToInt32(item["GameRoundInfoRoundID"]),
                                StartTime = DateTime.Parse(item["StartTime"]),
                                EndTime = DateTime.Parse(item["EndTime"]),
                            });
            SetupResult.For(Dqr_ListActiveGameRounds.List(new ListActiveGameRoundCommand()))
                .IgnoreArguments().Return(_activeRound);
        }

       [Given(@"sent Name: '(.*)', the GameRoundConfigName should recieved data as GameRoundConfigName\(Name: '(.*)', TableAmount: '(.*)', GameDuration: '(.*)', Inverval: '(.*)'\)")]
        public void GivenSentNameXTheGameRoundConfigurationShouldRecievedDataAsGameRoundConfigurationNameXTableAmountXGameDurationXInvervalX(string name, string configName, int tableAmount, int gameDuration, int interval)
        {
            _expectConfig = (from item in _roundConfig
                             where item.Name == name
                             select item).FirstOrDefault();

            SetupResult.For(Dqr_GetGameRoundConfiguration.Get(new GetGameRoundConfigurationCommand()))
                .IgnoreArguments().Return(_expectConfig);
        }

        [Given(@"Expect result should be create as:")]
        public void GivenExpectResultShouldBeCreateAs(Table table)
        {
            var qry = (from item in table.Rows                                      
                                      select new GameRoundInformation {
                                          RoundID = Convert.ToInt32(item["GameRoundInfoRoundID"]),
                                          StartTime = DateTime.Parse(item["StartTime"]),
                                          EndTime = DateTime.Parse(item["EndTime"]),
                                      });

            Queue<GameRoundInformation> expect = new Queue<GameRoundInformation>(qry);
            Func<GameRoundInformation, CreateGameRoundCommand, GameRoundInformation> checkdata = (gameRoundInfo, cmd) => {
                var exp = expect.Dequeue();
                Assert.AreEqual(exp.RoundID, gameRoundInfo.RoundID, "GameRoundInfoRoundID");
                Assert.AreEqual(exp.StartTime, gameRoundInfo.StartTime, "StartTime");
                Assert.AreEqual(exp.EndTime, gameRoundInfo.EndTime, "EndTime");
                return gameRoundInfo;
            };

            Dac_CreateGameRound.Create(new GameRoundInformation(), new CreateGameRoundCommand());
            LastCall.IgnoreArguments().Do(checkdata);
        }

        [When(@"call CreateGameRound\(GameRoundConfigName: '(.*)'\)")]
        public void WhenCallCreateGameRoundConfigNameX(string configName)
        {
            CreateGameRoundCommand cmd = new CreateGameRoundCommand { 
                GameRoundConfig = new GameRoundConfiguration {
                    Name = configName 
                }
            };
            CreateGameRoundsExecutor.Execute(cmd, (x) => { });            
        }

        [Then(@"the result should be create data as:")]
        public void ThenTheResultShouldBeCreateDataAs(Table table)
        {
            Assert.IsTrue(true, "Expectation has been verified in the end of block When.");
        }

    }
}
