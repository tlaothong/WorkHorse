using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TheS.Casinova.TwoWins.Models;
using SpecFlowAssist;
using Rhino.Mocks;
using TheS.Casinova.TwoWins.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerfEx.Infrastructure.Validation;

namespace TheS.Casinova.TwoWins.WebExecutors.Specs.Steps
{
    [Binding]
    public class GetGameStatusSteps : TwoWinGameStepsBase
    {
        private GetGameStatusCommand _cmd;
        private IEnumerable<RoundInformation> _gameStatus;
        private RoundInformation _getGameStatus;

        [Given(@"Server has game status information")]
        public void GivenServerHasGameStatusInformation(Table table)
        {
            //_gameStatus = table.CreateSet<RoundInformation>();

            _gameStatus = from item in table.Rows
                             select new RoundInformation {
                                 RoundID = Convert.ToInt32(item["RoundID"]),
                                 WinnerHightNameNormal = Convert.ToString(item["WinnerHightNameNormal"]),
                                 WinnerLowNameNormal = Convert.ToString(item["WinnerLowNameNormal"]),
                                 WinnerHightRange = Convert.ToString(item["WinnerHightRange"]),
                                 WinnerLowRange = Convert.ToString(item["WinnerLowRange"]),
                                 Pot = Convert.ToDouble(item["Pot"]),
                                 HandRange = Convert.ToString(item["HandRange"])
                             };
        }

        [Given(@"I sent RoundID '(.*)' to get game status")]
        public void GivenISentRoundIDXToGetGameStatus(int roundID)
        {
            
            _getGameStatus = (from item in _gameStatus
                              where item.RoundID == roundID
                              select item).FirstOrDefault();

            SetupResult.For(Dqr_GetGameStatus.Get(new GetGameStatusCommand()))
               .IgnoreArguments().Return(_getGameStatus);

            _cmd = new GetGameStatusCommand {
                RoundInfo = new RoundInformation {
                    RoundID = roundID
                }
            };

        }

        [Given(@"I sent RoundID '(.*)' for get game status validation")]
        public void GivenISentRoundIDสามForGetGameStatusValidation(int roundID)
        {
            _cmd = new GetGameStatusCommand {
                RoundInfo = new RoundInformation {
                    RoundID = roundID
                }
            };
        }

        // Test function
        [When(@"Call GetGameStatusExecutor\(\)")]
        public void WhenCallGetGameStatusExecutor()
        {
            GetGameStatus.Execute(_cmd, (x) => { });
        }

        //Validation
        [When(@"Call GetGameStatusExecutor\(\) for validate input")]
        public void WhenCallGetGameStatusExecutorForValidateInput()
        {
            try {
                GetGameStatus.Execute(_cmd, (x) => { });
                Assert.Fail("Shouldn't be here");
            }
            catch (Exception ex) {
                Assert.IsInstanceOfType(ex,
                    typeof(ValidationErrorException));
            }
        }

        [Then(@"GameStatus information should be as : RoundID'(.*)' WinnerHightNameNormal'(.*)' WinnerLowNameNormal'(.*)' WinnerHightRange'(.*)' WinnerLowRange'(.*)' Pot'(.*)' HandRange'(.*)'")]
        public void ThenGameStatusInformationShouldBeAsRoundIDXWinnerHightNameNormalXWinnerLowNameNormalXWinnerHightRangeXWinnerLowRangeXPotXHandRangeX(
            int roundID,
            string winnerHigntNameNormal,
            string winnerLowNameNormal,
            string winnerHightRange,
            string winnerLowRange,
            double pot,
            string handRange
            )
        {
            Assert.AreEqual(roundID,_getGameStatus.RoundID,"รหัสโต๊ะเกม");
            Assert.AreEqual(winnerHigntNameNormal, _getGameStatus.WinnerHightNameNormal,"ชื่อผู้ชนะที่ลงเดิมพันสูงสุด");
            Assert.AreEqual(winnerLowNameNormal, _getGameStatus.WinnerLowNameNormal,"ชื่อผู้ชนะที่ลงเดิมพันต่ำสุด");
            Assert.AreEqual(winnerHightRange, _getGameStatus.WinnerHightRange,"ช่วงจำนวนเงินที่ลงเดิมพันชนะสูงสุด");
            Assert.AreEqual(winnerLowRange, _getGameStatus.WinnerLowRange, "ช่วงจำนวนเงินที่ลงเดิมพันชนะต่ำสุด");
            Assert.AreEqual(pot, _getGameStatus.Pot, "จำนวนเงินทั้งหมดในเกม");
            Assert.AreEqual(handRange, _getGameStatus.HandRange, "ช่วงจำนวนมือทั้งหมดในเกม");
        }

        [Then(@"GameStatus information should be null")]
        public void ThenGameStatusInformationShouldBeNull()
        {
            Assert.AreEqual(null, _getGameStatus);
        }

        [Then(@"GameStatus information should be throw exception")]
        public void ThenGameStatusInformationShouldBeThrowException()
        {
            Assert.IsTrue(true, "Exception has been verified in the end of block When.");
        }
    }
}
