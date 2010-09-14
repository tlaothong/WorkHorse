using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Rhino.Mocks;
using PerfEx.Demo.SimpleGame.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PerfEx.Demo.SimpleGame.Specs.Steps {
    [Binding]
    public class StepDefinitions : GameTableConfiguratorStepsBase {

        MockRepository Mocks { get { return SpecEventDefinitions.Mocks; } }

        [Given(@"the active GameRounds are")]
        public void GivenTheActiveGameRoundsAre(Table table) {
            var qry = (from it in table.Rows
                       select new GameRound {
                           TableID = Convert.ToInt32(it["TableID"]),
                           RoundID = Convert.ToInt32(it["RoundID"]),
                           StartTime = DateTime.Today+TimeSpan.Parse(it["StartTime"]),
                           EndTime = DateTime.Today + TimeSpan.Parse(it["EndTime"]),
                       });
            SetupResult.For(Dac.List(new Commands.ListActiveGameRoundsCommand()))
                .IgnoreArguments()
                .Return(qry);   
        }
        [Given(@"the table configuration set '(.*)' has the following data")]
        public void GivenTheTableConfigurationSetConfig1HasTheFollowingData(string name,Table table) {
            
            var qry = (from it in table.Rows
                       select new GameTable {
                           TableID = Convert.ToInt32(it["TableID"]),
                           GameDuration = Convert.ToInt32(it["GameDuration"]),
                           Interval = Convert.ToInt32(it["Interval"]),
                       });
            SetupResult.For(Dac.List(new Commands.ListGameTableConfigurationsCommand()))
                .IgnoreArguments()
                .Return(qry);
        }

        [Given(@"Expect result should be add")]
        public void GivenExpectResultShouldBeAdd(Table table) {
            var qry = (from it in table.Rows
                       select new GameRound {
                           TableID = Convert.ToInt32(it["TableID"]),
                           RoundID = Convert.ToInt32(it["RoundID"]),
                           StartTime = DateTime.Today + TimeSpan.Parse(it["StartTime"]),
                           EndTime = DateTime.Today + TimeSpan.Parse(it["EndTime"]),
                       });
            Queue<GameRound> expect = new Queue<GameRound>(qry);
            Action<GameRound, Commands.CreateGameRoundCommand> CheckRound = (round,cmd) => {
                var exp = expect.Dequeue();
                Assert.AreEqual(exp.TableID, round.TableID,"Check TableID");
                Assert.AreEqual(exp.RoundID, round.RoundID,"Check RoundID");
                Assert.AreEqual(exp.StartTime, round.StartTime,"Check Start Time");
                Assert.AreEqual(exp.EndTime, round.EndTime,"Check EndTime");
            };
            Dac.Create(new GameRound(),new Commands.CreateGameRoundCommand());
            LastCall.IgnoreArguments().Do(CheckRound);
                       
        }

        [When(@"call CreateGameRounds\('(.*)',(.*)\)")]
        public void WhenCallCreateGameRoundsConfig11(string name,int bufferRoundCount) {
             TableCfgtor.CreateGameRounds(name, bufferRoundCount);
        }

        [Then(@"the result rounds should be saved to the ICreateGameRound\.Create\(\) with data")]
        public void ThenTheResultRoundsShouldBeSavedToTheICreateGameRound_CreateWithData(Table table) {
            
        }
    }
}
