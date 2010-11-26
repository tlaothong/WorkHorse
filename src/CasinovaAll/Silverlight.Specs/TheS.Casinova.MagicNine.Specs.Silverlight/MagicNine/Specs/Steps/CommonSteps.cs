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
            MockRepository mocks = new MockRepository();
            IMagicNineServiceAdapter svc = mocks.Stub<IMagicNineServiceAdapter>();
            IStatusTracker statusTracker = mocks.Stub<IStatusTracker>();
            Subject<TrackingInformation> subject = new Subject<TrackingInformation>();
            TestScheduler scheduler = new TestScheduler();
            GamePlayViewModel viewModel = new GamePlayViewModel
            {
                Scheduler = scheduler,
                GameService = svc,
                StatusTracker = statusTracker
            };

            ScenarioContext.Current.Set<GamePlayViewModel>(viewModel);
            ScenarioContext.Current.Set<TestScheduler>(scheduler);
            ScenarioContext.Current.Set<MockRepository>(mocks);
            ScenarioContext.Current.Set<IMagicNineServiceAdapter>(svc);
            ScenarioContext.Current.Set<IStatusTracker>(statusTracker);
            ScenarioContext.Current.Set<Subject<TrackingInformation>>(subject);
        }
    }
}
