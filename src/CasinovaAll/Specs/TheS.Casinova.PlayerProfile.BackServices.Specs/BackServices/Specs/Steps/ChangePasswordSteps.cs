using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TheS.Casinova.PlayerProfile.Models;
using Rhino.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheS.Casinova.PlayerProfile.Commands;
using PerfEx.Infrastructure.Validation;

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

        [Given(@"\(ChangePassword\)the player profile should be recieved\(UserName: '(.*)'\)")]
        public void GivenChangePasswordThePlayerProfileShouldBeRecievedUserNameX(string userName)
        {
            var qry = (from item in _iUserProfiles
                       where item.UserName == userName
                       select item).FirstOrDefault();

            SetupResult.For(Dqr_GetUserProfile.Get(new Commands.GetUserProfileCommand()))
                .IgnoreArguments().Return(qry);
        }

        [Given(@"the user profile should be update\(UserName: '(.*)', NewPassword: '(.*)'\)")]
        public void GivenTheUserProfileShouldBeUpdateUserNameXNewPasswordX(string userName, string newPassword)
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
                UserProfile = new UserProfile {
                    UserName = userName,
                    Password = oldPassword,
                },
                NewPassword = newPassword,
            };

            ChangePasswordExecutor.Execute(cmd, (x) => { });
        }

        [When(@"Expected exception and call ChangePasswordExecutor\(UserName: '(.*)', OldPassword: '(.*)', NewPassword: '(.*)'\)")]
        public void WhenExpectedExceptionAndChangePasswordExecutorUserNameXOldPasswordXNewPasswordX(string userName, string oldPassword, string newPassword)
        {
            try {
                ChangePasswordCommand cmd = new ChangePasswordCommand {
                    UserProfile = new UserProfile {
                        UserName = userName,
                        Password = oldPassword,
                    },
                    NewPassword = newPassword,
                };

                ChangePasswordExecutor.Execute(cmd, (x) => { });
                Assert.Fail("Shouldn't be here!");
            }
            catch (Exception ex) {
                Assert.IsInstanceOfType(ex, typeof(ValidationErrorException));
            }
        }
    
        [Then(@"the password should be update")]
        public void ThenThePasswordShouldBeUpdate()
        {
            Assert.IsTrue(true, "Expectation has been verified in the end of block When.");
        }
    }
}
