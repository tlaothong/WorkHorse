using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using SpecFlowAssist;
using Rhino.Mocks;
using TheS.Casinova.MagicNineSvc;
using TheS.Casinova.MagicNine.Services;
using PerfEx.Infrastructure.LotUpdate;
using TheS.Casinova.MagicNine.ViewModels;
using System.Concurrency;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TheS.Casinova.MagicNine.Specs.Steps
{
    [Binding]
    public class AutoBetStopStep
    {
        private int _generateTrackingCount;

        #region Background
        
        [Given(@"Setup web service trackingID for auto bet stop are")]
        public void GivenSetupWebServiceTrackingIDForAutoBetStopAre(Table table)
        {
            var trackingIDs = (from c in table.Rows select new StopAutoBetCommand { StopTrackingID = Guid.Parse(c["TrackingID"]) })
                .ToArray<StopAutoBetCommand>();
            ScenarioContext.Current.Set(trackingIDs);

            var svc = ScenarioContext.Current.Get<IMagicNineServiceAdapter>();
            var tracker = ScenarioContext.Current.Get<IStatusTracker>();
            var subject = ScenarioContext.Current.Get<Subject<TrackingInformation>>();

            Func<StopAutoBetCommand, IObservable<StopAutoBetCommand>> func = cmd =>
            {
                return Observable.Return(new StopAutoBetCommand
                {
                    StopTrackingID = trackingIDs[_generateTrackingCount++].StopTrackingID
                });
            };

            SetupResult.For(tracker.Watch(null)).IgnoreArguments().Return(subject);
            SetupResult.For(svc.AutoBetOff(null)).IgnoreArguments().Do(func);

        }

        #endregion Background

        [Given(@"Setup autobet game play viewmodel are")]
        public void GivenSetupAmount20InGameRoundID20(Table table)
        {
            var viewModel = ScenarioContext.Current.Get<GamePlayViewModel>();
            const int ActiveGameRoundEmpty = 0;
            Assert.IsTrue(viewModel.ActiveGameRoundTables.Count != ActiveGameRoundEmpty, "Active game rounds has created");

            foreach (var tb in table.Rows)
            {
                int roundID = int.Parse(tb["RoundID"]);
                int amount = int.Parse(tb["Amount"]);
                viewModel.ActiveGameRoundTables.First(c => c.RoundID.Equals(roundID)).Amount = amount;
            }
        }

        [When(@"I press AutoBetStop\(\) in game roundID=(.*)")]
        public void WhenIPressAutoBetStopInGameRoundID20(int roundID)
        {
            var viewModel = ScenarioContext.Current.Get<GamePlayViewModel>();

            viewModel.SelectedGameRoundID = roundID;
            viewModel.AutoBetStop();
            ScenarioContext.Current.Get<TestScheduler>().Run();
        }
    }
}

