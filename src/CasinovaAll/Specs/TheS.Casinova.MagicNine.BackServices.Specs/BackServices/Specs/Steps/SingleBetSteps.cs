using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TheS.Casinova.MagicNine.Models;
using Rhino.Mocks;
using TheS.Casinova.MagicNine.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheS.Casinova.PlayerProfile.Models;
using PerfEx.Infrastructure.Validation;

namespace TheS.Casinova.MagicNine.BackServices.Specs.Steps
{
    [Binding]
    public class SingleBetSteps
        : MagicNineStepsBase
    {
        private IEnumerable<UserProfile> _playerProfiles;
        private UserProfile _playerProfile;

        [Given(@"\(SingleBet\)server has player information as:")]
        public void GivenSingleBetServerHasPlayerInformationAs(Table table)
        {
            _playerProfiles = (from item in table.Rows
                            select new UserProfile { 
                                UserName = item["UserName"],
                                Refundable = Convert.ToDouble(item["Refundable"]),
                                NonRefundable = Convert.ToDouble(item["NonRefundable"]),
                            });
        }

        [Given(@"\(SingleBet\)sent name: '(.*)' the player's balance should recieved")]
        public void GivenSingleBetSentNameOhAeThePlayerSBalanceShouldRecieved(string userName)
        {
            var _expectPlayerProfile = (from item in _playerProfiles
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

        [Given(@"the player's balance should be update only bonuschips, Amount: '(.*)'")]
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

        [Given(@"\(SingleBet\)the player's balance should be update both chips, Amount: '(.*)'")]
        public void GivenSingleBetThePlayerSBalanceShouldBeUpdateBothChipsAmountX(double amount)
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

        [Given(@"the bet information assume dateTime as: '(.*)'\(RoundID: '(.*)', UserName: '(.*)', TrackingID: '(.*)', DateTime: '(.*)'\) should be create")]
        public void GivenTheBetInformationAssumeDateTimeAsXRoundIDXUserNameXTrackingIDXDateTimeXShouldBeCreate(DateTime assumeDateTime, int roundID, string userName, string trackingID, DateTime dateTime)
        {
            Func<BetInformation, SingleBetCommand, BetInformation> checkData = (betInfo, cmd) => {
                Assert.AreEqual(roundID, betInfo.RoundID, "RoundID");
                Assert.AreEqual(userName, betInfo.UserName, "UserName");
                Assert.AreEqual(Guid.Parse(trackingID), betInfo.BetTrackingID, "BetTrackingID");

                //define datetime by assume datetime
                return betInfo;
            };

            Dac_SingleBet.Create(new BetInformation(), new SingleBetCommand());
            LastCall.IgnoreArguments().Do(checkData);
        }

        [When(@"call SingleBetExecutor\(RoundID: '(.*)', UserName: '(.*)', TrackingID: '(.*)'\)")]
        public void WhenCallSingleBetExecutorRoundIDXUserNameXTrackingIDX(int roundID, string userName, string betTrackingID)
        {
            SingleBetCommand cmd = new SingleBetCommand {
                BetInfo = new BetInformation {
                    RoundID = roundID,
                    UserName = userName,
                    BetTrackingID = Guid.Parse(betTrackingID),
                },
            };

            SingleBetExecutor.Execute(cmd, (x) => { });
        }

        [When(@"Expected exception and call SingleBetExecutor\(RoundID: '(.*)', UserName: '(.*)', TrackingID: '(.*)'\)")]
        public void WhenExpectedExceptionAndCallSingleBetExecutorRoundIDXUserNameXTrackingIDX(int roundID, string userName, string betTrackingID)
        {
            try {
                SingleBetCommand cmd = new SingleBetCommand {
                    BetInfo = new BetInformation {
                        RoundID = roundID,
                        UserName = userName,
                        BetTrackingID = Guid.Parse(betTrackingID),
                    },
                };
                SingleBetExecutor.Execute(cmd, (x) => { });
                Assert.Fail("Shouldn't be here!");
            }
            catch (Exception ex) {
                Assert.IsInstanceOfType(ex, typeof(ValidationErrorException));
            }
        }

        [Then(@"the result should be create")]
        public void ThenTheResultShouldBeCreate()
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
