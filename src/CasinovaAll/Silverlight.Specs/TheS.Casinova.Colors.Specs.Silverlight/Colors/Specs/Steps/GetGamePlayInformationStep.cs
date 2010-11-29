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

        [Given(@"Web service execute new bet are")]
        public void WhenWebServiceExecuteNewBetAre(Table table)
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
                             OnGoingTrackingID = Guid.Parse(it["OnGoingTrackingID"])
                         };
            ScenarioContext.Current.Set<IEnumerable<GamePlayInformation>>(result);

            Func<ListGamePlayInfoCommand, IObservable<ListGamePlayInfoCommand>> func = cmd =>
            {
                return Observable.Return(new ListGamePlayInfoCommand
                {
                    GamePlayInfos = new System.Collections.ObjectModel.ObservableCollection<GamePlayInformation>
                    (ScenarioContext.Current.Get<IEnumerable<GamePlayInformation>>())
                });
            };
            var svc = ScenarioContext.Current.Get<IColorsServiceAdapter>();
            svc.GetListGamePlayInformation(null);
            LastCall.IgnoreArguments().Do(func);
        }

        [When(@"Send request GetListGamePlayInformation\( '(.*)' \)")]
        public void WhenSendRequestGetListGamePlayInformation(string username)
        {
            var result = ScenarioContext.Current.Get<IEnumerable<GamePlayInformation>>();
            var gameTable = from c in result where c.UserName.Equals(username) select c;
            ScenarioContext.Current.Set<IEnumerable<GamePlayInformation>>(gameTable);

            var viewModel = ScenarioContext.Current.Get<GamePlayViewModel>();
            viewModel.GetListGamePlayInformation();
            ScenarioContext.Current.Get<TestScheduler>().Run();
        }

        [Then(@"Tables in GamePlayViewModel display game play information are")]
        public void ThenTablesInGamePlayViewModelDisplayGamePlayInformationAre(Table table)
        {
            var expected = (from it in table.Rows
                         select new GameTable
                         {
                             Round = Convert.ToInt32(it["Round"]),
                             Amount = Convert.ToInt32(it["Amount"]),
                             TotalBetBlack = Convert.ToInt64(it["TotalBetBlack"]),
                             TotalBetWhite = Convert.ToInt64(it["TotalBetWhite"]),
                         }).ToArray<GameTable>();

            var actual = (from c in ScenarioContext.Current.Get<GamePlayViewModel>().Tables
                         select new GameTable
                         {
                             Round = c.Round,
                             Amount = c.TotalBetBlack + c.TotalBetWhite,
                             TotalBetBlack = c.TotalBetBlack,
                             TotalBetWhite = c.TotalBetWhite,
                         }).ToArray<GameTable>();

            for (int index = 0; index < actual.Count(); index++)
            {
                Assert.AreEqual(expected[index].Round, actual[index].Round, "Game round");
                Assert.AreEqual(expected[index].Amount, actual[index].Amount, "Amount");
                Assert.AreEqual(expected[index].TotalBetBlack, actual[index].TotalBetBlack, "TotalBetBlack");
                Assert.AreEqual(expected[index].TotalBetWhite, actual[index].TotalBetWhite, "TotalBetWhite");
            }
        }
    }
}
