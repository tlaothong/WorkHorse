using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace TheS.Casinova.PlayerAccount.WebExecutors.Specs.Steps
{
    [Binding]
    public class ListPlayerAccountSteps
    {
        [Given(@"Server has player account information as:")]
        public void GivenServerHasPlayerAccountInformationAs(Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"Sent UserName ''")]
        public void GivenSentUserName()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"Call ListPlayerAccountExecutor")]
        public void WhenCallListPlayerAccountExecutor()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"The result of player account should be as:")]
        public void ThenTheResultOfPlayerAccountShouldBeAs(Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"The result of player account should be null")]
        public void ThenTheResultOfPlayerAccountShouldBeNull()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
