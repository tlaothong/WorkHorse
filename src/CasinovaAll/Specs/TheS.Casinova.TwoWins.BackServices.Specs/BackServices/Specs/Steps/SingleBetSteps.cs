using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using SpecFlowAssist;
using TheS.Casinova.PlayerProfile.Models;
using TheS.Casinova.TwoWins.Models;
using Rhino.Mocks;
using TheS.Casinova.TwoWins.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerfEx.Infrastructure.Validation;
using PerfEx.Infrastructure;

namespace TheS.Casinova.TwoWins.BackServices.Specs.Steps
{
    [Binding]
    public class SingleBetSteps
        : TwowinsStepsBase
    {
        private IEnumerable<UserProfile> _userProfiles;
        private IEnumerable<RoundInformation> _roundInfos;
        private UserProfile _userProfile;
        private RoundInformation _roundInfo;

        [Given(@"\(Twowins_SingleBet\)server has player information as:")]
        public void GivenTwowins_SingleBetServerHasPlayerInformationAs(Table table)
        {
            //_userProfiles = table.CreateSet<UserProfile>();

            _userProfiles = (from item in table.Rows
                             select new UserProfile {
                                 UserName = item["UserName"],
                                 NonRefundable = Convert.ToDouble(item["NonRefundable"]),
                                 Refundable = Convert.ToDouble(item["Refundable"]),
                             });
        }

        [Given(@"\(Twowins_SingleBet\)server has round information as:")]
        public void GivenTwowins_SingleBetServerHasRoundInformationAs(Table table)
        {
            //_roundInfos = table.CreateSet<RoundInformation>();

            _roundInfos = from item in table.Rows
                          select new RoundInformation {
                              RoundID = Convert.ToInt32(item["RoundID"]),
                              Pot = Convert.ToDouble(item["Pot"]),
                              FromDateTime = DateTime.Now.AddMinutes(Convert.ToInt32(item["FromDateTime"])),
                              ThruDateTime = DateTime.Now.AddMinutes(Convert.ToInt32(item["ThruDateTime"])),
                              CriticalDateTime = DateTime.Now.AddMinutes(Convert.ToInt32(item["CriticalTime"])),
                          };
        }

        [Given(@"\(Twowins_SingleBet\)sent name: '(.*)' the player's balance should recieved")]
        public void GivenTwowins_SingleBetSentNameXThePlayerSBalanceShouldRecieved(string userName)
        {
            _userProfile = (from item in _userProfiles
                            where item.UserName == userName
                            select item).FirstOrDefault();
            SetupResult.For(Dqr_GetUserProfile.Get(new GetUserProfileCommand()))
                .IgnoreArguments().Return(_userProfile);
        }

        [Given(@"\(Twowins_SingleBet\)sent roundID: '(.*)' the round information should recieved")]
        public void GivenTwowins_SingleBetSentRoundIDXTheRoundInformationShouldRecieved(int roundID)
        {
            _roundInfo = (from item in _roundInfos
                          where item.RoundID == roundID
                          select item).FirstOrDefault();
            SetupResult.For(Dqr_GetRoundInfo.Get(new GetRoundInfoCommand()))
                .IgnoreArguments().Return(_roundInfo);
        }

        [Given(@"\(Twowins_SingleBet\)the round pot information should be update\(RoundID: '(.*)', Pot: '(.*)'\)")]
        public void GivenTwowins_SingleBetTheRoundPotInformationShouldBeUpdateRoundIDXPotX(int roundID, double pot)
        {
            Action<RoundInformation, UpdateRoundInfoCommand> checkData = (roundInfo, cmd) => {
                Assert.AreEqual(roundID, roundInfo.RoundID, "RoundID");
                Assert.AreEqual(pot, roundInfo.Pot, "Pot");
            };

            Dac_UpdateRoundInfo.ApplyAction(new RoundInformation(), new UpdateRoundInfoCommand());
            LastCall.IgnoreArguments().Do(checkData);
        }

        [Given(@"\(Twowins_SingleBet\)the player's balance should be update\(UserName: '(.*)', BonusChips: '(.*)', Chips: '(.*)'\)")]
        public void GivenTwowins_SingleBetThePlayerSBalanceShouldBeUpdateUserNameXBonusChipsXChipsX(string userName, double bonusChips, double chips)
        {
            Action<UserProfile, UpdateUserProfileCommand> checkData = (userProfile, cmd) => {
                Assert.AreEqual(userName, userProfile.UserName, "UserName");
                Assert.AreEqual(bonusChips, userProfile.NonRefundable, "BonusChips");
                Assert.AreEqual(chips, userProfile.Refundable, "Chips");
            };
            Dac_UpdateUserProfile.ApplyAction(new UserProfile(), new UpdateUserProfileCommand());
            LastCall.IgnoreArguments().Do(checkData);
        }

        [Given(@"\(Twowins_SingleBet\)the action log information should be create \(RoundID: '(.*)', UserName: '(.*)', ActionType: '(.*)', Amount: '(.*)', OldAmount: '(.*)', HandStatus: '(.*)', Change: '(.*)'")]
        public void GivenTwowins_SingleBetTheActionLogInformationShouldBeCreateRoundID1UserNameOhAeActionTypeSingleBetAmount10OldAmount_1HandStatusNormalChangeTrue(int roundID, string userName, string actionType, double amount, double oldAmount, string handStatus, bool change)
        {
            Func<ActionLogInformation, CreateActionLogInfoCommand, ActionLogInformation> checkData = (actionLogInfo, cmd) => {
                Assert.AreEqual(roundID, actionLogInfo.RoundID, "RoundID");
                Assert.AreEqual(userName, actionLogInfo.UserName, "UserName");
                Assert.AreEqual(amount, actionLogInfo.Amount, "Amount");
                Assert.AreEqual(oldAmount, actionLogInfo.OldAmount, "OldAmount");
                Assert.AreEqual(handStatus, actionLogInfo.HandStatus, "HandStatus");
                Assert.AreEqual(change, actionLogInfo.Change, "Change");
                return actionLogInfo;
            };
            Dac_CreateActionLogInfo.Create(new ActionLogInformation(), new CreateActionLogInfoCommand());
            LastCall.IgnoreArguments().Do(checkData);
        }

        [Given(@"\(Twowins_SingleBet\)the bet information \(RoundID: '(.*)', UserName: '(.*)', BetTrackingID: '(.*)', BonusChips: '(.*)', Chips: '(.*)', HandStatus: '(.*)', CanChange: '(.*)'\) should be create")]
        public void GivenTwowins_SingleBetTheBetInformationRoundIDXUserNameXBetTrackingIDXBonusChipsXChipsXHandStatusXShouldBeCreate(int roundID, string userName, string betTrackingID, double bonusChips, double chips, string handStatus, bool canChange)
        {
            Func<BetInformation, CreateBetInfoCommand, BetInformation> checkData = (betInfo, cmd) => {
                Assert.AreEqual(roundID, betInfo.RoundID, "RoundID");
                Assert.AreEqual(userName, betInfo.UserName, "UserName");
                Assert.AreEqual(bonusChips, betInfo.BonusChips, "BonusChips");
                Assert.AreEqual(chips, betInfo.Chips, "Chips");
                Assert.AreEqual(handStatus, betInfo.HandStatus, "HandStatus");
                Assert.AreEqual(canChange, betInfo.CanChange, "CanChange");
                Assert.AreEqual(Guid.Parse(betTrackingID), betInfo.BetTrackingID, "BetTrackingID"); 
                return betInfo;
            };
            Dac_CreateBetInfo.Create(new BetInformation(), new CreateBetInfoCommand());
            LastCall.IgnoreArguments().Do(checkData);
        }

        [When(@"\(Twowins_SingleBet\)call SingleBetExecutor\(RoundID: '(.*)', UserName: '(.*)', Amount: '(.*)', BetTrackingID: '(.*)'\)")]
        public void WhenTwowins_SingleBetCallSingleBetExecutorRoundIDXUserNameXAmountXBetTrackingIDX(int roundID, string userName, double amound, string betTrackingID)
        {
            SingleBetCommand cmd = new SingleBetCommand {
                BetInfo = new BetInformation {
                    RoundID = roundID,
                    UserName = userName,
                    Amount = amound,
                    BetTrackingID = Guid.Parse(betTrackingID),
                },
            };
            SingleBetExecutor.Execute(cmd, (x) => { });
        }

        [When(@"\(Twowins_SingleBet\)Expected exception and call SingleBetExecutor\(RoundID: '(.*)', UserName: '(.*)', Amount: '(.*)', BetTrackingID: '(.*)'\)")]
        public void WhenTwowins_SingleBetExpectedExceptionAndCallSingleBetExecutorRoundIDXUserNameXAmountXBetTrackingIDX(int roundID, string userName, double amound, string betTrackingID)
        {
            try {
                SingleBetCommand cmd = new SingleBetCommand {
                    BetInfo = new BetInformation {
                        RoundID = roundID,
                        UserName = userName,
                        Amount = amound,
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
    }
}
