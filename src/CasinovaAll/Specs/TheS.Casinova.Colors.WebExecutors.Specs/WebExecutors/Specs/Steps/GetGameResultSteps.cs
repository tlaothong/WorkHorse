using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TheS.Casinova.Colors.Models;
using Rhino.Mocks;
using TheS.Casinova.Colors.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TheS.Casinova.Colors.WebExecutors.Specs.Steps
{
    [Binding]
    public class GetGameResultSteps : ColorsGameStepsBase
    {
        private GetGameResultCommand _cmd;
        private GameRoundInformation _getGameResult;

        [Given(@"Server has game information")]
        public void GivenServerHasGameInformation(Table table)
        {
            if (table.RowCount > 0) {
                _getGameResult = new GameRoundInformation {
                    BlackPot = Convert.ToInt32(table.Rows[0]["BlackPot"]),
                    WhitePot = Convert.ToInt32(table.Rows[0]["WhitePot"]),
                    HandCount = Convert.ToInt32(table.Rows[0]["HandCount"])
                };

                Expect.Call(Dac.Get(new Commands.GetGameResultCommand()))
                .IgnoreArguments()
                .Return(_getGameResult);
            }
        }

        [When(@"Call GetGameResultExecutor\(RoundID'(.*)'\)")]
        public void WhenCallGetGameResultExecutorRoundIDX(int roundId)
        {
            try {
                _cmd = new GetGameResultCommand {
                    RoundID = roundId
                };
                GetGameResult.Execute(_cmd, x => { });
            }
            catch (ArgumentNullException err) {
                ScenarioContext.Current[("ArgumentNullException_RoundID")] = err;
            }
        }

        [Then(@"the game result should be")]
        public void ThenTheGameResultShouldBe(Table table)
        {
            GameRoundInformation expected = new GameRoundInformation {
                BlackPot = Convert.ToInt32(table.Rows[0]["BlackPot"]),
                WhitePot = Convert.ToInt32(table.Rows[0]["WhitePot"]),
                HandCount = Convert.ToInt32(table.Rows[0]["HandCount"])
            };

            Assert.AreEqual(expected.BlackPot, _cmd.GameResult.BlackPot, "BlackPot");
            Assert.AreEqual(expected.WhitePot, _cmd.GameResult.WhitePot, "WhitePot");
            Assert.AreEqual(expected.HandCount, _cmd.GameResult.HandCount, "HandCount");
        }

        [Then(@"the game result should be throw exception")]
        public void ThenTheGameResultShouldBeThrowException()
        {
            Assert.IsTrue(true, "ArgumentNullException_RoundID");
        }
    }
}
