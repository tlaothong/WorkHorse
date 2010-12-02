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
        [Given(@"Back service have active game rounds are:")]
        public void GivenBackServiceHaveActiveGameRoundsAre(Table table)
        {
            var activeGameRound = from c in table.Rows
                                  select new GameRoundInformation
                                  {
                                      RoundID = int.Parse(c["RoundID"]),
                                      WinnerPoint = int.Parse(c["WinnerPoint"])
                                  };
            ScenarioContext.Current.Set(activeGameRound);

            var svc = ScenarioContext.Current.Get<IMagicNineServiceAdapter>();
            Func<IObservable<ListActiveGameRoundInfoCommand>> fun = () =>
            {
                return Observable.Return(new ListActiveGameRoundInfoCommand
                {
                    GameRoundInfos = new System.Collections.ObjectModel.ObservableCollection<GameRoundInformation>
                        (ScenarioContext.Current.Get<IEnumerable<GameRoundInformation>>())
                });
            };

            SetupResult.For(svc.GetListActiveGameRound()).Do(fun);
        }
        
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
            var actual = ScenarioContext.Current.Get<GamePlayViewModel>().ActiveGameRoundTables;
            var expect = (from c in table.Rows
                          select new GamePlayUIViewModel
                          {
                              RoundID = int.Parse(c["RoundID"]),
                              WinnerPoint = int.Parse(c["WinnerPoint"])
                          }).ToArray<GamePlayUIViewModel>();

            Assert.AreEqual(expect.Count(), actual.Count, "Count");

            for (int elementIndex = 0; elementIndex < actual.Count; elementIndex++)
            {
                Assert.AreEqual(expect[elementIndex].RoundID, actual[elementIndex].RoundID, "RoundID");
                Assert.AreEqual(expect[elementIndex].WinnerPoint, actual[elementIndex].WinnerPoint, "WinnerPoint");
            }
        }
    }
}
