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
        private GetGameResultCommand cmd;

        [Given(@"Server has game information")]
        public void GivenServerHasGameInformation(Table table)
        {
            GameRoundInformation qry;
            if (table.RowCount < 1) {
                qry = null;

            }
            else {
                qry = new GameRoundInformation {
                    BlackPot = Convert.ToInt32(table.Rows[0]["BlackPot"]),
                    WhitePot = Convert.ToInt32(table.Rows[0]["WhitePot"]),
                    HandCount = Convert.ToInt32(table.Rows[0]["HandCount"])
                };
            }

            Expect.Call(Dac.Get(new Commands.GetGameResultCommand()))
                .IgnoreArguments()
                .Return(qry);
        }

        [When(@"Call GetGameResultExecutor\(RoundID'(.*)'\)")]
        public void WhenCallGetGameResultExecutorRoundIDX(int roundId)
        {
            cmd = new GetGameResultCommand { 
                
            };
            GetGameResult.Execute(cmd, x => { });
        }
       
        [Then(@"the game result should be")]
        public void ThenTheGameResultShouldBe(Table table)
        {
            GameRoundInformation expected = new GameRoundInformation {
                 BlackPot = Convert.ToInt32(table.Rows[0]["BlackPot"]),
                 WhitePot = Convert.ToInt32(table.Rows[0]["WhitePot"]),
                 HandCount = Convert.ToInt32(table.Rows[0]["HandCount"])
                };

            Assert.AreEqual(expected.BlackPot, cmd.GameResult.BlackPot, "BlackPot");
            Assert.AreEqual(expected.WhitePot, cmd.GameResult.WhitePot, "WhitePot");
            Assert.AreEqual(expected.HandCount, cmd.GameResult.HandCount, "HandCount");

        }

        [Then(@"the game result should be null")]
        public void ThenTheGameResultShouldBeNull() {
            Assert.IsNull(cmd.GameResult);          
        }
    }
}
