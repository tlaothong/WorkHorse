using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using SpecFlowAssist;
using TheS.Casinova.ColorsSvc;
using TheS.Casinova.Colors.ViewModels;
using System.Concurrency;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using TheS.Casinova.Colors.Services;

namespace TheS.Casinova.Colors.Specs.Steps
{
    [Binding]
    public class GetGameStatisticsStep
    {
        #region Background

        [Given(@"Web server have game results are")]
        public void GivenWebServerHaveGameResultsAre(Table table)
        {
            var svc = ScenarioContext.Current.Get<IColorsServiceAdapter>();

            Func<GetGameResultCommand, IObservable<GetGameResultCommand>> _mockGetGameResult = cmd =>
            {
                return Observable.Return(new GetGameResultCommand
                {
                    GameResult = ScenarioContext.Current.Get<GameRoundInformation>()
                });
            };

            SetupResult.For(svc.GetGameResult(null)).IgnoreArguments().Do(_mockGetGameResult);


            var result = from it in table.Rows
                         select new GameRoundInformation
                         {
                             RoundID = int.Parse(it["RoundID"]),
                             BlackPot = double.Parse(it["BlackPot"]),
                             WhitePot = double.Parse(it["WhitePot"]),
                             HandCount = int.Parse(it["HandCount"]),
                         };

            ScenarioContext.Current.Set<IEnumerable<GameRoundInformation>>(result);
        }

        #endregion Background

        [When(@"Request GetGameResult\( roundID = '(.*)' \)")]
        public void WhenRequestGetGameResultRoundID1(int roundID)
        {
            var gameResult = ScenarioContext.Current.Get<IEnumerable<GameRoundInformation>>();
            var queryResult = gameResult.FirstOrDefault(c => c.RoundID.Equals(roundID));
            ScenarioContext.Current.Set<GameRoundInformation>(queryResult);

            var viewModel = ScenarioContext.Current.Get<GamePlayViewModel>();
            viewModel.GetGameResult();
            ScenarioContext.Current.Get<TestScheduler>().Run();
        }

        [Then(@"Game has display game result Winner='(.*)', BlackPot='(.*)', WhitePot='(.*)', Hands='(.*)'")]
        public void ThenGameHasDisplayGameResultRoundID1WinnerBlackBlackPot1523WhitePot4526Hands452(string winner,double blackPot,double whitePot,int handsCount)
        {
            var actual = ScenarioContext.Current.Get<GamePlayViewModel>().GameResult;

            Assert.AreEqual(winner, actual.Winner, "Winner");
            Assert.AreEqual(blackPot, actual.BlackPot, "BlackPot");
            Assert.AreEqual(whitePot, actual.WhitePot, "WhitePot");
            Assert.AreEqual(handsCount, actual.Hands, "Hands");
        }

        [Then(@"Game result is null")]
        public void GameResultIsNull()
        {
            var actual = ScenarioContext.Current.Get<GamePlayViewModel>().GameResult;
            Assert.IsNull(actual, "Game result is null");
        }
    }
}
