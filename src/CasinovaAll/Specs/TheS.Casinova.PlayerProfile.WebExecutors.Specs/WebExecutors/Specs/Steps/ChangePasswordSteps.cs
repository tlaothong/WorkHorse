using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TheS.Casinova.PlayerProfile.Commands;
using TheS.Casinova.PlayerProfile.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerfEx.Infrastructure.Validation;
using Rhino.Mocks;

namespace TheS.Casinova.PlayerProfile.WebExecutors.Specs.Steps
{
    [Binding]
    public class ChangePasswordSteps : PlayerProfileModuleStepsBase
    {
        private ChangePasswordCommand _cmd;
  
        [Given(@"Sent UserName '(.*)' OldPassword '(.*)' NewPassword '(.*)'")]
        public void GivenSentUserNameXOldPasswordXNewPasswordX(string userName, string oldPassword, string newPassword)
        {
            _cmd = new ChangePasswordCommand {
                UserProfile = new UserProfile { 
                    UserName = userName,
                    Password = oldPassword,
                    NewPassword = newPassword
                }
            };
        }

        [Given(@"Call membership service to validate change password information : UserName '(.*)' OldPassword '(.*)' NewPassword '(.*)'")]
        public void GivenCallMembershipServiceToValidateChangePasswordInformationUserNameXOldPasswordXNewPasswordX(string userName, string oldPassword, string newPassword)
        {
            Action<UserProfile> checkData = (userProfile) => {
                Assert.AreEqual(userName, userProfile.UserName, "UserName");
                Assert.AreEqual(oldPassword, userProfile.Password, "OldPassword");
                Assert.AreEqual(newPassword, userProfile.NewPassword, "NewPassword");
            };

            svc_Membership.ChangePassword(new UserProfile());
            LastCall.IgnoreArguments().Do(checkData);
        }

        //Validation
        [When(@"Call ChangePasswordExecutor\(\) for validation input")]
        public void WhenCallChangePasswordExecutorForValidationInput()
        {
            try {
                ChangePassword.Execute(_cmd, (x) => { });
                Assert.Fail("Shouldn't be here");
            }
            catch (Exception ex) {
                Assert.IsInstanceOfType(ex,
                    typeof(ValidationErrorException));
            }
        }

        //Test function
        [When(@"Call ChangePasswordExecutor\(\)")]
        public void WhenCallChangePasswordExecutor()
        {
              ChangePassword.Execute(_cmd, (x) => { });
        }

         [Then(@"Skip call membership service to change new password")]
         public void ThenSkipCallMembershipServiceToChangeNewPassword()
         {
             Assert.IsTrue(true, "Exception has been verified in the end of block When.");      
         }


         [Then(@"Membership service can change new password")]
         public void ThenMembershipServiceCanChangeNewPassword()
        {
            Assert.IsTrue(true, "Membership has been verified in the end of block When.");
        }
    }
}
