using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TheS.Casinova.ColorsGame.Models;
using Rhino.Mocks;
using TheS.Casinova.ColorsGame.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TheS.Casinova.ColorsGame.BackServices.Specs
{
    [Binding]
    public class CreateGameRoundSteps : ColorsGameStepsBase
    {
        [Given(@"the table configuration set '(.*)' has the following data")]
        public void GivenTheTableConfigurationSetXXXHasTheFollowingData(string name, Table table)
        {
            var qry = (from it in table.Rows
                       select new TableConfiguration {
                           TableID = Convert.ToInt32(it["TableID"]),
                           GameDuration = Convert.ToInt32(it["GameDuration"]),
                           Interval = Convert.ToInt32(it["Interval"]),
                       });
            SetupResult.For(Dqr.List(new ListGameTableConfigurationCommand()))
                .IgnoreArguments()
                .Return(qry);
        }

        [Given(@"the active GameRounds are")]
        public void GivenTheActiveGameRoundsAre(Table table)
        {
            var qry = (from it in table.Rows
                       select new GameRoundInformation {
                           TableID = Convert.ToInt32(it["TableID"]),
                           RoundID = Convert.ToInt32(it["RoundID"]),
                           StartTime = DateTime.Today + TimeSpan.Parse(it["StartTime"]),
                           EndTime = DateTime.Today + TimeSpan.Parse(it["EndTime"]),
                       });
            SetupResult.For(Dqr.List(new ListActiveGameRoundsCommand()))
                .IgnoreArguments()
                .Return(qry);
        }

        [Given(@"Expect result should be add")]
        public void GivenExpectResultShouldBeAdd(Table table)
        {
            var qry = (from it in table.Rows
                       select new GameRoundInformation {
                           TableID = Convert.ToInt32(it["TableID"]),
                           RoundID = Convert.ToInt32(it["RoundID"]),
                           StartTime = DateTime.Today + TimeSpan.Parse(it["StartTime"]),
                           EndTime = DateTime.Today + TimeSpan.Parse(it["EndTime"]),
                       });

            Queue<GameRoundInformation> expect = new Queue<GameRoundInformation>(qry);

            Func<GameRoundInformation, CreateGameRoundCommand, GameRoundInformation> CheckRound = (round, cmd) => {
                var exp = expect.Dequeue();
                Assert.AreEqual(exp.TableID, round.TableID, "Check TableID");
                Assert.AreEqual(exp.RoundID, round.RoundID, "Check RoundID");
                Assert.AreEqual(exp.StartTime, round.StartTime, "Check Start Time");
                Assert.AreEqual(exp.EndTime, round.EndTime, "Check EndTime");
                return round;
            };

            for (int i = 0; i < table.RowCount; i++) {
                Expect.Call(Dac.Create(new GameRoundInformation(), new CreateGameRoundCommand()))
                    .IgnoreArguments().Do(CheckRound);
            }
        }

        [When(@"call CreateGameRounds\('(.*)', (.*)\)")]
        public void WhenCallCreateGameRoundsConfig11(string name, int bufferRoundCount)
        {
            CreateGameRoundCommand cmd = new CreateGameRoundCommand
            {
                Name = name,
                BufferRoundsCount = bufferRoundCount,
            };

            Action<CreateGameRoundCommand> act = (a) => {};
            CreateGameRoundExecutor.Execute(cmd, act);
        }

        [Then(@"the result rounds should be saved to the IColorsGameDataAccess\.Create\(\) with data")]
        public void ThenTheResultRoundsShouldBeSavedToTheIColorsGameDataAccess_CreateWithData(Table table)
        {
            Assert.IsTrue(true, "Expectation has been verified in the end of block When.");
        }
    }
}
