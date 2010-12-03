using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using SpecFlowAssist;
using TheS.Casinova.MagicNine.ViewModels;
using System.Concurrency;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheS.Casinova.MagicNineSvc;
using TheS.Casinova.MagicNine.Services;
using Rhino.Mocks;
using PerfEx.Infrastructure.LotUpdate;

namespace TheS.Casinova.MagicNine.Specs.Steps
{
    [Binding]
    public class AutoBetStartStep
    {
        private int _generateTrackingCount;

        #region Background
        
        [Given(@"Setup web service trackingID for AutoBet are")]
        public void GivenSetupWebServiceTrackingIDForAutoBetAre(Table table)
        {
            var trackingIDs = (from c in table.Rows select new StartAutoBetCommand { StartTrackingID = Guid.Parse(c["TrackingID"]) })
                .ToArray<StartAutoBetCommand>();


            var svc = ScenarioContext.Current.Get<IMagicNineServiceAdapter>();
            Func<StartAutoBetCommand, IObservable<StartAutoBetCommand>> func = cmd =>
            {
                return Observable.Return(new StartAutoBetCommand
                {
                    StartTrackingID = trackingIDs[_generateTrackingCount++].StartTrackingID
                });
            };

            SetupResult.For(svc.AutoBetOn(null)).IgnoreArguments().Do(func);

            var tracker = ScenarioContext.Current.Get<IStatusTracker>();
            var subject = ScenarioContext.Current.Get<Subject<TrackingInformation>>();
            SetupResult.For(tracker.Watch(null)).IgnoreArguments().Return(subject);
        }

        #endregion Background

        [When(@"I press AutoBetStart button in game roundID=(.*), Amount=(.*)")]
        public void WhenIPressAutoBetStartButtonInGameRoundID1Amount1(int roundID,int amount)
        {
            var viewModel = ScenarioContext.Current.Get<GamePlayViewModel>();
            const int EmptyActiveGameRound = 0;
            Assert.IsTrue(viewModel.ActiveGameRoundTables.Count > EmptyActiveGameRound, "Active game round is created");

            viewModel.SelectedGameRoundID = roundID;
            viewModel.ActiveGameRoundTables.First(c => c.RoundID.Equals(roundID)).Amount = amount;
            viewModel.AutoBetStart();
            ScenarioContext.Current.Get<TestScheduler>().Run();
        }

        [Then(@"Auto bet has been turned off in active game roundID=(.*) and amount=(.*)")]
        public void ThenAutoBetHasBeenTurnOffInActiveGameRoundID1(int roundID,int amount)
        {
            var activegameRound = ScenarioContext.Current.Get<GamePlayViewModel>().ActiveGameRoundTables.First(c => c.RoundID.Equals(roundID));

            Assert.AreEqual(amount, activegameRound.Amount, "Amount");
            Assert.IsFalse(activegameRound.IsAutoBetOn, "Auto bet has been turn off");
        }

        [Then(@"Auto bet has been turned on in active game roundID=(.*) and amount=(.*)")]
        public void ThenAutoBetHasBeenTurnOnInActiveGameRoundID1(int roundID, int amount)
        {
            var activegameRound = ScenarioContext.Current.Get<GamePlayViewModel>().ActiveGameRoundTables.First(c => c.RoundID.Equals(roundID));

            Assert.AreEqual(amount, activegameRound.Amount, "Amount");
            Assert.IsTrue(activegameRound.IsAutoBetOn, "Auto bet has been turn on");
        }
    }
}
