using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using TechTalk.SpecFlow;
using Rhino.Mocks;
using TheS.Casinova.ColorsSvc;
using SpecFlowAssist;
using System.Collections.Generic;
using TheS.Casinova.Colors.ViewModels;
using System.Threading;
using TheS.Casinova.Colors.Services;
using System.Concurrency;
using System.Linq;
using System.Collections.ObjectModel;
using PerfEx.Infrastructure.LotUpdate;

namespace TheS.Casinova.Colors.Specs.Steps
{
    [Binding]
    public class CommonSteps
    {
        [Given(@"Create and initialize GamePlayViewModel and Colors game service")]
        public void GivenCreateAndInitializeGamePlayViewModelAndColorsGameService()
        {
            var mocks = ScenarioContext.Current.Get<MockRepository>();

            var svc = mocks.Stub<IColorsServiceAdapter>();
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
