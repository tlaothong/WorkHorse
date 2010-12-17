using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerfEx.Infrastructure.Validation;
using TheS.Casinova.PlayerAccount.Commands;
using TheS.Casinova.PlayerAccount.Models;

namespace TheS.Casinova.PlayerAccount.WebExecutors.Specs.Steps
{
    [Binding]
    public class CreatePlayerAccountSteps : PlayerAccountModuleStepsBase
    {
        private CreatePlayerAccountCommand _cmd;
        private string _trackingID;

        [Given(@"Sent player account information: UserName '(.*)' CardType'(.*)' AccountNo'(.*)' CVV'(.*)' ExpireDate'(.*)'")]
        public void GivenSentPlayerAccountInformationUserNameXCardTypeXAccountNoXCVVXExpireDateX(string userName, string cardType, string accountNo, string cvv, DateTime expireDate)
        {
            _cmd = new CreatePlayerAccountCommand {
                PlayerAccountInfo = new PlayerAccountInformation { 
                    UserName = userName,
                    CardType = cardType,
                    AccountNo = accountNo,
                    CVV = cvv,
                    ExpireDate = expireDate
                }
            };
        }

        [Given(@"The system generated TrackingID for CreatePlayerAccount :'(.*)'")]
        public void GivenTheSystemGeneratedTrackingIDForCreatePlayerAccountX(string trackingID)
        {
            _trackingID = trackingID;
        }

        //Validate
        [When(@"Call CreatePlayerAccountExecutor\(\) for validate input")]
        public void WhenCallCreatePlayerAccountExecutorForValidateInput()
        {
            try {
                CreatePlayerAccount.Execute(_cmd, (x) => { });
                Assert.Fail("Shouldn't be here");
            }
            catch (Exception ex) {
                Assert.IsInstanceOfType(ex,
                    typeof(ValidationErrorException));
            }
        }

        //Test function
        [When(@"Call CreatePlayerAccountExecutor\(\)")]
        public void WhenCallCreatePlayerAccountExecutor()
        {
                CreatePlayerAccount.Execute(_cmd, (x) => { });
        }

        [Then(@"Get null and skip checking trackingID")]
        public void ThenGetNullAndSkipCheckingTrackingID()
        {
            Assert.IsTrue(true, "Exception has been verified in the end of block When.");
        }

        [Then(@"TrackingID for CreatePlayerAccount should be : '(.*)'")]
        public void ThenTrackingIDForCreatePlayerAccountShouldBeX(string trackingID)
        {
            Assert.AreEqual(trackingID, _trackingID, "Get trackingID accept");
        }
    }
}
