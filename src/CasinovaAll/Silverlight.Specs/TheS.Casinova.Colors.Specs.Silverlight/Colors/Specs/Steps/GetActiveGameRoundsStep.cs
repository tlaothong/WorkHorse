using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TheS.Casinova.ColorsSvc;
using SpecFlowAssist;
using TheS.Casinova.Colors.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheS.Casinova.Colors.Models;
using System.Threading;
using System.Concurrency;
using Rhino.Mocks;
using TheS.Casinova.Colors.Services;

namespace TheS.Casinova.Colors.Specs.Steps
{
    [Binding]
    public class GetActiveGameRoundsStep
    {
        [Given(@"Back service have active game rounds are:")]
        public void GivenBackServiceHaveActiveGameRoundsAre(Table table)
        {
            var mocks = ScenarioContext.Current.Get<MockRepository>();
            var svc = ScenarioContext.Current.Get<IColorsServiceAdapter>();

            Func<IObservable<ListActiveGameRoundCommand>> _mockGetListActiveGameRounds = () =>
            {
                return Observable.Return(new ListActiveGameRoundCommand
                {
                    ActiveRounds = ScenarioContext.Current.Get<IEnumerable<GameRoundInformation>>().ToArray()
                });
            };

            using (mocks.Record())
            {
                SetupResult.For(svc.GetListActiveGameRound()).Do(_mockGetListActiveGameRounds);
            }

            ScenarioContext.Current.Set<IEnumerable<GameRoundInformation>>(table.CreateSet<GameRoundInformation>());
        } 

        [When(@"Send request GetListActiveGameRounds\(\) to web server")]
        public void WhenSendRequestGetListActiveGameRoundsToWebServer()
        {
            var viewModel = ScenarioContext.Current.Get<GamePlayViewModel>();
            viewModel.GetListActiveGameRounds();
            ScenarioContext.Current.Get<TestScheduler>().Run();
        }

        [Then(@"Tables in GamePlayViewModel has create from ListActivegameRounds")]
        public void ThenServerRespondListActiveGameRoundAre(Table table)
        {
            var actual = ScenarioContext.Current.Get<GamePlayViewModel>().Tables;
            var expected = table.CreateSet<GameTable>().ToArray<GameTable>();

            for (int index = 0; index < actual.Count; index++)
            {
                Assert.AreEqual(expected[index].Name, actual[index].Name, "Name");
                Assert.AreEqual(expected[index].Round, actual[index].Round, "Round");
                Assert.AreEqual(expected[index].StartTime, actual[index].StartTime, "StartTime");
                Assert.AreEqual(expected[index].EndTime, actual[index].EndTime, "EndTime");
            }

            Assert.IsTrue(actual.Count > 0, "Tables should have rows");
            Assert.IsNotNull(actual, "Tables not null");
        }

        [Then(@"Tables in GamePlayViewModel don't create ListActivegameRounds")]
        public void ThenTablesInGamePlayViewModelDonTCreateListActivegameRounds(Table table)
        {
            var actual = ScenarioContext.Current.Get<GamePlayViewModel>().Tables;
            var expected = table.CreateSet<GameTable>();

            CollectionAssert.AreEqual(expected.ToArray(), actual.ToArray());
            Assert.IsTrue(actual.Count <= 0, "Tables not have rows");
            Assert.IsNotNull(actual,"Tables not null");
        }
    }
}
