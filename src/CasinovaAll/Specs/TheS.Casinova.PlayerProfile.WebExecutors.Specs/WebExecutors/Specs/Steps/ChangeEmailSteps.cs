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
    public class ChangeEmailSteps : PlayerProfileModuleStepsBase
    {
        private ChangeEmailCommand _cmd;
        private string _trackingID;

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

        [Given(@"The system generated TrackingID for change email:'(.*)'")]
        public void GivenTheSystemGeneratedTrackingIDForChangeEmailX(string trackingID)
        {
            _trackingID = trackingID;
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
            try {
                ChangeEmail.Execute(_cmd, (x) => { });
                Assert.Fail("Shouldn't be here");
            }
            catch (Exception ex) {
                Assert.IsInstanceOfType(ex,
                    typeof(ValidationErrorException));
            }
        }

        [Then(@"Get null and skip checking trackingID for change email")]
        public void ThenGetNullAndSkipCheckingTrackingIDForChangeEmail()
        {
            Assert.IsTrue(true, "Exception has been verified in the end of block When.");
        }

        [Then(@"TrackingID for change email should be :'(.*)'")]
        public void ThenTrackingIDForChangeEmailShouldBeX(string expectTrackingID)
        {
            //Assert.AreEqual(expectTrackingID, _trackingID, "Get trackingID accept");
            ScenarioContext.Current.Pending();
        }
    }
}
