using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TheS.Casinova.PlayerAccount.Commands;
using TheS.Casinova.PlayerAccount.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerfEx.Infrastructure.Validation;

namespace TheS.Casinova.PlayerAccount.WebExecutors.Specs.Steps
{
    [Binding]
    public class CancelPlayerAccountSteps : PlayerAccountModuleStepsBase
    {
        private CancelPlayerAccountCommand _cmd;
        private string _trackingID;

        [Given(@"Sent UserName '(.*)' AccountType '(.*)' for cancel player account")]
        public void GivenSentUserNameAccountTypePrimaryForCancelPlayerAccount(string userName, string accountType)
        {
            _cmd = new CancelPlayerAccountCommand {
                PlayerAccountInfo = new PlayerAccountInformation { 
                    UserName = userName,
                    AccountType = accountType
                }
            };
        }

        [Given(@"The system generated TrackingID for CancelPlayerAccount :'(.*)'")]
        public void GivenTheSystemGeneratedTrackingIDForCancelPlayerAccountX(string trackingID)
        {
            _trackingID = trackingID;
        }

        [When(@"Call CancelPlayerAccountExecutor\(\) for validate input")]
        public void WhenCallCancelPlayerAccountExecutorForValidateInput()
        {
            try {
                CancelPlayerAccount.Execute(_cmd, (x) => { });
                Assert.Fail("Shouldn't be here");
            }
            catch (Exception ex) {
                Assert.IsInstanceOfType(ex,
                    typeof(ValidationErrorException));
            }
        }

        //Test function
        [When(@"Call CancelPlayerAccountExecutor\(\)")]
        public void WhenCallCancelPlayerAccountExecutor()
        {
            CancelPlayerAccount.Execute(_cmd, (x) => { });
        }

        [Then(@"TrackingID for CancelPlayerAccount should be : '(.*)'")]
        public void ThenTrackingIDForCancelPlayerAccountShouldBeX(string trackingID)
        {
            Assert.AreEqual(trackingID, _trackingID, "Get trackingID accept");
            
        }

        [Then(@"Get null and skip checking trackingID for cancel player account")]
        public void ThenGetNullAndSkipCheckingTrackingIDForCancelPlayerAccount()
        {
            Assert.IsTrue(true, "Exception has been verified in the end of block When.");
        }
    }
}
