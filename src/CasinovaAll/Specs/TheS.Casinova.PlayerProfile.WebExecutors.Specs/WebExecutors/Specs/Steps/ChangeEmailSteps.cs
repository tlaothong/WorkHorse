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
    public class ChangeEmailSteps : PlayerProfileModuleStepsBase
    {
        private ChangeEmailCommand _cmd;

        [Given(@"Sent UserName '(.*)' OldEmail '(.*)' NewEmail '(.*)'")]
        public void GivenSentUserNameXOldEmailXNewEmailXPasswordX(string userName, string oldEmail, string newEmail)
        {
            _cmd = new ChangeEmailCommand {
                UserProfile = new UserProfile { 
                    UserName = userName,
                    Email = oldEmail,
                    NewEmail = newEmail
                }
            };
        }

        [Given(@"Call membership service to validate change email information : UserName '(.*)' OldEmail '(.*)' NewEmail '(.*)'")]
        public void GivenCallMembershipServiceToValidateChangeEmailInformationUserNameXOldEmailXNewEmailX(string userName, string oldEmail, string newEmail)
        {
            Action<UserProfile> checkData = (userProfile) => {
                Assert.AreEqual(userName, userProfile.UserName, "UserName");
                Assert.AreEqual(oldEmail, userProfile.Email, "OldEmail");
                Assert.AreEqual(newEmail, userProfile.NewEmail, "NewEmail");
            };

            svc_Membership.ChangeEmail(new UserProfile());
            LastCall.IgnoreArguments().Do(checkData);
        }

        //Validation
        [When(@"Call ChangeEmailExecutor\(\) for validate input")]
        public void WhenCallChangeEmailExecutorForValidateInput()
        {
            try {
                ChangeEmail.Execute(_cmd, (x) => { });
                Assert.Fail("Shouldn't be here");
            }
            catch (Exception ex) {
                Assert.IsInstanceOfType(ex,
                    typeof(ValidationErrorException));
            }
        }

        //Test function
        [When(@"Call ChangeEmailExecutor\(\)")]
        public void WhenCallChangeEmailExecutor()
        {
           
            ChangeEmail.Execute(_cmd, (x) => { });        
        }

        [Then(@"Skip call membership service to change new email")]
        public void ThenSkipCallMembershipServiceToChangeNewEmail()
        {
            Assert.IsTrue(true, "Exception has been verified in the end of block When.");
        }

        [Then(@"Membership service can change new email")]
        public void ThenMembershipServiceCanChangeNewEmail()
        {
            Assert.IsTrue(true, "Membership has been verified in the end of block When.");
        }
    }
}
