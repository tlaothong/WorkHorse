using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TheS.Casinova.ColorsGame.Commands;
using TheS.Casinova.ColorsGame.Models;
using Rhino.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TheS.Casinova.ColorsGame.BackServices.Specs
{
    [Binding]
    public class GetRoundWinnerQuerySteps : ColorsGameStepsBase
    {
        private PayForColorsWinnerInfoCommand _cmd;
        private IEnumerable<GamePlayInformation> _gamePlayInformations;
        private GamePlayInformation _result;
        private GamePlayInformation _expect;

        [Given(@"server has game information:")]
        public void GivenServerHasGameInformation(Table table)
        {
            _gamePlayInformations = (from item in table.Rows
                                     select new GamePlayInformation {
                                         TableID = Convert.ToInt32(item["TableID"]),
                                         RoundID = Convert.ToInt32(item["RoundID"]),
                                         Winner = item["Winner"],
                                     });
        }


        [Given(@"sent TableID: '(.*)', RoundID: '(.*)' and expected winner: '(.*)'")]
        public void GivenSentTableIDXRoundIDXAndExpectedWinnerX(int tableID, int roundID, string winner)
        {
            _expect = (from item in _gamePlayInformations
                       where (item.TableID == tableID && item.RoundID == roundID)
                       select item).FirstOrDefault();

            SetupResult.For(Dqr.Get(new PayForColorsWinnerInfoCommand()))
                    .IgnoreArguments()
                    .Return(_expect.Winner);
        }

        [Given(@"sent TableID: '(.*)', RoundID: '(.*)' and expected winner: null")]
        public void GivenSentTableIDXRoundIDXAndExpectedWinnerNull(int tableID, int roundID)
        {
            _expect = (from item in _gamePlayInformations
                       where (item.TableID == tableID && item.RoundID == roundID)
                       select item).FirstOrDefault();

            SetupResult.For(Dqr.Get(new PayForColorsWinnerInfoCommand()))
                    .IgnoreArguments()
                    .Return(null);
        }

        [When(@"call GetRoundWinnerQuery\(TableID: '(.*)', RoundID: '(.*)'\)")]
        public void WhenCallGetRoundWinnerQueryTableIDXRoundIDX(int tableID, int roundID)
        {
            _cmd = new PayForColorsWinnerInfoCommand {
                GamePlayInformation = new GamePlayInformation { TableID = tableID, RoundID = roundID }
            };

            //Action<PayForColorsWinnerInfoCommand> cmd = (a) => {};
            //PayForColorsWinnerInfoExecutor.Execute(_cmd, cmd);
            var winner = Dqr.Get(_cmd);
            _result = new GamePlayInformation { Winner = winner };
        }

        [Then(@"the round winner should be same as expected winner")]
        public void ThenTheRoundWinnerShouldBeSameAsExpectedWinner()
        {
            Assert.AreEqual(_expect.Winner, _result.Winner);
        }

        [Then(@"the game result should be null")]
        public void ThenTheGameResultShouldBeNull()
        {
            Assert.IsNull(_result.Winner);
        }
    }
}
