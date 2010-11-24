using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace TheS.Casinova.PlayerAccount.WebExecutors.Specs.Steps
{
    [Binding]
    public class EditPlayerAccountSteps
    {
        [Given(@"Sent UserName 'Nit' AccountType'Visa' AccountNo'0012214544543212' CVV'3' ExpireDate12/31/2010")]
        public void GivenSentUserNameNitAccountTypeVisaAccountNo0012214544543212CVV3ExpireDate12312010()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"Call EditPlayerAccountExecutor")]
        public void WhenCallEditPlayerAccountExecutor()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"System can edit PlayerAccount to backserver")]
        public void ThenSystemCanEditPlayerAccountToBackserver()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"System can't edit PlayerAccount to backserver")]
        public void ThenSystemCanTEditPlayerAccountToBackserver()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
