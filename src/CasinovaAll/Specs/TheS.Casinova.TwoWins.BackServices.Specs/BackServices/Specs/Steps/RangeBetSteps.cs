using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TheS.Casinova.PlayerProfile.Models;
using TheS.Casinova.TwoWins.Models;
using TheS.Casinova.TwoWins.Commands;
using Rhino.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerfEx.Infrastructure.Validation;

namespace TheS.Casinova.TwoWins.BackServices.Specs.Steps
{
    [Binding]
    public class RangeBetSteps
        : TwowinsStepsBase
    {
        private IEnumerable<UserProfile> _userProfiles;
        private IEnumerable<RoundInformation> _roundInfos;
        private IEnumerable<BetInformation> _expectBetInfos;
        private UserProfile _userProfile;
        private RoundInformation _roundInfo;
        private int _beforeEndGameDateTiem;
        private DateTime _betDateTime;

        [Given(@"\(Twowins_RangeBet\)player bet before end game: '(.*)' minute")]
        public void GivenTwowins_RangeBetPlayerBetBeforeEndGameXMinute(int beforeEndGame)
        {
            _beforeEndGameDateTiem = beforeEndGame;
            _betDateTime = DateTime.Now.AddMinutes(_beforeEndGameDateTiem);
        }

        [Given(@"\(Twowins_RangeBet\)server has player information as:")]
        public void GivenTwowins_RangeBetServerHasPlayerInformationAs(Table table)
        {
            _userProfiles = (from item in table.Rows
                             select new UserProfile {
                                 UserName = item["UserName"],
                                 NonRefundable = Convert.ToDouble(item["NonRefundable"]),
                                 Refundable = Convert.ToDouble(item["Refundable"]),
                             });
        }

        [Given(@"\(Twowins_RangeBet\)server has round information as:")]
        public void GivenTwowins_RangeBetServerHasRoundInformationAs(Table table)
        {
            _roundInfos = from item in table.Rows
                          select new RoundInformation {
                              RoundID = Convert.ToInt32(item["RoundID"]),
                              Pot = Convert.ToDouble(item["Pot"]),
                              FromDateTime = DateTime.Now.AddMinutes(Convert.ToInt32(item["FromDateTime"])),
                              ThruDateTime = DateTime.Now.AddMinutes(Convert.ToInt32(item["ThruDateTime"])),
                              CriticalDateTime = DateTime.Now.AddMinutes(Convert.ToInt32(item["CriticalTime"])),
                          };
        }

        [Given(@"\(Twowins_RangeBet\)sent name: '(.*)' the player's balance should recieved")]
        public void GivenTwowins_RangeBetSentNameXThePlayerSBalanceShouldRecieved(string userName)
        {
            _userProfile = (from item in _userProfiles
                            where item.UserName == userName
                            select item).FirstOrDefault();
            SetupResult.For(Dqr_GetUserProfile.Get(new GetUserProfileCommand()))
                .IgnoreArguments().Return(_userProfile);
        }

        [Given(@"\(Twowins_RangeBet\)sent roundID: '(.*)' the round information should recieved")]
        public void GivenTwowins_RangeBetBetSentRoundIDXTheRoundInformationShouldRecieved(int roundID)
        {
            _roundInfo = (from item in _roundInfos
                          where item.RoundID == roundID
                          select item).FirstOrDefault();
            SetupResult.For(Dqr_GetRoundInfo.Get(new GetRoundInfoCommand()))
                .IgnoreArguments().Return(_roundInfo);
        }

        [Given(@"\(Twowins_RangeBet\)the round pot information should be update\(RoundID: '(.*)', Pot: '(.*)'\)")]
        public void GivenTwowins_RangeBetTheRoundPotInformationShouldBeUpdateRoundIDXPotX(int roundID, double pot)
        {
            Action<RoundInformation, UpdateRoundInfoCommand> checkData = (roundInfo, cmd) => {
                Assert.AreEqual(roundID, roundInfo.RoundID, "RoundID");
                Assert.AreEqual(pot, roundInfo.Pot, "Pot");
            };

            Dac_UpdateRoundInfo.ApplyAction(new RoundInformation(), new UpdateRoundInfoCommand());
            LastCall.IgnoreArguments().Do(checkData);
        }

        [Given(@"\(Twowins_RangeBet\)the player's balance should be update only bonuschips\(UserName: '(.*)', BonusChips: '(.*)', Chips: '(.*)'\)")]
        public void GivenTwowins_RangeBetThePlayerSBalanceShouldBeUpdateOnlyBonuschipsUserNameXBonusChipsXChipsX(string userName, double bonusChips, double chips)
        {
            Action<UserProfile, UpdateUserProfileCommand> checkData = (userProfile, cmd) => {
                Assert.AreEqual(userName, userProfile.UserName, "UserName");
                Assert.AreEqual(bonusChips, userProfile.NonRefundable, "BonusChips");
                Assert.AreEqual(chips, userProfile.Refundable, "Chips");
            };
            Dac_UpdateUserProfile.ApplyAction(new UserProfile(), new UpdateUserProfileCommand());
            LastCall.IgnoreArguments().Do(checkData);
        }

        [Given(@"\(Twowins_RangeBet\)the action log information should be create\(RoundID: '(.*)', UserName: '(.*)', ActionType: '(.*)', Amount: '(.*)', OldAmount: '(.*)', HandStatus: '(.*)', CanChange: '(.*)'\)")]
        public void GivenTwowins_RangeBetTheActionLogInformationShouldBeCreateRoundIDXUserNameXActionTypeXAmountXOldAmountXHandStatusXCanChangeX(int roundID, string userName, string actionType, double amount, double oldAmount, string handStatus, bool canChange)
        {
            Func<ActionLogInformation, CreateActionLogInfoCommand, ActionLogInformation> checkData = (actionLogInfo, cmd) => {
                Assert.AreEqual(roundID, actionLogInfo.RoundID, "RoundID");
                Assert.AreEqual(userName, actionLogInfo.UserName, "UserName");
                Assert.AreEqual(actionType, actionLogInfo.ActionType, "ActionType");
                Assert.AreEqual(amount, actionLogInfo.Amount, "Amount");
                Assert.AreEqual(oldAmount, actionLogInfo.OldAmount, "OldAmount");
                Assert.AreEqual(handStatus, actionLogInfo.HandStatus, "HandStatus");

                Assert.AreEqual(DateTime.Now.ToString(), actionLogInfo.ActionDateTime.ToString(), "ActionDateTime");
                Assert.AreEqual(canChange, actionLogInfo.CanChange, "CanChange");
                return actionLogInfo;
            };
            Dac_CreateActionLogInfo.Create(new ActionLogInformation(), new CreateActionLogInfoCommand());
            LastCall.IgnoreArguments().Do(checkData);
        }
        
        [Given(@"\(Twowins_RangeBet\)expected the bet information should be create")]
        public void GivenTwowins_RangeBetExpectedTheBetInformationShouldBeCreate(Table table)
        {
            _expectBetInfos = (from item in table.Rows
                               select new BetInformation {
                                   RoundID = Convert.ToInt32(item["RoundID"]),
                                   UserName = item["UserName"],
                                   BetTrackingID = Guid.Parse(item["BetTrackingID"]),
                                   BetDateTime = DateTime.Now,
                                   HandStatus = item["Status"],
                                   BonusChips = Convert.ToDouble(item["BonusChips"]),
                                   Chips = Convert.ToDouble(item["Chips"]),
                                   CanChange = Convert.ToBoolean(item["CanChange"]),
                               });

            Queue<BetInformation> expect = new Queue<BetInformation>(_expectBetInfos);
            Func<BetInformation, CreateBetInfoCommand, BetInformation> checkdata = (betInfo, cmd) => {
                var exp = expect.Dequeue();
                Assert.AreEqual(exp.RoundID, betInfo.RoundID, "RoundID");
                Assert.AreEqual(exp.UserName, betInfo.UserName, "UserName");
                Assert.AreEqual(exp.BetTrackingID, betInfo.BetTrackingID, "BetTrackingID");
                Assert.AreEqual(exp.BetDateTime.ToString(), betInfo.BetDateTime.ToString(), "BetDateTime");
                Assert.AreEqual(exp.HandStatus, betInfo.HandStatus, "HandStatus");
                Assert.AreEqual(exp.BonusChips, betInfo.BonusChips, "BonusChips");
                Assert.AreEqual(exp.Chips, betInfo.Chips, "Chips");
                Assert.AreEqual(exp.CanChange, betInfo.CanChange, "CanChange");

                return betInfo;
            };

            Dac_CreateBetInfo.Create(new BetInformation(), new CreateBetInfoCommand());
            LastCall.IgnoreArguments().Do(checkdata);
        }
        
        [When(@"\(Twowins_RangeBet\)call RangeBetExecutor\(RoundID: '(.*)', UserName: '(.*)', FromAmount: '(.*)', ThruAmoutn: '(.*)', BetTrackingID: '(.*)'\)")]
        public void WhenTwowins_RangeBetCallRangeBetExecutorRoundIDXUserNameXFromAmountXThruAmoutnXBetTrackingIDX(int roundID, string userName, double fromAmount, double thruAmount, string betTrackingID)
        {
            RangeBetCommand cmd = new RangeBetCommand {
                RangeBetInfo = new RangeBetInformation {
                    RoundID = roundID,
                    UserName = userName,
                    FromAmount = fromAmount,
                    ThruAmount = thruAmount,
                    BetTrackingID = Guid.Parse(betTrackingID),                    
                },
            };

            RangeBetExecutor.Execute(cmd, (x) => { });
        }

        [When(@"\(Twowins_RangeBet\)Expected exception and call RangeBetExecutor\(RoundID: '(.*)', UserName: '(.*)', FromAmount: '(.*)', ThruAmoutn: '(.*)', BetTrackingID: '(.*)'\)")]
        public void WhenTwowins_RangeBetExpectedExceptionAndCallRangeBetExecutorRoundIDXUserNameXFromAmountXThruAmoutnXBetTrackingIDX(int roundID, string userName, double fromAmount, double thruAmount, string betTrackingID)
        {
            try {
                RangeBetCommand cmd = new RangeBetCommand {
                    RangeBetInfo = new RangeBetInformation {
                        RoundID = roundID,
                        UserName = userName,
                        FromAmount = fromAmount,
                        ThruAmount = thruAmount,
                        BetTrackingID = Guid.Parse(betTrackingID),
                    },
                };

                RangeBetExecutor.Execute(cmd, (x) => { });
                Assert.Fail("Shouldn't be here!");
            }
            catch (Exception ex) {
                Assert.IsInstanceOfType(ex, typeof(ValidationErrorException));
            }
        }

        [Then(@"the result should be throw exception")]
        public void ThenTheResultShouldBeThrowException()
        {
            Assert.IsTrue(true, "Expectation has been verified in the end of block When.");
        }
    }
}

