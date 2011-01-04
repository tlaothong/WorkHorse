using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TheS.Casinova.PlayerProfile.Models;
using Rhino.Mocks;
using TheS.Casinova.PlayerProfile.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TheS.Casinova.PlayerProfile.BackServices.Specs.Steps
{
    [Binding]
    public class ReturnRewardSteps
        : PlayerProfileStepsBase
    {
        private IEnumerable<UserProfile> _userProfiles;
        private UserProfile _userProfile;

        [Given(@"\(PlayerProfile_ReturnReward\)server has player information as:")]
        public void GivenPlayerProfile_ReturnRewardServerHasPlayerInformationAs(Table table)
        {
            _userProfiles = (from item in table.Rows
                             select new UserProfile { 
                                 UserName = item["UserName"],
                                 NonRefundable = Convert.ToDouble(item["NonRefundable"]),
                                 Refundable = Convert.ToDouble(item["Refundable"]),
                             });
        }

        [Given(@"\(PlayerProfile_ReturnReward\)sent name: '(.*)' the player's balance should recieved")]
        public void GivenPlayerProfile_ReturnRewardSentNameXThePlayerSBalanceShouldRecieved(string userName)
        {
            _userProfile = (from item in _userProfiles
                            where item.UserName == userName
                            select item).FirstOrDefault();

            SetupResult.For(Dqr_GetUserProfile.Get(new Commands.GetUserProfileCommand()))
                .IgnoreArguments().Return(_userProfile);
        }

        [Given(@"the user profile should be update\(UserName: '(.*)', NonRefundable: '(.*)', Refundable: '(.*)'\)")]
        public void GivenTheUserProfileShouldBeUpdateUserNameXNonRefundableXRefundableX(string userName, double nonRefundable, double refundable)
        {
            Action<UserProfile, ReturnRewardCommand> checkData = (userProfile, cmd) => {
                Assert.AreEqual(userName, userProfile.UserName, "UserName");
                Assert.AreEqual(nonRefundable, userProfile.NonRefundable, "NonRefundable");
                Assert.AreEqual(refundable, userProfile.Refundable, "Refundable");
            };

            Dac_ReturnReward.ApplyAction(new UserProfile(), new Commands.ReturnRewardCommand());
            LastCall.IgnoreArguments().Do(checkData);
        }

        [When(@"call ReturnRewardExecutor\(UserName: '(.*)', NonRefundable: '(.*)', Refundable: '(.*)'\)")]
        public void WhenCallReturnRewardExecutorUserNameOhAeNonRefundable1Refundable8(string userName, double nonRefundable, double refundable)
        {
            ReturnRewardCommand cmd = new ReturnRewardCommand {
                UserProfile = new UserProfile {
                    UserName = userName,
                    NonRefundable = nonRefundable,
                    Refundable = refundable,
                },
            };
            ReturnRewardExecutor.Execute(cmd, (x) => { });
        }
    }
}
