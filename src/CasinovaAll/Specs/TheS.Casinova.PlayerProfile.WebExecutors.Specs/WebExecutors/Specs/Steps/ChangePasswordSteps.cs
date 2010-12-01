using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TheS.Casinova.PlayerProfile.Commands;
using TheS.Casinova.PlayerProfile.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerfEx.Infrastructure.Validation;

namespace TheS.Casinova.PlayerProfile.WebExecutors.Specs.Steps
{
    [Binding]
    public class ChangePasswordSteps : PlayerProfileModuleStepsBase
    {
        private ChangePasswordCommand _cmd;
        private string _trackingID;

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

        [Given(@"The system generated TrackingID for change password:'(.*)'")]
        public void GivenTheSystemGeneratedTrackingIDForChangePasswordX(string trackingID)
        {
            _trackingID = trackingID;
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
            try {
                ChangePassword.Execute(_cmd, (x) => { });
                Assert.Fail("Shouldn't be here");
            }
            catch (Exception ex) {
                Assert.IsInstanceOfType(ex,
                    typeof(ValidationErrorException));
            }
        }

        [Then(@"Get null and skip checking trackingID for change password")]
        public void ThenGetNullAndSkipCheckingTrackingIDForChangePassword()
        {
            Assert.IsTrue(true, "Exception has been verified in the end of block When.");
        }

        [Then(@"TrackingID for change password should be :'(.*)'")]
        public void ThenTrackingIDForChangePasswordShouldBeX(string expectTrackingID)
        {
            Assert.AreEqual(expectTrackingID, _trackingID, "Get trackingID accept");
        }
    }
}
