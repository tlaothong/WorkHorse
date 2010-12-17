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
    public class EditPlayerAccountSteps : PlayerAccountModuleStepsBase
    {
        private EditPlayerAccountCommand _cmd;
        private string _trackingID;

        [Given(@"Sent UserName '(.*)' AccountType'(.*)' CardType'(.*)' AccountNo'(.*)' CVV'(.*)' ExpireDate'(.*)'")]
        public void GivenSentUserNameNitAccountTypeCardTypeVisaAccountNo0012214544543212CVV3223ExpireDate12312011(string userName, string accountType, string cardType, string accountNo, string cvv, DateTime expireDate)
        {
            _cmd = new EditPlayerAccountCommand {
                PlayerAccountInfo = new PlayerAccountInformation {
                    UserName = userName,
                    AccountType = accountType,
                    CardType = cardType,
                    AccountNo = accountNo,
                    CVV = cvv,
                    ExpireDate = expireDate
                }
            };
        }

        [Given(@"The system generated TrackingID for EditPlayerAccount :'(.*)'")]
        public void GivenTheSystemGeneratedTrackingIDForEditPlayerAccountX(string trackingID)
        {
            _trackingID = trackingID;
        }

        //validation
        [When(@"Call EditPlayerAccountExecutor\(\) for validate input")]
        public void WhenCallEditPlayerAccountExecutorForValidateInput()
        {
            try {
                 EditPlayerAccount.Execute(_cmd, (x) => { });
                Assert.Fail("Shouldn't be here");
            }
            catch (Exception ex) {
                Assert.IsInstanceOfType(ex,
                    typeof(ValidationErrorException));
            }
        }

        //Test function
        [When(@"Call EditPlayerAccountExecutor\(\)")]
        public void WhenCallEditPlayerAccountExecutor()
        {
            EditPlayerAccount.Execute(_cmd, (x) => { });
        }

        [Then(@"Get null and skip checking trackingID for edit player account")]
        public void ThenGetNullAndSkipCheckingTrackingIDForEditPlayerAccount()
        {
            Assert.IsTrue(true, "Exception has been verified in the end of block When.");
        }

        [Then(@"TrackingID for EditPlayerAccount should be : '(.*)'")]
        public void ThenTrackingIDForEditPlayerAccountShouldBeX(string trackingID)
        {
            Assert.AreEqual(trackingID, _trackingID, "Get trackingID accept");
        }
       
    }
}
