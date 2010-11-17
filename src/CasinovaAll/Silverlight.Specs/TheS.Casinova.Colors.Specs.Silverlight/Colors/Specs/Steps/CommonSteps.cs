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

namespace TheS.Casinova.Colors.Specs.Steps
{
    [Binding]
    public class CommonSteps
    {
        [Given(@"Create and initialize GamePlayViewModel and Colors game service")]
        public void GivenCreateAndInitializeGamePlayViewModelAndColorsGameService()
        {
            MockRepository mocks = new MockRepository();
            IColorsService svc = mocks.Stub<IColorsService>();

            AutoResetEvent are = new AutoResetEvent(false);
            ScenarioContext.Current.Set<AutoResetEvent>(are);

            AsyncGetListActiveGameRound delGetListActiveGameRound = mockGetListActiveGameRound;

            Func<AsyncCallback, object, IAsyncResult> beginGet = (cb, ustate) =>
            {
                //throw new InvalidOperationException();
                return delGetListActiveGameRound.BeginInvoke(cb, ustate);
            };
            Func<IAsyncResult, ListActiveGameRoundCommand> endGet = (ar) =>
            {
                var ret = delGetListActiveGameRound.EndInvoke(ar);
                are.Set();
                return ret;
            };

            SetupResult.For(svc.BeginGetListActiveGameRound(null, null)).IgnoreArguments().Do(beginGet);
            SetupResult.For(svc.EndGetListActiveGameRound(null)).IgnoreArguments().Do(endGet);

            GamePlayPageViewModel viewModel = new GamePlayPageViewModel();
            viewModel.GameSvc = svc;
            ScenarioContext.Current.Set<GamePlayPageViewModel>(viewModel);
        }

        
        private static ListActiveGameRoundCommand mockGetListActiveGameRound()
        {
            return new ListActiveGameRoundCommand
            {
                ActiveRounds = new System.Collections.ObjectModel.ObservableCollection<GameRoundInformation>(
                    ScenarioContext.Current.Get<IEnumerable<GameRoundInformation>>()),
            };
        }

        public delegate ListActiveGameRoundCommand AsyncGetListActiveGameRound();
    }
}
