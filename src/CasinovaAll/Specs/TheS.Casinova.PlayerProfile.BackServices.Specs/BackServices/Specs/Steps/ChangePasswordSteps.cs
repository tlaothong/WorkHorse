using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TheS.Casinova.PlayerProfile.Models;
using Rhino.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheS.Casinova.PlayerProfile.Commands;

namespace TheS.Casinova.PlayerProfile.BackServices.Specs.Steps
{
    [Binding]
    public class ChangePasswordSteps
        : PlayerProfileStepsBase
    {
        private IEnumerable<UserProfile> _iUserProfiles;

        [Given(@"\(ChangePassword\)server has user profile information as:")]
        public void GivenChangePasswordServerHasUserProfileInformationAs(Table table)
        {
            _iUserProfiles = (from item in table.Rows
                              select new UserProfile {
                                  UserName = item["UserName"],
                                  Password = item["Password"],
                              });
        }

        [Given(@"the old password should be correct\(UserName: '(.*)', OldPassword: '(.*)'\)")]
        public void GivenTheOldPasswordShouldBeCorrectUserNameXOldPasswordX(string userName, string oldPassword)
        {
            var qry = (from item in _iUserProfiles
                       where item.UserName == userName
                       select item).FirstOrDefault();

            SetupResult.For(Dqr_GetUserProfile.Get(new Commands.GetUserProfileCommand()))
                .IgnoreArguments().Return(qry);

            Assert.AreEqual(qry.Password, oldPassword, "OldPassword");
        }

        [Given(@"the user profile should be update\(UserName: '(.*)', OldPassword: '(.*)', NewPassword: '(.*)'\)")]
        public void GivenTheUserProfileShouldBeUpdateUserNameXOldPasswordXNewPasswordX(string userName, string oldPassword, string newPassword)
        {
            Action<UserProfile, ChangePasswordCommand> checkData = (userProfile, cmd) => 
            {
                Assert.AreEqual(userName, userProfile.UserName, "UserName");
                Assert.AreEqual(newPassword, userProfile.Password, "Password");
            };

            Dac_ChangePassword.ApplyAction(new UserProfile(), new ChangePasswordCommand());
            LastCall.IgnoreArguments().Do(checkData);
        }

        [When(@"call ChangePasswordExecutor\(UserName: '(.*)', OldPassword: '(.*)', NewPassword: '(.*)'\)")]
        public void WhenCallChangePasswordExecutorUserNameXOldPasswordXNewPasswordX(string userName, string oldPassword, string newPassword)
        {
            ChangePasswordCommand cmd = new ChangePasswordCommand {
                UserName = userName,
                OldPassword = oldPassword,
                NewPassword = newPassword,
            };

            ChangePasswordExecutor.Execute(cmd, (x) => { });
        }

        [Then(@"the password should be update in user profile")]
        public void ThenThePasswordShouldBeUpdateInUserProfile()
        {
            Assert.IsTrue(true, "Expectation has been verified in the end of block When.");
        }
    }
}
