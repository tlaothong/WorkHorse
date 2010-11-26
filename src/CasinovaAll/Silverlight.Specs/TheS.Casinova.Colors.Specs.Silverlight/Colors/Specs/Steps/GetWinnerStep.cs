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
            var tracker = ScenarioContext.Current.Get<IStatusTracker>();


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
                SetupResult.For(tracker.Watch(null)).IgnoreArguments().Return(ScenarioContext.Current.Get<Subject<TrackingInformation>>());
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
            var viewModel = ScenarioContext.Current.Get<GamePlayViewModel>().Paylogs.Where(c => c.RoundID.Equals(gameRound));
            Assert.IsTrue(viewModel.Count() >= 1, "Pay log has save");
            Assert.AreEqual(count, viewModel.Count(), "Log count");
        }

        [Then(@"Lot of TrackingID='(.*)' Is Retrieved")]
        public void ThenLotOfTrackingID(string trackingID)
        {
            var gid = Guid.Parse(trackingID);
            var subject = ScenarioContext.Current.Get<Subject<TrackingInformation>>();
            subject.OnNext(new TrackingInformation
            {
                LotNo = "789",
                TrackingID = gid,
                Status = "ok",
            });
        }

        [Then(@"PayLog has empty")]
        public void ThenPayLogHasDeleteEmpty()
        {
            var viewModel = ScenarioContext.Current.Get<GamePlayViewModel>();

            const int EmptyList = 0;
            Assert.AreEqual(EmptyList, viewModel.Paylogs.Count, "Paylog is empty");
        }
    }
}
