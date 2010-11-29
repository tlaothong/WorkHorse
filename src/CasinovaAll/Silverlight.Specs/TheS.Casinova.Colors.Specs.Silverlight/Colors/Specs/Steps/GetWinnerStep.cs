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
        private int _generateTrackingCount;

        [Given(@"Setup web service trackingID are")]
        public void GivenSetupWebServiceTrackingIDAre(Table table)
        {
            var trackings = (from c in table.Rows
                             select new PayForColorsWinnerInfoCommand { OnGoingTrackingID = Guid.Parse(c["TrackingID"]) })
                            .ToArray<PayForColorsWinnerInfoCommand>();

            var svc = ScenarioContext.Current.Get<IColorsServiceAdapter>();
            var tracker = ScenarioContext.Current.Get<IStatusTracker>();
            var subject = ScenarioContext.Current.Get<Subject<TrackingInformation>>();

            Func<PayForColorsWinnerInfoCommand, IObservable<PayForColorsWinnerInfoCommand>> func = cmd =>
            {
                return Observable.Return(new PayForColorsWinnerInfoCommand
                {
                    OnGoingTrackingID = trackings[_generateTrackingCount++].OnGoingTrackingID
                });
            };

            SetupResult.For(tracker.Watch(null)).IgnoreArguments().Return(subject);
            SetupResult.For(svc.GetWinnerInformation(null)).IgnoreArguments().Do(func);
        }

        [When(@"Click get winner in game round (.*)")]
        public void WhenClickGetWinnerInGameRound20(int gameRound)
        {
            var viewModel = ScenarioContext.Current.Get<GamePlayViewModel>();

            viewModel.SelectedGameRoundID = gameRound;
            viewModel.GetWinnerInformation();
            ScenarioContext.Current.Get<TestScheduler>().Run();
        }

        [Then(@"PayLog has save RoundID='(.*)', Count='(.*)'")]
        public void ThenPayLogHasSaveRoundID20(int gameRound, int count)
        {
            var payLog = ScenarioContext.Current.Get<GamePlayViewModel>().Paylogs.Where(c => c.RoundID.Equals(gameRound));
            Assert.AreEqual(count, payLog.Count(), "Paylog count");
        }

        [Then(@"Lot of TrackingIDs has Retrieved are")]
        public void ThenLotOfTrackingIDsHasRetrievedAre(Table table)
        {
            var trackingsRetrieved = (from c in table.Rows
                             select new PayForColorsWinnerInfoCommand
                             {
                                 OnGoingTrackingID = Guid.Parse(c["TrackingID"])
                             }).ToArray<PayForColorsWinnerInfoCommand>();

            var subject = ScenarioContext.Current.Get<Subject<TrackingInformation>>();

            foreach (var tracking in trackingsRetrieved)
            {
                subject.OnNext(new TrackingInformation
                {
                    LotNo = "123",
                    TrackingID = tracking.OnGoingTrackingID,
                    Status = "ok",
                });
            }
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
