using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using SpecFlowAssist;
using TheS.Casinova.Colors.ViewModels;
using System.Concurrency;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheS.Casinova.ColorsSvc;
using Rhino.Mocks;
using TheS.Casinova.Colors.Services;
using PerfEx.Infrastructure.LotUpdate;

namespace TheS.Casinova.Colors.Specs.Steps
{
    [Binding]
    public class GetWinnerStep
    {
        #region Background


        [Given(@"Setup trackingID for getwinner (.*)")]
        public void GivenSetupTrackingID(string trackingID)
        {
            var mocks = ScenarioContext.Current.Get<MockRepository>();
            var svc = ScenarioContext.Current.Get<IColorsServiceAdapter>();
            var statusTracker = ScenarioContext.Current.Get<IStatusTracker>();
            var subject = ScenarioContext.Current.Get<Subject<TrackingInformation>>();

            Func<PayForColorsWinnerInfoCommand, IObservable<PayForColorsWinnerInfoCommand>> _mockGetWinnerInformation = cmd =>
            {
                return Observable.Return(new PayForColorsWinnerInfoCommand
                {
                    RoundID = cmd.RoundID,
                    OnGoingTrackingID = Guid.NewGuid(),
                });
            };

            using (mocks.Record())
            {
                SetupResult.For(svc.GetWinnerInformation(null)).IgnoreArguments().Do(_mockGetWinnerInformation);
                SetupResult.For(statusTracker.Watch(null)).IgnoreArguments().Return(subject);
            }
        }

        #endregion Background

        [When(@"Click get winner in game round (.*)")]
        public void WhenClickGetWinnerInGameRound20(int gameRound)
        {
            var viewModel = ScenarioContext.Current.Get<GamePlayViewModel>();
            viewModel.RoundID = gameRound;
            viewModel.GetWinnerInformation();
            ScenarioContext.Current.Get<TestScheduler>().Run();
        }

        [Then(@"PayLog has save RoundID='(.*)', Count='(.*)'")]
        public void ThenPayLogHasSaveRoundID20(int gameRound,int count)
        {
            var actual = ScenarioContext.Current.Get<GamePlayViewModel>().Paylogs.Where(c => c.RoundID.Equals(gameRound));
            Assert.IsTrue(actual.Count() >= 1, "Pay log has save");
            Assert.AreEqual(count, actual.Count(), "Log count");
        }
    }
}
