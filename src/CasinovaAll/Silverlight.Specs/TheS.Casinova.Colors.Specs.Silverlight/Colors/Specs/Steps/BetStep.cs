﻿using System;
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
        private int _generateTrackingCount;

        #region Given

        [Given(@"Setup trackingID for bet (.*)")]
        public void GivenSetupTrackingID(string trackingID)
        {
            var mocks = ScenarioContext.Current.Get<MockRepository>();
            var svc = ScenarioContext.Current.Get<IColorsServiceAdapter>();
            var statusTracker = ScenarioContext.Current.Get<IStatusTracker>();
            var subject = ScenarioContext.Current.Get<Subject<TrackingInformation>>();

            Func<BetCommand, IObservable<BetCommand>> func = cmd =>
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

            SetupResult.For(svc.Bet(null)).IgnoreArguments().Do(func);
            SetupResult.For(statusTracker.Watch(null)).IgnoreArguments().Return(subject);
        }

        [Given(@"Setup web service trackingID for bets")]
        public void GivenSetupWebServiceTrackingIDForBets(Table table)
        {
            var trackings = (from c in table.Rows
                            select new BetCommand
                            {
                                TrackingID = Guid.Parse(c["TrackingID"])
                            }).ToArray<BetCommand>();

            var mocks = ScenarioContext.Current.Get<MockRepository>();
            var svc = ScenarioContext.Current.Get<IColorsServiceAdapter>();
            var statusTracker = ScenarioContext.Current.Get<IStatusTracker>();
            var subject = ScenarioContext.Current.Get<Subject<TrackingInformation>>();

            Func<BetCommand, IObservable<BetCommand>> func = cmd =>
            {
                var result = new BetCommand
                {
                    Amount = cmd.Amount,
                    Color = cmd.Color,
                    RoundID = cmd.RoundID,
                    TrackingID = trackings[_generateTrackingCount++].TrackingID,
                    UserName = cmd.UserName,
                };
                return Observable.Return(result);
            };

            SetupResult.For(svc.Bet(null)).IgnoreArguments().Do(func);
            SetupResult.For(statusTracker.Watch(null)).IgnoreArguments().Return(subject);
        }

        #endregion Given

        #region When

        [When(@"Click Bet black amount=(.*) in game round=(.*)")]
        public void WhenClickBetBlackAmount(int amount, int gameRound)
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

        #endregion When

        #region Then

        [Then(@"PayLog count='(.*)' are")]
        public void ThenPayLogAre(int payLogCount)
        {
            var viewModel = ScenarioContext.Current.Get<GamePlayViewModel>();
            Assert.AreEqual(payLogCount, viewModel.Paylogs.Count, "Pay log count");
        }

        [Then(@"Bet Lot has Retrieved are")]
        public void ThenBetLotHasRetrievedAre(Table table)
        {
            var trackingsRetrieved = (from c in table.Rows
                             select new BetCommand
                             {
                                 TrackingID = Guid.Parse(c["TrackingID"])
                             }).ToArray<BetCommand>();

            var subject = ScenarioContext.Current.Get<Subject<TrackingInformation>>();
            foreach (var tracking in trackingsRetrieved)
            {
                subject.OnNext(new TrackingInformation
                {
                    LotNo = "789",
                    TrackingID = tracking.TrackingID,
                    Status = "ok",
                });
            }
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

        #endregion Then
    }
}
