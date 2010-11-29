using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using SpecFlowAssist;
using TheS.Casinova.ColorsSvc;
using TheS.Casinova.Colors.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheS.Casinova.Colors.ViewModels;
using System.Concurrency;
using Rhino.Mocks;
using TheS.Casinova.Colors.Services;

namespace TheS.Casinova.Colors.Specs.Steps
{
    [Binding]
    public class GetGamePlayInformationStep
    {
        #region Background

        [Given(@"Web server have game play information are")]
        public void GivenWebServerHaveGamePlayInformationAre(Table table)
        {
            var result = from it in table.Rows
                         select new GamePlayInformation
                         {
                             UserName = it["UserName"],
                             TableID = Convert.ToInt32(it["TableID"]),
                             RoundID = Convert.ToInt32(it["RoundID"]),
                             TotalBetAmountOfBlack = Convert.ToDouble(it["TotalBetAmountOfBlack"]),
                             TotalBetAmountOfWhite = Convert.ToDouble(it["TotalBetAmountOfWhite"]),
                             TrackingID = Guid.Parse(it["TrackingID"]),
                             Winner = it["Winner"],
                             OnGoingTrackingID = Guid.Parse(it["OnGoingTrackingID"]),
                         };
            ScenarioContext.Current.Set<IEnumerable<GamePlayInformation>>(result);

            var svc = ScenarioContext.Current.Get<IColorsServiceAdapter>();
            Func<ListGamePlayInfoCommand, IObservable<ListGamePlayInfoCommand>> func = cmd =>
            {
                return Observable.Return(new ListGamePlayInfoCommand
                {
                    GamePlayInfos = new System.Collections.ObjectModel.ObservableCollection<GamePlayInformation>
                    (ScenarioContext.Current.Get<IEnumerable<GamePlayInformation>>())
                });
            };
            Expect.Call(svc.GetListGamePlayInformation(null)).IgnoreArguments().Do(func);
        }

        #endregion Background

        [When(@"Send request GetListGamePlayInformation username=(.*)")]
        public void WhenSendRequestGetListGamePlayInformation(string username)
        {
            var result = ScenarioContext.Current.Get<IEnumerable<GamePlayInformation>>().Where(c => c.UserName.Equals(username));
            ScenarioContext.Current.Set(result);

            var viewModel = ScenarioContext.Current.Get<GamePlayViewModel>();
            viewModel.GetListGamePlayInformation();
            ScenarioContext.Current.Get<TestScheduler>().Run();
        }

        [Then(@"Tables in GamePlayViewModel display game play information are")]
        public void ThenTablesInGamePlayViewModelDisplayGamePlayInformationAre(Table table)
        {
            var expected = (from it in table.Rows
                            select new GamePlayUIViewModel
                         {
                             RoundID = Convert.ToInt32(it["Round"]),
                             Amount = Convert.ToInt32(it["Amount"]),
                             TotalAmountOfBlack = Convert.ToInt64(it["TotalBetBlack"]),
                             TotalAmountOfWhite = Convert.ToInt64(it["TotalBetWhite"]),
                             Winner = it["Winner"]
                         }).ToArray<GamePlayUIViewModel>();

            var actual = (from c in ScenarioContext.Current.Get<GamePlayViewModel>().ActiveGameRoundTables
                          select new GamePlayUIViewModel
                         {
                             RoundID = c.RoundID,
                             Amount = c.TotalAmountOfBlack + c.TotalAmountOfWhite,
                             TotalAmountOfBlack = c.TotalAmountOfBlack,
                             TotalAmountOfWhite = c.TotalAmountOfWhite,
                             Winner = c.Winner
                         }).ToArray<GamePlayUIViewModel>();


            Assert.AreEqual(expected.Count(), actual.Count(), "Expect game count");

            for (int index = 0; index < actual.Count(); index++)
            {
                Assert.AreEqual(expected[index].RoundID, actual[index].RoundID, "Game round id");
                Assert.AreEqual(expected[index].Amount, actual[index].Amount, "Amount");
                Assert.AreEqual(expected[index].TotalAmountOfBlack, actual[index].TotalAmountOfBlack, "TotalBetBlack");
                Assert.AreEqual(expected[index].TotalAmountOfWhite, actual[index].TotalAmountOfWhite, "TotalBetWhite");
                Assert.AreEqual(expected[index].Winner, actual[index].Winner, "Winner");
            }
        }
    }
}
