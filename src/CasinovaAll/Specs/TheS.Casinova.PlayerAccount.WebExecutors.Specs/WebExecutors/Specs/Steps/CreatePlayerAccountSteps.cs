using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace TheS.Casinova.PlayerAccount.WebExecutors.Specs.Steps
{
    [Binding]
    public class CreatePlayerAccountSteps
    {
        [Given(@"Sent UserName 'Nit' AccountType'Visa' AccountNo'0012214544543212' CVV'3223' ExpireDate12/31/2005")]
        public void GivenSentUserNameNitAccountTypeVisaAccountNo0012214544543212CVV3223ExpireDate12312005()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"Call CreatePlayerAccountExecutor")]
        public void WhenCallCreatePlayerAccountExecutor()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"System can sent PlayerAccount to backserver")]
        public void ThenSystemCanSentPlayerAccountToBackserver()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"System can't sent PlayerAccount to backserver")]
        public void ThenSystemCanTSentPlayerAccountToBackserver()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
