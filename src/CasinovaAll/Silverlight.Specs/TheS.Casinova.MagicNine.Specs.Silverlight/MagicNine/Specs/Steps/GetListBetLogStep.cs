using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using SpecFlowAssist;
using Rhino.Mocks;
using TheS.Casinova.MagicNine.Services;
using TheS.Casinova.MagicNineSvc;
using TheS.Casinova.MagicNine.ViewModels;
using System.Concurrency;
using TheS.Casinova.MagicNine.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TheS.Casinova.MagicNine.Specs.Steps
{
    [Binding]
    public class GetListBetLogStep
    {
        #region Background

        [Given(@"Web server have list bet log are")]
        public void GivenWebServerHaveListBetLogAre(Table table)
        {
            var betLogs = from c in table.Rows
                          select new BetInformation
                          {
                              RoundID = int.Parse(c["RoundID"]),
                              UserName = c["UserName"],
                              BetOrder = int.Parse(c["BetOrder"]),
                              BetDateTime = DateTime.Parse(c["BetDateTime"])
                          };
            ScenarioContext.Current.Set(betLogs);

            var svc = ScenarioContext.Current.Get<IMagicNineServiceAdapter>();
            Func<ListBetLogCommand, IObservable<ListBetLogCommand>> func = cmd =>
            {
                return Observable.Return(new ListBetLogCommand
                {
                    BetInformations = new System.Collections.ObjectModel.ObservableCollection<BetInformation>
                    (ScenarioContext.Current.Get<IEnumerable<BetInformation>>())
                });
            };

            Expect.Call(svc.GetListBetLog(null)).IgnoreArguments().Do(func);
        }

        #endregion Background

        [When(@"Send request GetListBetlog\( '(.*)' \) RoundID='(.*)'")]
        public void WhenSendRequestGetListBetlogSakulRoundID999(string username, int RoundID)
        {
            var betLogs = ScenarioContext.Current.Get<IEnumerable<BetInformation>>()
                .Where(c => c.UserName.Equals(username) && c.RoundID.Equals(RoundID));
            ScenarioContext.Current.Set(betLogs);

            var viewModel = ScenarioContext.Current.Get<GamePlayViewModel>();
            const int EmptyActiveGameRound = 0;
            Assert.IsTrue(viewModel.ActiveGameRoundTables.Count > EmptyActiveGameRound, "Get active game rounds");

            viewModel.GetListBetLog();
            ScenarioContext.Current.Get<TestScheduler>().Run();
        }

        [Then(@"Dispaly bet log int game roundID=(.*) are")]
        public void ThenDispalyBetLogAre(int roundID, Table table)
        {
            var expect = (from c in table.Rows
                          select new BetLog
                          {
                              BetDateTime = DateTime.Parse(c["BetDateTime"]),
                              BetOrder = int.Parse(c["BetOrder"])
                          }).ToArray<BetLog>();

            var viewModel = ScenarioContext.Current.Get<GamePlayViewModel>()
                .ActiveGameRoundTables.FirstOrDefault(c => c.RoundID.Equals(roundID));

            if (viewModel != null)
            {
                var actual = viewModel.BetLogs.ToArray<BetLog>();
                Assert.AreEqual(expect.Count(), actual.Count(), "Count");
                for (int elementIndex = 0; elementIndex < actual.Count(); elementIndex++)
                {
                    Assert.AreEqual(expect[elementIndex].BetDateTime, actual[elementIndex].BetDateTime, "BetDateTime");
                    Assert.AreEqual(expect[elementIndex].BetOrder, actual[elementIndex].BetOrder, "BetOrder");
                }
            }
        }
    }
}