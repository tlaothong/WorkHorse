using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TheS.Casinova.Colors.Models;
using Rhino.Mocks;
using TheS.Casinova.Colors.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TheS.Casinova.Colors.BackServices.Specs
{
    [Binding]
    public class GetRoundWinnerSteps : ColorsGameStepsBase
    {
        private IEnumerable<GameRoundInformation> _gameRoundInfos;
        private GameRoundInformation _expected;
        private PayForColorsWinnerInfoCommand _cmd;
        private GameRoundInformation _result;

        [Given(@"server has round information as:")]
        public void GivenServerHasRoundInformationAs(Table table)
        {
            _gameRoundInfos = (from item in table.Rows
                               select new GameRoundInformation {
                                   RoundID = Convert.ToInt32(item["RoundID"]),
                                   BlackPot = Convert.ToDouble(item["BlackPot"]),
                                   WhitePot = Convert.ToDouble(item["WhitePot"]),
                               });
        }

        [Given(@"sent RoundID: '(.*)' expected result should be BlackPot: '(.*)', WhitePot: '(.*)'")]
        public void GivenSentRoundIDXExpectedResultShouldBeBlackPotXWhitePotX(int roundID, double blackPot, double whitePot)
        {
            var result = (from item in _gameRoundInfos
                          where item.RoundID == roundID
                          select item).FirstOrDefault();

            _expected = new GameRoundInformation { 
                RoundID = roundID, 
                BlackPot = blackPot, 
                WhitePot = whitePot 
            };

            SetupResult.For(Dqr_GetGameRoundWinner.Get(new PayForColorsWinnerInfoCommand()))
                .IgnoreArguments().Return(result);
        }

        [When(@"call Get\(PayForColorsWinnerInfoCommand\), Round: '(.*)'")]
        public void WhenCallGetPayForColorsWinnerInfoCommandRound12(int roundID)
        {
            _cmd = new PayForColorsWinnerInfoCommand { GameRoundInfo = new GameRoundInformation { RoundID = roundID } };
            _result = Dqr_GetGameRoundWinner.Get(_cmd);
        }

        [Then(@"the result should be same as expected BlackPot and WhitePot")]
        public void ThenTheResultShouldBeSameAsExpectedBlackPotAndWhitePot()
        {
            Assert.AreEqual(_expected.RoundID, _result.RoundID, "RoundID");
            Assert.AreEqual(_expected.BlackPot, _result.BlackPot, "BlackPot");
            Assert.AreEqual(_expected.WhitePot, _result.WhitePot, "WhitePot");
        }
    }
}
