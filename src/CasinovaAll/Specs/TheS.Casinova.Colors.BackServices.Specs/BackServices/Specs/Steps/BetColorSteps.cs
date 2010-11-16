using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TheS.Casinova.Colors.Models;
using TheS.Casinova.Colors.Commands;
using Rhino.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TheS.Casinova.Colors.BackServices.Specs
{
    [Binding]
    public class BetColorSteps
        : ColorsGameStepsBase
    {
        public PlayerInformation _expectPlayerInfo;

        public IEnumerable<PlayerInformation> _playerInfos;


        [Given(@"\(BetColor\)server has player information as:")]
        public void GivenBetColorServerHasPlayerInformationAs(Table table)
        {
            _playerInfos = (from item in table.Rows
                            select new PlayerInformation {
                                UserName = item["UserName"],
                                Balance = Convert.ToDouble(item["Balance"]),
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
            _expectPlayerInfo.Balance -= amount;
            Action<PlayerInformation, UpdatePlayerInfoBalanceCommand> CheckCallMethod = (playerInfo, cmd) => {
                Assert.AreEqual(_expectPlayerInfo.UserName, playerInfo.UserName, "UserName");
                Assert.AreEqual(_expectPlayerInfo.Balance, playerInfo.Balance, "Balance");
            };

            Dac_UpdatePlayerInfoBalance.ApplyAction(new PlayerInformation(), new UpdatePlayerInfoBalanceCommand());
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
