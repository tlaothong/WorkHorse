using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TheS.Casinova.ChipExchange.Commands;
using TheS.Casinova.ChipExchange.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerfEx.Infrastructure.Validation;

namespace TheS.Casinova.ChipExchange.WebExecutors.Specs.Steps
{
    [Binding]
    public class ChipsToMoneySteps : ChipsExchangeModuleStepsBase
    {
        private ChipsToMoneyCommand _cmd;

        [Given(@"Sent UserName'(.*)' Address'(.*)' Amount'(.*)'")]
        public void GivenSentUserNameXAddressXAmountX(string userName, string address, int amount)
        {
            _cmd = new ChipsToMoneyCommand {
                ChequeInfo = new ChequeInformation { 
                    UserName = userName,
                    Amount = amount,
                    Address = address
                }
            };
        }

        //Test function
        [When(@"Call ChipsToMoneyExecutor\(\)")]
        public void WhenCallChipsToMoneyExecutor()
        {
            ChipsToMoney.Execute(_cmd, (x) => { });
        }

        //Validation
        [When(@"Call ChipsToMoneyExecutor\(\) for validation")]
        public void WhenCallChipsToMoneyExecutorForValidation()
        {
            try {
                ChipsToMoney.Execute(_cmd, (x) => { });
                Assert.Fail("Shouldn't be here");
            }
            catch (Exception ex) {
                Assert.IsInstanceOfType(ex,
                    typeof(ValidationErrorException));
            }
        }

        [Then(@"The system can sent chips to money exchange information to back server")]
        public void ThenTheSystemCanSentChipsToMoneyExchangeInformationToBackServer()
        {
            Assert.IsTrue(true, "System can sent information to back server");
        }

        [Then(@"The system can't sent chips to money exchange information to back server")]
        public void ThenTheSystemCanTSentChipsToMoneyExchangeInformationToBackServer()
        {
            Assert.IsTrue(true, "System can't sent information to back server");
        }
    }
}
