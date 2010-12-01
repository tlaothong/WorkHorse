using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using SpecFlowAssist;
using TheS.Casinova.MagicNineSvc;
using Rhino.Mocks;
using TheS.Casinova.MagicNine.Services;
using TheS.Casinova.MagicNine.ViewModels;
using System.Concurrency;
using PerfEx.Infrastructure.LotUpdate;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TheS.Casinova.MagicNine.Specs.Steps
{
    [Binding]
    public class BetStep
    {
        private int _generateTrackingCount;

        #region Background

        [Given(@"Setup web service trackingID for Bet are")]
        public void GivenSetupWebServiceTrackingIDAre(Table table)
        {
            var trackingIDs = (from c in table.Rows
                             select new SingleBetCommand
                             {
                                 TrackingID = Guid.Parse(c["TrackingID"])
                             }).ToArray<SingleBetCommand>();
            ScenarioContext.Current.Set(trackingIDs);

            var svc = ScenarioContext.Current.Get<IMagicNineServiceAdapter>();
            var tracker = ScenarioContext.Current.Get<IStatusTracker>();
            var subject = ScenarioContext.Current.Get<Subject<TrackingInformation>>();

            Func<SingleBetCommand, IObservable<SingleBetCommand>> func = cmd =>
            {
                return Observable.Return(new SingleBetCommand
                {
                    TrackingID = trackingIDs[_generateTrackingCount++].TrackingID
                });
            };

            SetupResult.For(tracker.Watch(null)).IgnoreArguments().Return(subject);
            SetupResult.For(svc.BetSingle(null)).IgnoreArguments().Do(func);
        }

        #endregion Background

        [When(@"I press bet in game round=(.*)")]
        public void WhenIPressBetInGameRound1(int roundID)
        {
            var viewModel = ScenarioContext.Current.Get<GamePlayViewModel>();
            viewModel.SelectedGameRoundID = roundID;
            viewModel.Bet();
            ScenarioContext.Current.Get<TestScheduler>().Run();
        }

        [Then(@"PayLog has save RoundID='(.*)', Count='(.*)'")]
        public void ThenPayLogHasSaveRoundID1Count1(int roundID,int count)
        {
            var viewModel = ScenarioContext.Current.Get<GamePlayViewModel>();
            var actual = viewModel.PayLogs.Where(c => c.RoundID.Equals(roundID)).Count();

            Assert.AreEqual(count, actual, "PayLog Count");
        }

        [Then(@"Lot of TrackingIDs has Retrieved are")]
        public void ThenLotOfTrackingIDsHasRetrievedAre(Table table)
        {
            var trackingsRetrieved = (from c in table.Rows
                                      select new SingleBetCommand
                                      {
                                          TrackingID = Guid.Parse(c["TrackingID"])
                                      }).ToArray<SingleBetCommand>();

            var subject = ScenarioContext.Current.Get<Subject<TrackingInformation>>();

            foreach (var tracking in trackingsRetrieved)
            {
                subject.OnNext(new TrackingInformation
                {
                    LotNo = "123",
                    TrackingID = tracking.TrackingID,
                    Status = "ok",
                });
            }
        }

        [Then(@"PayLog has empty")]
        public void ThenPayLogHasEmpty()
        {
            var actual = ScenarioContext.Current.Get<GamePlayViewModel>().PayLogs.Count();

            const int EmptyPayLogs = 0;
            Assert.IsTrue(actual.Equals(EmptyPayLogs),"Pay log is empty");

        }
    }
}
