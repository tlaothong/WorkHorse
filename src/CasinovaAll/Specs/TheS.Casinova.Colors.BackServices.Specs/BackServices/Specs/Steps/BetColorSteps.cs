using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TheS.Casinova.TwoWins.Models;
using TheS.Casinova.TwoWins.Commands;
using Rhino.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheS.Casinova.PlayerProfile.Models;

namespace TheS.Casinova.TwoWins.BackServices.Specs
{
    [Binding]
    public class BetColorSteps
        : ColorsGameStepsBase
    {
        public UserProfile _expectPlayerInfo;

        public IEnumerable<UserProfile> _playerInfos;


        [Given(@"\(BetColor\)server has player profile information as:")]
        public void GivenBetColorServerHasPlayerProfileInformationAs(Table table)
        {
            _playerInfos = (from item in table.Rows
                            select new UserProfile {
                                UserName = item["UserName"],
                                NonRefundable = Convert.ToDouble(item["NonRefundable"]),
                                Refundable = Convert.ToDouble(item["Refundable"]),
                            });
        }

        [Given(@"sent name: (.*) the player's balance should recieved, for bet color")]
        public void GivenSentNameXThePlayerSBalanceShouldRecievedForBetColor(string userName)
        {
            _expectPlayerInfo = (from item in _playerInfos
                                     where item.UserName == userName
                                     select item).FirstOrDefault();

            SetupResult.For(Dqr_GetPlayerInfo.Get(new GetPlayerInfoCommand()))
                .IgnoreArguments().Return(_expectPlayerInfo);
        }

        [Given(@"the player's balance should be update correct, Amount: (.*)")]
        public void GivenThePlayerSBalanceShouldBeUpdateCorrectAmountX(double amount)
        {
            double balance = _expectPlayerInfo.NonRefundable + _expectPlayerInfo.Refundable;
            balance -= amount;
            Action<UserProfile, UpdatePlayerInfoBalanceCommand> CheckCallMethod = (playerProfile, cmd) => {
                Assert.AreEqual(_expectPlayerInfo.UserName, playerProfile.UserName, "UserName");
                Assert.AreEqual(_expectPlayerInfo.Refundable, playerProfile.Refundable, "Refundable");
                Assert.AreEqual(_expectPlayerInfo.NonRefundable, playerProfile.NonRefundable, "NonRefundable");
            };

            Dac_UpdatePlayerInfoBalance.ApplyAction(new UserProfile(), new UpdatePlayerInfoBalanceCommand());
            LastCall.IgnoreArguments().Do(CheckCallMethod);
        }

        [Given(@"the player action information should be update as: \(UserName: (.*), RoundID: (.*), Amount: (.*), Color: (.*), TrackingID: (.*)\)")]
        public void GivenThePlayerActionInformationShouldBeUpdateAsUserNameXRoundIDXAmountXColorXTrackingIDX(string userName, int roundID, string amount, string color, string trackingID)
        {
            PlayerActionInformation _expected = new PlayerActionInformation {
                RoundID = roundID,
                UserName = userName,
                ActionType = color,
                Amount = Convert.ToDouble(amount),
                TrackingID = Guid.Parse(trackingID),
            };

            Func<PlayerActionInformation, CreatePlayerActionInfoCommand, PlayerActionInformation> checkdata = (playerActionInfo, cmd) => {
                Assert.AreEqual(_expected.RoundID, playerActionInfo.RoundID, "RoundID");
                Assert.AreEqual(_expected.UserName, playerActionInfo.UserName, "UserName");
                Assert.AreEqual(_expected.ActionType, playerActionInfo.ActionType, "ActionType");
                Assert.AreEqual(_expected.Amount, playerActionInfo.Amount, "Amount");

                return playerActionInfo;
            };
            Dac_CreatePlayerActionInfo.Create(new PlayerActionInformation(), new CreatePlayerActionInfoCommand());
            LastCall.IgnoreArguments().Do(checkdata);
        }

        [When(@"call BetColorExecutor\(UserName: (.*), RoundID: (.*), Amount: (.*), Color: (.*), TrackingID: (.*)\)")]
        public void WhenCallBetColorExecutorUserNameXRoundIDXAmountXColorXTrackingIDX(string userName, int roundID, double amount, string color, string trackingID)
        {
            BetCommand cmd = new BetCommand {
                UserName = userName,
                RoundID = roundID,
                Amount = amount,
                Color = color,
                TrackingID = Guid.Parse(trackingID),
            };
            BetColorExecutor.Execute(cmd, (x) => { });
        }

        [Then(@"the player action information should be created")]
        public void ThenThePlayerActionInformationShouldBeCreated()
        {
            Assert.IsTrue(true, "Expectation has been verified in the end of block When.");
        }
    }
}
