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
            MockRepository mocks = new MockRepository();
            IColorsServiceAdapter svc = mocks.Stub<IColorsServiceAdapter>();
            IStatusTracker tracker = mocks.Stub<IStatusTracker>();
            TestScheduler scheduler = new TestScheduler();
            GamePlayViewModel viewModel = new GamePlayViewModel
            {
                Scheduler = scheduler,
                GameService = svc
            };

            ScenarioContext.Current.Set<GamePlayViewModel>(viewModel);
            ScenarioContext.Current.Set<TestScheduler>(scheduler);
            ScenarioContext.Current.Set<MockRepository>(mocks);
            ScenarioContext.Current.Set<IColorsServiceAdapter>(svc);
            ScenarioContext.Current.Set<IStatusTracker>(tracker);
        }
    }
}
