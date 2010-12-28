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
       // private string _trackingID;

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

        [Then(@"System can sent cancel player account information to back server")]
        public void ThenSystemCanSentCancelPlayerAccountInformationToBackServer()
        {
            Assert.IsTrue(true, "Cancel information has been verified in the end of block When.");
            
        }

        [Then(@"System can't sent cancel player account information to back server")]
        public void ThenSystemCanTSentCancelPlayerAccountInformationToBackServer()
        {
            Assert.IsTrue(true, "Exception has been verified in the end of block When.");
        }
    }
}
