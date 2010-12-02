using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Rhino.Mocks;
using TheS.Casinova.MagicNine.Services;
using PerfEx.Infrastructure.LotUpdate;
using System.Concurrency;
using TheS.Casinova.MagicNine.ViewModels;
using SpecFlowAssist;

namespace TheS.Casinova.MagicNine.Specs.Steps
{
    [Binding]
    public class CommonSteps
    {
        [Given(@"Create and initialize GamePlayViewModel and MagicNine game service")]
        public void GivenCreateAndInitializeGamePlayViewModelAndColorsGameService()
        {
            var mocks = ScenarioContext.Current.Get<MockRepository>();
            var svc = mocks.Stub<IMagicNineServiceAdapter>();
            var statusTracker = mocks.Stub<IStatusTracker>();
            var scheduler = new TestScheduler();
            var viewModel = new GamePlayViewModel
            {
                Scheduler = scheduler,
                GameService = svc,
                StatusTracker = statusTracker
            };
            var subject = new Subject<TrackingInformation>();

            ScenarioContext.Current.Set(viewModel);
            ScenarioContext.Current.Set(scheduler);
            ScenarioContext.Current.Set(mocks);
            ScenarioContext.Current.Set(svc);
            ScenarioContext.Current.Set(statusTracker);
            ScenarioContext.Current.Set(subject);
        }
    }
}
