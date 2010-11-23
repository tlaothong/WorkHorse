using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Rhino.Mocks;
using TheS.Casinova.Colors.Services;
using TheS.Casinova.ColorsSvc;
using SpecFlowAssist;
using TheS.Casinova.Colors.ViewModels;
using System.Concurrency;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheS.Casinova.Colors.Models;
using PerfEx.Infrastructure.LotUpdate;

namespace TheS.Casinova.Colors.Specs.Steps
{
    [Binding]
    public class BetStep
    {
        #region Background

        [Given(@"Setup trackingID for bet (.*)")]
        public void GivenSetupTrackingID(string trackingID)
        {
            var mocks = ScenarioContext.Current.Get<MockRepository>();
            var svc = ScenarioContext.Current.Get<IColorsServiceAdapter>();
            var statusTracker = ScenarioContext.Current.Get<IStatusTracker>();
            var subject = ScenarioContext.Current.Get<Subject<TrackingInformation>>();

            Func<BetCommand, IObservable<BetCommand>> _mockBet = cmd =>
            {
                var result = new BetCommand
                {
                    Amount = cmd.Amount,
                    Color = cmd.Color,
                    RoundID = cmd.RoundID,
                    TrackingID = Guid.Parse(trackingID),
                    UserName = cmd.UserName,
                };
                return Observable.Return(result);
            };

            using (mocks.Record())
            {
                SetupResult.For(svc.Bet(null)).IgnoreArguments().Do(_mockBet);
                SetupResult.For(statusTracker.Watch(null)).IgnoreArguments().Return(subject);
            }
        }

        #endregion Background

        [When(@"Click Bet black amount=(.*) in game round=(.*)")]
        public void WhenClickBetBlackAmount(int amount,int gameRound)
        {
            var viewModel = ScenarioContext.Current.Get<GamePlayViewModel>();
            viewModel.RoundID = gameRound;
            viewModel.BetAmount = amount;
            viewModel.BetBlack();
            ScenarioContext.Current.Get<TestScheduler>().Run();
        }

        [When(@"Click Bet white amount=(.*) in game round=(.*)")]
        public void WhenClickBetWhiteAmount(int amount, int gameRound)
        {
            var viewModel = ScenarioContext.Current.Get<GamePlayViewModel>();
            viewModel.RoundID = gameRound;
            viewModel.BetAmount = amount;
            viewModel.BetWhite();
            ScenarioContext.Current.Get<TestScheduler>().Run();
        }

        [Then(@"PayLog count='(.*)' are")]
        public void ThenPayLogAre(int payLogCount)
        {
            var viewModel = ScenarioContext.Current.Get<GamePlayViewModel>();
            Assert.AreEqual(payLogCount, viewModel.Paylogs.Count, "Pay log count");
        }

        [Then(@"Lot of TrackingID='(.*)' Is Retrieved")]
        public void ThenLotOfTrackingID(string trackingID)
        {
             var subject = ScenarioContext.Current.Get<Subject<TrackingInformation>>();
             subject.OnNext(new TrackingInformation
             {
                 TrackingID = Guid.Parse(trackingID)
             });
        }

        [Then(@"Paylog have save information are")]
        public void ThenPaylogHaveSaveInformationAre(Table table)
        {
            var payLog = ScenarioContext.Current.Get<GamePlayViewModel>().Paylogs;
            var actual = payLog.ToArray<PayLog>();
            var expect = (from c in table.Rows
                          select new PayLog
                          {
                              Amount = int.Parse(c["Amount"]),
                              Colors = c["Colors"],
                              RoundID = int.Parse(c["RoundID"]),
                          }).ToArray<PayLog>();

            for (int index = 0; index < payLog.Count; index++)
            {
                Assert.AreEqual(expect[index].RoundID, actual[index].RoundID, "RoundID");
                Assert.AreEqual(expect[index].Colors, actual[index].Colors, "Colors");
                Assert.AreEqual(expect[index].Amount, actual[index].Amount, "Amount");
            }
        }
    }
}
