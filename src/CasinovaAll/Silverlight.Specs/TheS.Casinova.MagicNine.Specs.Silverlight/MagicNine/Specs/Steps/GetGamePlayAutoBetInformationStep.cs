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
        #region Background

        [Given(@"Web server have game play auto bet information are")]
        public void GivenWebServerHaveGamePlayAutoBetInformationAre(Table table)
        {
            var mocks = ScenarioContext.Current.Get<MockRepository>();
            var svc = ScenarioContext.Current.Get<IMagicNineServiceAdapter>();

            ScenarioContext.Current.Set<IEnumerable<GamePlayAutoBetInformation>>(table.CreateSet<GamePlayAutoBetInformation>());

            Func<ListGamePlayAutoBetInfoCommand,IObservable<ListGamePlayAutoBetInfoCommand>> func = cmd=>{
                return Observable.Return(new ListGamePlayAutoBetInfoCommand
                {
                    GamePlayAutoBet = new System.Collections.ObjectModel.ObservableCollection<GamePlayAutoBetInformation>
                    (ScenarioContext.Current.Get<IEnumerable<GamePlayAutoBetInformation>>())
                });
            };

            using (mocks.Record())
            {
                SetupResult.For(svc.GetListGamePlayAutoBetInformation(null)).IgnoreArguments().Do(func);
            }

        }

        [Given(@"Client have active game rounds are:")]
        public void GivenClientHaveActiveGameRoundsAre(Table table)
        {
            var viewModel = ScenarioContext.Current.Get<GamePlayViewModel>();
            foreach (var gt in table.CreateSet<GameRoundInformation>())
            {
                viewModel.Tables.Add(new GameTable
                {
                    Round = gt.RoundID,
                    Name = gt.WinnerPoint.ToString()
                });
            }
        }

        #endregion Background

        [When(@"Send request GetListGamePlayAutoBet\( '(.*)' \)")]
        public void WhenSendRequestGetListGamePlayInformationMary(string username)
        {
            var autoBetInformations = from c in ScenarioContext.Current.Get<IEnumerable<GamePlayAutoBetInformation>>().ToArray<GamePlayAutoBetInformation>()
                                      where c.UserName.Equals(username)
                                      select c;
            ScenarioContext.Current.Set<IEnumerable<GamePlayAutoBetInformation>>(autoBetInformations);

            var viewModel = ScenarioContext.Current.Get<GamePlayViewModel>();
            viewModel.GetLisGamePlayAutoBetInformation();
            ScenarioContext.Current.Get<TestScheduler>().Run();
        }

        [Then(@"Tables in GamePlayViewModel display game play information are")]
        public void ThenTablesInGamePlayViewModelDisplayGamePlayInformationAre(Table table)
        {
            var expect = (from c in table.Rows
                         select new GameTable
                         {
                             Round = int.Parse( c["Round"]),
                             Amount = double.Parse(c["Amount"]),
                             IsPlaying = bool.Parse(c["IsPlaying"])
                         }).ToArray<GameTable>();
            var actual = ScenarioContext.Current.Get<GamePlayViewModel>().Tables.ToArray<GameTable>();

            const int EmptyTable = 0;
            Assert.IsTrue(actual.Count() >= EmptyTable, "Table has create");
            Assert.AreEqual(expect.Count(), actual.Count(), "Element count");
            for (int elementIndex = 0; elementIndex < expect.Count(); elementIndex++)
            {
                Assert.AreEqual(expect[elementIndex].Round, actual[elementIndex].Round, "Round");
                Assert.AreEqual(expect[elementIndex].Amount, actual[elementIndex].Amount, "Amount: "+elementIndex);
                Assert.AreEqual(expect[elementIndex].IsPlaying, actual[elementIndex].IsPlaying, "IsPlaying");
            }
        }
    }
}
