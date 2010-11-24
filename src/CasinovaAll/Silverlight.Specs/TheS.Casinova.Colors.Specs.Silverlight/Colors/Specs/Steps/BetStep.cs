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

namespace TheS.Casinova.Colors.Specs.Steps
{
    [Binding]
    public class BetStep
    {
        #region Background

        [Given(@"Initialize mock for bet")]
        public void GivenInitializeMockForBet()
        {
            var mocks = ScenarioContext.Current.Get<MockRepository>();
            var svc = ScenarioContext.Current.Get<IColorsServiceAdapter>();

            Func<BetCommand, IObservable<BetCommand>> _mockBet = cmd =>
            {
                var result = new BetCommand
                {
                    Amount = cmd.Amount,
                    Color = cmd.Color,
                    RoundID = cmd.RoundID,
                    TrackingID = Guid.NewGuid(),
                    UserName = cmd.UserName
                };
                return Observable.Return(result);
            };

            using (mocks.Record())
            {
                SetupResult.For(svc.Bet(null)).IgnoreArguments().Do(_mockBet);
            }
        }

        #endregion Background

        [When(@"Click Bet black amount=(.*) in game round=(.*)")]
        public void WhenClickBetBlackAmount30InGameRound15(int amount,int gameRound)
        {
            var viewModel = ScenarioContext.Current.Get<GamePlayViewModel>();
            viewModel.RoundID = gameRound;
            viewModel.BetAmount = amount;
            viewModel.BetBlack();
            ScenarioContext.Current.Get<TestScheduler>().Run();
        }

        [When(@"Click Bet white amount=(.*) in game round=(.*)")]
        public void WhenClickBetWhiteAmount30InGameRound15(int amount, int gameRound)
        {
            var viewModel = ScenarioContext.Current.Get<GamePlayViewModel>();
            viewModel.RoundID = gameRound;
            viewModel.BetAmount = amount;
            viewModel.BetWhite();
            ScenarioContext.Current.Get<TestScheduler>().Run();
        }

        [Then(@"PayLog count='(.*)' are")]
        public void ThenPayLogAre(int payLogCount,Table table)
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

            Assert.AreEqual(payLogCount, payLog.Count, "Pay log count");
            for (int index = 0; index < payLog.Count; index++)
            {
                Assert.AreEqual(expect[index].RoundID, actual[index].RoundID, "RoundID");
                Assert.AreEqual(expect[index].Colors, actual[index].Colors, "Colors");
                Assert.AreEqual(expect[index].Amount, actual[index].Amount, "Amount");
            }
        }
    }
}
