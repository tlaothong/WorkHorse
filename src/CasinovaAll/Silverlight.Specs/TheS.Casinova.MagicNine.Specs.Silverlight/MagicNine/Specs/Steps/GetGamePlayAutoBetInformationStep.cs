using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using SpecFlowAssist;
using TheS.Casinova.MagicNine.Services;
using Rhino.Mocks;
using TheS.Casinova.MagicNineSvc;
using TheS.Casinova.MagicNine.ViewModels;
using System.Concurrency;
using TheS.Casinova.MagicNine.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TheS.Casinova.MagicNine.Specs.Steps
{
    [Binding]
    public class GetGamePlayAutoBetInformationStep
    {
        [Given(@"Web server have game play auto bet information are")]
        public void GivenWebServerHaveGamePlayAutoBetInformationAre(Table table)
        {
            var autoBetList = from c in table.Rows
                                         select new GamePlayAutoBetInformation
                                         {
                                             UserName = c["UserName"],
                                             RoundID = int.Parse(c["RoundID"]),
                                             Amount = int.Parse(c["Amount"]),
                                             Interval = int.Parse(c["Interval"]),
                                             StratTrackingID = Guid.Parse(c["StratTrackingID"])
                                         };
            ScenarioContext.Current.Set(autoBetList);

            var svc = ScenarioContext.Current.Get<IMagicNineServiceAdapter>();

            Func<ListGamePlayAutoBetInfoCommand,IObservable<ListGamePlayAutoBetInfoCommand>> func = cmd =>{
                return Observable.Return(new ListGamePlayAutoBetInfoCommand
                {
                    GamePlayAutoBet = new System.Collections.ObjectModel.ObservableCollection<GamePlayAutoBetInformation>
                    (ScenarioContext.Current.Get<IEnumerable<GamePlayAutoBetInformation>>())
                });
            };
            SetupResult.For(svc.GetListGamePlayAutoBetInformation(null)).IgnoreArguments().Do(func);
        }

        [When(@"Send request GetListGamePlayAutoBet\( '(.*)' \)")]
        public void WhenSendRequestGetListGamePlayAutoBetMary(string username)
        {
            var autoBetList = ScenarioContext.Current.Get<IEnumerable<GamePlayAutoBetInformation>>()
                .Where(c => c.UserName.Equals(username));
            ScenarioContext.Current.Set(autoBetList);

            var viewModel = ScenarioContext.Current.Get<GamePlayViewModel>();
            viewModel.GetLisGamePlayAutoBetInformation();
            ScenarioContext.Current.Get<TestScheduler>().Run();
        }

        [Then(@"Tables in GamePlayViewModel display game play information are")]
        public void ThenTablesInGamePlayViewModelDisplayGamePlayInformationAre(Table table)
        {
            var expect = (from c in table.Rows
                         select new GamePlayUIViewModel
                         {
                             RoundID = int.Parse(c["RoundID"]),
                             WinnerPoint = int.Parse(c["WinnerPoint"]),
                             Amount = double.Parse(c["Amount"]),
                             Interval = int.Parse(c["Interval"]),
                             AutoBetTrackingID = Guid.Parse(c["StratTrackingID"])
                         }).ToArray<GamePlayUIViewModel>();

            var actual  = ScenarioContext.Current.Get<GamePlayViewModel>().ActiveGameRoundTables.ToArray<GamePlayUIViewModel>();

            Assert.AreEqual(expect.Count(), actual.Count(), "Count");

            for (int elementIndex = 0; elementIndex < actual.Count(); elementIndex++)
            {
                Assert.AreEqual(expect[elementIndex].RoundID, actual[elementIndex].RoundID, "RoundID");
                Assert.AreEqual(expect[elementIndex].WinnerPoint, actual[elementIndex].WinnerPoint, "WinnerPoint");
                Assert.AreEqual(expect[elementIndex].Amount, actual[elementIndex].Amount, "Amount");
                Assert.AreEqual(expect[elementIndex].Interval, actual[elementIndex].Interval, "Interval");
                Assert.AreEqual(expect[elementIndex].AutoBetTrackingID, actual[elementIndex].AutoBetTrackingID, "AutoBetTrackingID");
            }

        }
    }
}
