using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TheS.Casinova.Colors.Models;
using TheS.Casinova.Colors.Commands;
using Rhino.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheS.Casinova.PlayerProfile.Models;
using PerfEx.Infrastructure.Validation;

namespace TheS.Casinova.Colors.BackServices.Specs
{
    [Binding]
    public class BetColorSteps
        : ColorsGameStepsBase
    {
        private UserProfile _expectPlayerProfile;
        private IEnumerable<UserProfile> _playerProfiles;
        private UserProfile _playerProfile;

        [Given(@"\(BetColor\)server has player profile information as:")]
        public void GivenBetColorServerHasPlayerProfileInformationAs(Table table)
        {
            _playerProfiles = (from item in table.Rows
                            select new UserProfile {
                                UserName = item["UserName"],
                                NonRefundable = Convert.ToDouble(item["NonRefundable"]),
                                Refundable = Convert.ToDouble(item["Refundable"]),
                            });
        }

        [Given(@"sent name: (.*) the player's balance should recieved, for bet color")]
        public void GivenSentNameXThePlayerSBalanceShouldRecievedForBetColor(string userName)
        {
            _expectPlayerProfile = (from item in _playerProfiles
                                     where item.UserName == userName
                                     select item).FirstOrDefault();

            SetupResult.For(Dqr_GetPlayerInfo.Get(new GetPlayerInfoCommand()))
                .IgnoreArguments().Return(_expectPlayerProfile);

            _playerProfile = new UserProfile {
                UserName = _expectPlayerProfile.UserName,
                NonRefundable = _expectPlayerProfile.NonRefundable,
                Refundable = _expectPlayerProfile.Refundable,
            };
        }

        [Given(@"the player's balance should be update both chips, Amount: (.*)")]
        public void GivenThePlayerSBalanceShouldBeUpdateBothChipsAmountX(double amount)
        {
            _playerProfile.Refundable -= amount - _playerProfile.NonRefundable;
            _playerProfile.NonRefundable = 0;

            Action<UserProfile, UpdatePlayerInfoBalanceCommand> CheckCallMethod = (playerProfile, cmd) => {
                Assert.AreEqual(_playerProfile.UserName, playerProfile.UserName, "UserName");
                Assert.AreEqual(_playerProfile.Refundable, playerProfile.Refundable, "Refundable");
                Assert.AreEqual(_playerProfile.NonRefundable, playerProfile.NonRefundable, "NonRefundable");
            };

            Dac_UpdatePlayerInfoBalance.ApplyAction(new UserProfile(), new UpdatePlayerInfoBalanceCommand());
            LastCall.IgnoreArguments().Do(CheckCallMethod);
        }

        [Given(@"the player's balance should be update only bonuschips, Amount: (.*)")]
        public void GivenThePlayerSBalanceShouldBeUpdateOnlyBonuschipsAmountX(double amount)
        {
            _playerProfile.NonRefundable -= amount;

            Action<UserProfile, UpdatePlayerInfoBalanceCommand> CheckCallMethod = (playerProfile, cmd) => {
                Assert.AreEqual(_playerProfile.UserName, playerProfile.UserName, "UserName");
                Assert.AreEqual(_playerProfile.Refundable, playerProfile.Refundable, "Refundable");
                Assert.AreEqual(_playerProfile.NonRefundable, playerProfile.NonRefundable, "NonRefundable");
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
            BetCommand cmd = new BetCommand 
            {
                PlayerActionInformation = new PlayerActionInformation {
                UserName = userName,
                RoundID = roundID,
                Amount = amount,
                ActionType = color,
                TrackingID = Guid.Parse(trackingID),                    
                }
            };
            BetColorExecutor.Execute(cmd, (x) => { });
        }

        [When(@"Expected exception and call BetColorExecutor\(UserName: (.*), RoundID: (.*), Amount: (.*), Color: (.*), TrackingID: (.*)\)")]
        public void WhenExpectedExceptionAndCallBetColorExecutorUserNameXRoundIDXAmountXColorXTrackingIDX(string userName, int roundID, double amount, string color, string trackingID)
        {
            try {
                BetCommand cmd = new BetCommand {
                    PlayerActionInformation = new PlayerActionInformation {
                        UserName = userName,
                        RoundID = roundID,
                        Amount = amount,
                        ActionType = color,
                        TrackingID = Guid.Parse(trackingID),
                    }
                };

                BetColorExecutor.Execute(cmd, (x) => { });
                Assert.Fail("Shouldn't be here!");
            }
            catch (Exception ex) {
                Assert.IsInstanceOfType(ex, typeof(ValidationErrorException));
            }                  
        }

        [Then(@"the player action information should be created")]
        public void ThenThePlayerActionInformationShouldBeCreated()
        {
            Assert.IsTrue(true, "Expectation has been verified in the end of block When.");
        }

        [Then(@"the result should be throw exception")]
        public void ThenTheResultShouldBeThrowException()
        {
            Assert.IsTrue(true, "Expectation has been verified in the end of block When.");
        }
    }
}
