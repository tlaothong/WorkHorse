using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TheS.Casinova.TwoWins.Models;
using TheS.Casinova.PlayerProfile.Models;
using Rhino.Mocks;
using TheS.Casinova.TwoWins.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TheS.Casinova.TwoWins.BackServices.Specs.Steps
{
    [Binding]
    public class ChangeBetSteps
        : TwowinsStepsBase
    {
        private IEnumerable<UserProfile> _userProfiles;
        private IEnumerable<RoundInformation> _roundInfos;
        private IEnumerable<BetInformation> _betInfos;
        private BetInformation _betInfo;
        private UserProfile _userProfile;
        private RoundInformation _roundInfo;

        [Given(@"\(Twowins_ChangeBet\)server has bet information as:")]
        public void GivenTwowins_ChangeBetServerHasBetInformationAs(Table table)
        {
            _betInfos = (from item in table.Rows
                         select new BetInformation {
                             RoundID = Convert.ToInt32(item["RoundID"]),
                             UserName = item["UserName"],
                             BonusChips = Convert.ToDouble(item["BonusChips"]),
                             Chips = Convert.ToDouble(item["Chips"]),
                             Amount = Convert.ToDouble(item["Amount"]),
                             HandID = Convert.ToInt32(item["HandID"]),
                             HandStatus = item["HandStatus"],
                             CanChange = Convert.ToBoolean(item["CanChange"]),                             
                         });
        }

        [Given(@"\(Twowins_ChangeBet\)server has player information as:")]
        public void GivenTwowins_ChangeBetServerHasPlayerInformationAs(Table table)
        {
            _userProfiles = (from item in table.Rows
                             select new UserProfile {
                                 UserName = item["UserName"],
                                 NonRefundable = Convert.ToDouble(item["NonRefundable"]),
                                 Refundable = Convert.ToDouble(item["Refundable"]),
                             });
        }

        [Given(@"\(Twowins_ChangeBet\)server has round information as:")]
        public void GivenTwowins_ChangeBetServerHasRoundInformationAs(Table table)
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

        [Given(@"\(Twowins_ChangeBet\)sent name: '(.*)' the player's balance should recieved")]
        public void GivenTwowins_ChangeBetSentNameXThePlayerSBalanceShouldRecieved(string userName)
        {
            _userProfile = (from item in _userProfiles
                            where item.UserName == userName
                            select item).FirstOrDefault();
            SetupResult.For(Dqr_GetUserProfile.Get(new GetUserProfileCommand()))
                .IgnoreArguments().Return(_userProfile);
        }

        [Given(@"\(Twowins_ChangeBet\)sent roundID: '(.*)' the round information should recieved")]
        public void GivenTwowins_ChangeBetSentRoundIDXTheRoundInformationShouldRecieved(int roundID)
        {
            _roundInfo = (from item in _roundInfos
                            where item.RoundID == roundID
                            select item).FirstOrDefault();
            SetupResult.For(Dqr_GetRoundInfo.Get(new GetRoundInfoCommand()))
                .IgnoreArguments().Return(_roundInfo);
        }

        [Given(@"\(Twowins_ChangeBet\)sent handID: '(.*)' the round information should recieved")]
        public void GivenTwowins_ChangeBetSentHandIDXTheRoundInformationShouldRecieved(int handID)
        {
            _betInfo = (from item in _betInfos
                          where item.HandID == handID 
                          select item).FirstOrDefault();
            SetupResult.For(Dqr_GetBetInfo.Get(new GetBetInfoCommand()))
                .IgnoreArguments().Return(_betInfo);
        }

        [Given(@"\(Twowins_ChangeBet\)the round pot information should be update\(RoundID: '(.*)', Pot: '(.*)'\)")]
        public void GivenTwowins_ChangeBetTheRoundPotInformationShouldBeUpdateRoundIDXPotX(int roundID, double pot)
        {
            Action<RoundInformation, UpdateRoundInfoCommand> checkData = (roundInfo, cmd) => {
                Assert.AreEqual(roundID, roundInfo.RoundID, "RoundID");
                Assert.AreEqual(pot, roundInfo.Pot, "Pot");
            };

            Dac_UpdateRoundInfo.ApplyAction(new RoundInformation(), new UpdateRoundInfoCommand());
            LastCall.IgnoreArguments().Do(checkData);
        }

       [Given(@"\(Twowins_ChangeBet\)the action log information should be create \(RoundID: '(.*)', UserName: '(.*)', ActionType: '(.*)', Amount: '(.*)', OldAmount: '(.*)', HandStatus: '(.*)', CanChange: '(.*)'")]
        public void GivenTwowins_ChangeBetTheActionLogInformationShouldBeCreateRoundIDXUserNameXActionTypeSingleBetAmountXOldAmountXHandStatusXCanChangeX(int roundID, string userName, string actionType, double amount, double oldAmount, string handStatus, bool canChange)
        {
            Func<ActionLogInformation, CreateActionLogInfoCommand, ActionLogInformation> checkData = (actionLogInfo, cmd) => {
                Assert.AreEqual(roundID, actionLogInfo.RoundID, "RoundID");
                Assert.AreEqual(userName, actionLogInfo.UserName, "UserName");
                Assert.AreEqual(actionType, actionLogInfo.ActionType, "ActionType");
                Assert.AreEqual(amount, actionLogInfo.Amount, "Amount");
                Assert.AreEqual(oldAmount, actionLogInfo.OldAmount, "OldAmount");
                //Assert.AreEqual(DateTime.Now.ToString(), actionLogInfo.ActionDateTime.ToString(), "ActionDateTime");
                Assert.AreEqual(handStatus, actionLogInfo.HandStatus, "HandStatus");
                Assert.AreEqual(canChange, actionLogInfo.CanChange, "CanChange");
                return actionLogInfo;
            };
            Dac_CreateActionLogInfo.Create(new ActionLogInformation(), new CreateActionLogInfoCommand());
            LastCall.IgnoreArguments().Do(checkData);
        }

        [Given(@"\(Twowins_ChangeBet\)the player's balance should be update\(UserName: '(.*)', BonusChips: '(.*)', Chips: '(.*)'\)")]
        public void GivenTwowins_ChangeBetThePlayerSBalanceShouldBeUpdateUserNameXBonusChipsXChipsX(string userName, double bonusChips, double chips)
        {
            Action<UserProfile, UpdateUserProfileCommand> checkData = (userProfile, cmd) => {
                Assert.AreEqual(userName, userProfile.UserName, "UserName");
                Assert.AreEqual(bonusChips, userProfile.NonRefundable, "BonusChips");
                Assert.AreEqual(chips, userProfile.Refundable, "Chips");
            };
            Dac_UpdateUserProfile.ApplyAction(new UserProfile(), new UpdateUserProfileCommand());
            LastCall.IgnoreArguments().Do(checkData);
        }

        [Given(@"\(Twowins_ChangeBet\)the bet information should be update\(RoundID: '(.*)', UserName: '(.*)', BetTrackingID: '(.*)', BonusChips: '(.*)', Chips: '(.*)', HandStatus: '(.*)', CanChange: '(.*)'\)")]
        public void GivenTwowins_ChangeBetTheBetInformationShouldBeUpdateRoundID1UserNameOhAeBetTrackingIDXBonusChipsXChipsXHandStatusXCanChangeX(int roundID, string userName, string betTrackingID, double bonusChips, double chips, string handStatus, bool canChange)
        {
            Action<BetInformation, ChangeBetInfoCommand> checkData = (betInfo, cmd) => {
                Assert.AreEqual(roundID, betInfo.RoundID, "RoundID");
                Assert.AreEqual(userName, betInfo.UserName, "UserName");
                Assert.AreEqual(bonusChips, betInfo.BonusChips, "BonusChips");
                Assert.AreEqual(chips, betInfo.Chips, "Chips");
                Assert.AreEqual(DateTime.Now.ToString(), betInfo.BetDateTime.ToString(), "BetDateTime");
                Assert.AreEqual(handStatus, betInfo.HandStatus, "HandStatus");
                Assert.AreEqual(canChange, betInfo.CanChange, "CanChange");
                Assert.AreEqual(Guid.Parse(betTrackingID), betInfo.BetTrackingID, "BetTrackingID");
            };
            Dac_ChangeBetInfo.ApplyAction(new BetInformation(), new ChangeBetInfoCommand());
            LastCall.IgnoreArguments().Do(checkData);
        }

        [When(@"\(Twowins_ChangeBet\)call ChangeBetExecutor\(UserName: '(.*)', HandID: '(.*)', Amount: '(.*)', RoundID: '(.*)', BetTrackingID: '(.*)'\)")]
        public void WhenTwowins_ChangeBetCallChangeBetExecutorUserNameXHandIDXAmountXRoundIDXBetTrackingIDX(string userName, int handID, double amount, int roundID, string betTrackingID)
        {
            ChangeBetInfoCommand cmd = new ChangeBetInfoCommand {
                BetInfo = new BetInformation {
                    RoundID = roundID,
                    UserName = userName,
                    HandID = handID,
                    Amount = amount,
                    BetTrackingID = Guid.Parse(betTrackingID)
                },
            };
            ChangeBetExecutor.Execute(cmd, (x) => { });
        }
 
        [Then(@"the result should be change")]
        public void ThenTheResultShouldBeChange()
        {
            Assert.IsTrue(true, "Expectation has been verified in the end of block When.");
        }
   }
}
