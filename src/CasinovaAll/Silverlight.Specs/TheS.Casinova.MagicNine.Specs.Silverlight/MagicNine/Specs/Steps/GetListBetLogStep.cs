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
            var mocks = ScenarioContext.Current.Get<MockRepository>();
            var svc = ScenarioContext.Current.Get<IMagicNineServiceAdapter>();

            ScenarioContext.Current.Set<IEnumerable<BetInformation>>(table.CreateSet<BetInformation>());

            Func<ListBetLogCommand, IObservable<ListBetLogCommand>> func = cmd =>
            {
                return Observable.Return(new ListBetLogCommand
                {
                    BetInformations = new System.Collections.ObjectModel.ObservableCollection<BetInformation>
                    (ScenarioContext.Current.Get<IEnumerable<BetInformation>>())
                });
            };

            using (mocks.Record())
            {
                SetupResult.For(svc.GetListBetLog(null)).IgnoreArguments().Do(func);
            }

        }

        #endregion Background

        [When(@"Send request GetListBetlog\( '(.*)' \) RoundID='(.*)'")]
        public void WhenSendRequestGetListBetlogSakulRoundID999(string username,int RoundID)
        {
            var query = from c in ScenarioContext.Current.Get<IEnumerable<BetInformation>>().ToArray<BetInformation>()
                        where c.RoundID.Equals(RoundID) && c.UserName.Equals(username)
                        select c;
            ScenarioContext.Current.Set<IEnumerable<BetInformation>>(query);

            var viewModel = ScenarioContext.Current.Get<GamePlayViewModel>();
            viewModel.GetListBetLog();
            ScenarioContext.Current.Get<TestScheduler>().Run();
        }

        [Then(@"Dispaly bet log are")]
        public void ThenDispalyBetLogAre(Table table)
        {
            var expect = (from c in table.Rows
                         select new BetLog
                         {
                             Round = int.Parse(c["Round"]),
                             BetOrder = double.Parse(c["BetOrder"]),
                             BetDateTime = DateTime.Parse(c["BetDateTime"])
                         }).ToArray<BetLog>();
            var actual = ScenarioContext.Current.Get<GamePlayViewModel>().BetLogs.ToArray<BetLog>();

            Assert.AreEqual(expect.Count(), actual.Count(), "Element count");
            for (int elementIndex = 0; elementIndex < actual.Count(); elementIndex++)
            {
                Assert.AreEqual(expect[elementIndex].Round, actual[elementIndex].Round, "Round");
                Assert.AreEqual(expect[elementIndex].BetOrder, actual[elementIndex].BetOrder, "BetOrder");
                Assert.AreEqual(expect[elementIndex].BetDateTime, actual[elementIndex].BetDateTime, "BetDateTime");
            }
        }
    }
}
