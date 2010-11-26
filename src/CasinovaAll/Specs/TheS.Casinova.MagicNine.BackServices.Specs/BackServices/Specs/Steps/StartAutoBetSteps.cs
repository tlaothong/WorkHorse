using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TheS.Casinova.MagicNine.Models;
using TheS.Casinova.MagicNine.Commands;
using Rhino.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheS.Casinova.PlayerProfile.Models;
using PerfEx.Infrastructure.Validation;

namespace TheS.Casinova.MagicNine.BackServices.Specs.Steps
{
    [Binding]
    public class StartAutoBetSteps
        : MagicNineStepsBase
    {
        private IEnumerable<UserProfile> _userProfiles;
        private UserProfile _expectUserProfile;
        private UserProfile _userProfile;

        [Given(@"\(StartAutoBet\)server has player information as:")]
        public void GivenAutoBetServerHasPlayerInformationAs(Table table)
        {
            _userProfiles = (from item in table.Rows
                             select new UserProfile {
                                 UserName = item["UserName"],
                                 NonRefundable = Convert.ToDouble(item["NonRefundable"]),
                                 Refundable = Convert.ToDouble(item["Refundable"]),
                             });
        }

        [Given(@"\(StartAutoBet\)sent name: '(.*)' the player's balance should recieved")]
        public void GivenStartAutoBetSentNameXThePlayerSBalanceShouldRecieved(string userName)
        {
            _expectUserProfile = (from item in _userProfiles
                            where item.UserName == userName
                            select item).FirstOrDefault();

            SetupResult.For(Dqr_GetPlayerInfo.Get(new GetPlayerInfoCommand()))
                .IgnoreArguments().Return(_expectUserProfile);

            _userProfile = new UserProfile {
                UserName = _expectUserProfile.UserName,
                NonRefundable = _expectUserProfile.NonRefundable,
                Refundable = _expectUserProfile.Refundable,
            };
        }

        [Given(@"\(StartAutoBet\)the player's balance should be update only bonuschips, Amount: '(.*)'")]
        public void GivenStartAutoBetThePlayerSBalanceShouldBeUpdateOnlyBonuschipsAmountX(double amount)
        {
            _expectUserProfile.NonRefundable -= amount;

            Action<UserProfile, UpdatePlayerInfoBalanceCommand> CheckCallMethod = (playerProfile, cmd) => {
                Assert.AreEqual(_expectUserProfile.UserName, playerProfile.UserName, "UserName");
                Assert.AreEqual(_expectUserProfile.Refundable, playerProfile.Refundable, "Refundable");
                Assert.AreEqual(_expectUserProfile.NonRefundable, playerProfile.NonRefundable, "NonRefundable");
            };

            Dac_UpdatePlayerInfoBalance.ApplyAction(new UserProfile(), new UpdatePlayerInfoBalanceCommand());
            LastCall.IgnoreArguments().Do(CheckCallMethod);
        }

        [Given(@"\(StartAutoBet\)the player's balance should be update both chips, Amount: '(.*)'")]
        public void GivenStartAutoBetThePlayerSBalanceShouldBeUpdateBothChipsAmountX(double amount)
        {
            _userProfile.Refundable -= amount - _expectUserProfile.NonRefundable;
            _userProfile.NonRefundable = 0;

            Action<UserProfile, UpdatePlayerInfoBalanceCommand> CheckCallMethod = (playerProfile, cmd) => {
                Assert.AreEqual(_userProfile.UserName, playerProfile.UserName, "UserName");
                Assert.AreEqual(_userProfile.Refundable, playerProfile.Refundable, "Refundable");
                Assert.AreEqual(_userProfile.NonRefundable, playerProfile.NonRefundable, "NonRefundable");
            };

            Dac_UpdatePlayerInfoBalance.ApplyAction(new UserProfile(), new UpdatePlayerInfoBalanceCommand());
            LastCall.IgnoreArguments().Do(CheckCallMethod);
        }

        [Given(@"the autobet information should be update assume dateTime as: '(.*)'\(UserName: '(.*)', RoundID: '(.*)', Amount: '(.*)', Interval: '(.*)', AutoBetTrackingID: '(.*)', BetTrackingID: '(.*)'\)")]
        public void GivenTheAutobetInformationShouldBeUpdateAssumeDateTimeAsXUserNameXRoundIDXAmountXIntervalXAutoBetTrackingIDXBetTrackingIDX(string dateTime, string userName, int roundID, double amount, int interval, string autoBetTrackingID, string betTrackingID)
        {
            Func<GamePlayAutoBetInformation, StartAutoBetCommand, GamePlayAutoBetInformation> checkData = (autoBetInfo, cmd) => {
                Assert.AreEqual(roundID, autoBetInfo.Round, "RoundID");
                Assert.AreEqual(userName, autoBetInfo.UserName, "UserName");
                Assert.AreEqual(amount, autoBetInfo.Amount, "Amount");
                Assert.AreEqual(interval, autoBetInfo.Interval, "Interval");
                Assert.AreEqual(Guid.Parse(autoBetTrackingID), autoBetInfo.AutoBetTrackingID, "AutoBetTrackingID");
                Assert.AreEqual(Guid.Parse(betTrackingID), autoBetInfo.BetTrackingID, "BetTrackingID");

                //define datetime by assume datetime
                return autoBetInfo;
            };

            Dac_CreateAutoBetInfo.Create(new GamePlayAutoBetInformation(), new StartAutoBetCommand());
            LastCall.IgnoreArguments().Do(checkData);
        }

        [Given(@"the StartAuto Engine shoule be call as: \(UserName: '(.*)', RoundID: '(.*)', Amount: '(.*)', Interval: '(.*)', AutoBetTrackingID: '(.*)', BetTrackingID: '(.*)'\)")]
        public void GivenTheStartAutoEngineShouleBeCallAsUserNameXRoundIDXAmountXIntervalXAutoBetTrackingIDXBetTrackingIDX(string userName, int roundID, double amount, int interval, string autoBetTrackingID, string betTrackingID)
        {
            Action<GamePlayAutoBetInformation, StartAutoBetCommand> checkData = (autoBetInfo, cmd) => {
                Assert.AreEqual(roundID, autoBetInfo.Round, "RoundID");
                Assert.AreEqual(userName, autoBetInfo.UserName, "UserName");
                Assert.AreEqual(amount, autoBetInfo.Amount, "Amount");
                Assert.AreEqual(interval, autoBetInfo.Interval, "Interval");
                Assert.AreEqual(Guid.Parse(autoBetTrackingID), autoBetInfo.AutoBetTrackingID, "AutoBetTrackingID");
                Assert.AreEqual(Guid.Parse(betTrackingID), autoBetInfo.BetTrackingID, "BetTrackingID");
            };
            Svc_AutoBetEngine.StartAutoBet(new GamePlayAutoBetInformation(), new StartAutoBetCommand());
            LastCall.IgnoreArguments().Do(checkData);
        }

        [When(@"call StartAutoBetExecutor\(UserName: '(.*)', RoundID: '(.*)', Amount: '(.*)', Interval: '(.*)', AutoBetTrackingID: '(.*)', BetTrackingID: '(.*)'\)")]
        public void WhenCallStartAutoBetExecutorUserNameXRoundIDXAmountXIntervalXAutoBetTrackingIDXBetTrackingIDX(string userName, int roundID, double amount, int interval, string autoBetTrackingID, string betTrackingID)
        {
            StartAutoBetCommand cmd = new StartAutoBetCommand {
                GamePlayAutoBetInfo = new GamePlayAutoBetInformation {
                    Round = roundID,
                    UserName = userName,
                    Amount = amount,
                    Interval = interval,
                    AutoBetTrackingID = Guid.Parse(autoBetTrackingID),
                    BetTrackingID = Guid.Parse(betTrackingID),
                },
            };

            StartAutoBetExecutor.Execute(cmd, (x) => { });
        }

        [When(@"Expected exeception and call StartAutoBetExecutor\(UserName: '(.*)', RoundID: '(.*)', Amount: '(.*)', Interval: '(.*)', AutoBetTrackingID: '(.*)', BetTrackingID: '(.*)'\)")]
        public void WhenExpectedExeceptionAndCallStartAutoBetExecutorUserNameXRoundIDXAmountXIntervalXAutoBetTrackingIDXBetTrackingIDX(string userName, int roundID, double amount, int interval, string autoBetTrackingID, string betTrackingID)
        {
            try {
                StartAutoBetCommand cmd = new StartAutoBetCommand {
                    GamePlayAutoBetInfo = new GamePlayAutoBetInformation {
                        Round = roundID,
                        UserName = userName,
                        Amount = amount,
                        Interval = interval,
                        AutoBetTrackingID = Guid.Parse(autoBetTrackingID),
                        BetTrackingID = Guid.Parse(betTrackingID),
                    },
                };

                StartAutoBetExecutor.Execute(cmd, (x) => { });
                Assert.Fail("Shouldn't be here!");
            }
            catch (Exception ex) {
                Assert.IsInstanceOfType(ex, typeof(ValidationErrorException));
            }
        }

        [Then(@"autobet engine should be execute")]
        public void ThenAutobetEngineShouldBeExecute()
        {
            Assert.IsTrue(true, "Expectation has been verified in the end of block When.");
        }

        [Then(@"the player information should be update and call StartAutoBet")]
        public void ThenThePlayerActionInformationShouldBeCreated()
        {
            Assert.IsTrue(true, "Expectation has been verified in the end of block When.");
        }
    }
}
