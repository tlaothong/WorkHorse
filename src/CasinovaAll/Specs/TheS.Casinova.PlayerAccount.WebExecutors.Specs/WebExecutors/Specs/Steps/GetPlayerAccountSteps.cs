using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace TheS.Casinova.PlayerAccount.WebExecutors.Specs.Steps
{
    [Binding]
    public class GetPlayerAccountSteps
    {
        [Given(@"Sent UserName 'Meaw'")]
        public void GivenSentUserNameMeaw()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"Call GetPlayerAccountExecutor")]
        public void WhenCallGetPlayerAccountExecutor()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"The result of get player account should be null")]
        public void ThenTheResultOfGetPlayerAccountShouldBeNull()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
