using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using SpecFlowAssist;
using Rhino.Mocks;
using TheS.Casinova.MagicNine.Services;
using TheS.Casinova.MagicNineSvc;
using System.Concurrency;
using TheS.Casinova.MagicNine.ViewModels;
using TheS.Casinova.MagicNine.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TheS.Casinova.MagicNine.Specs.Steps
{
    [Binding]
    public class GetActiveGameRoundStep
    {
        #region Background

        [Given(@"Back service have active game rounds are:")]
        public void GivenBackServiceHaveActiveGameRoundsAre(Table table)
        {
            var mocks = ScenarioContext.Current.Get<MockRepository>();
            var svc = ScenarioContext.Current.Get<IMagicNineServiceAdapter>();
            ScenarioContext.Current.Set<IEnumerable<GameRoundInformation>>(table.CreateSet<GameRoundInformation>());

            Func<IObservable<ListActiveGameRoundInfoCommand>> fun = () =>
            {
                return Observable.Return(new ListActiveGameRoundInfoCommand
                {
                    GameRoundInfos = new System.Collections.ObjectModel.ObservableCollection<GameRoundInformation>
                        (ScenarioContext.Current.Get<IEnumerable<GameRoundInformation>>())
                });
            };

            using (mocks.Record())
            {
                SetupResult.For(svc.GetListActiveGameRound()).Do(fun);
            }
        }

        #endregion Background
        
        [When(@"Send request GetListActiveGameRounds\(\) to web server")]
        public void WhenSendRequestGetListActiveGameRoundsToWebServer()
        {
            var viewModel = ScenarioContext.Current.Get<GamePlayViewModel>();
            viewModel.GetListActiveGameRoundInformation();
            ScenarioContext.Current.Get<TestScheduler>().Run();
        }

        [Then(@"Tables in GamePlayViewModel has create from ListActivegameRounds")]
        public void ThenTablesInGamePlayViewModelHasCreateFromListActivegameRounds(Table table)
        {
            var actual = ScenarioContext.Current.Get<GamePlayViewModel>().Tables;
            var expect = table.CreateSet<GameTable>().ToArray<GameTable>();

            for (int elementIndex = 0; elementIndex < actual.Count; elementIndex++)
            {
                Assert.AreEqual(expect[elementIndex].Round, actual[elementIndex].Round, "Roud");
                Assert.AreEqual(expect[elementIndex].Name, actual[elementIndex].Name, "Name");
            }
        }
    }
}
