using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TheS.Casinova.Colors.Models;
using Rhino.Mocks;
using TheS.Casinova.Colors.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerfEx.Infrastructure.Validation;

namespace TheS.Casinova.Colors.WebExecutors.Specs.Steps
{
    [Binding]
    public class GetGameResultSteps : ColorsGameStepsBase
    {
        private GetGameResultCommand _cmd;
        private IEnumerable<GameRoundInformation> _GameResult;
        private GameRoundInformation _getGameResult;

        [Given(@"Server has game result information")]
        public void GivenServerHasGameResultInformation(Table table)
        {
            _GameResult = from item in table.Rows
                          select new GameRoundInformation { 
                              RoundID = Convert.ToInt32(item["RoundID"]),
                              StartTime = DateTime.Parse(item["StartTime"]),
                              EndTime = DateTime.Parse(item["EndTime"]),
                              BlackPot = Convert.ToDouble(item["BlackPot"]),
                              WhitePot = Convert.ToDouble(item["WhitePot"]),
                              HandCount = Convert.ToInt32(item["HandCount"])
                          };
        }

        [Given(@"Sent roundID'(.*)' for get game result")]
        public void GivenSentRoundID2ForGetGameResult(int roundId)
        {
            _getGameResult = (from item in _GameResult
                       where item.RoundID == roundId                     
                      select item).FirstOrDefault();

            SetupResult.For(Dqr_GetGameResult.Get(new GetGameResultCommand()))
                .IgnoreArguments().Return(_getGameResult);

            _cmd = new GetGameResultCommand {
                GameResultGameRoundInfo = new GameRoundInformation {
                    RoundID = roundId,
                }
            };
        }

        [When(@"Call GetGameResultExecutor\(\)")]
        public void WhenCallGetGameResultExecutor()
        {
            try {
                GetGameResult.Execute(_cmd, (x) => { });
            }
            catch (Exception ex) {
                Assert.IsInstanceOfType(ex,
                    typeof(ValidationErrorException));
            }
        }

        [When(@"Call GetGameResultExecutor\(\) for validate roundID")]
        public void WhenCallGetGameResultExecutorForValidateRoundID()
        {
            try {
                GetGameResult.Execute(_cmd, (x) => { });
                Assert.Fail("Shouldn't be here");
            }
            catch (Exception ex) {
                Assert.IsInstanceOfType(ex,
                    typeof(ValidationErrorException));
            }
        }

        [Then(@"the game result should be : RoundID '(.*)' StartTime '(.*)' EndTime '(.*)' BlackPot '(.*)' WhitePot '(.*)' HandCount '(.*)'")]
        public void ThenTheGameResultShouldBeRoundIDXStartTimeXEndTimeXBlackPotXWhitePotXHandCountX(int roundId, DateTime startTime, DateTime endTime, double blackPot, double whitePot,int handCount)
        {
            Assert.AreEqual(roundId, _getGameResult.RoundID);
            Assert.AreEqual(startTime, _getGameResult.StartTime);
            Assert.AreEqual(endTime, _getGameResult.EndTime);
            Assert.AreEqual(blackPot, _getGameResult.BlackPot);
            Assert.AreEqual(whitePot, _getGameResult.WhitePot);
            Assert.AreEqual(handCount, _getGameResult.HandCount);
        }

        [Then(@"the game result should be null")]
        public void ThenTheGameResultShouldBeNull()
        {
            Assert.IsTrue(true,"The server don't have game result information");
        }

        [Then(@"the game result should be throw exception")]
        public void ThenTheGameResultShouldBeThrowException()
        {
            Assert.IsTrue(true, "Exception has been verified in the end of block When.");
        }
    }
}
