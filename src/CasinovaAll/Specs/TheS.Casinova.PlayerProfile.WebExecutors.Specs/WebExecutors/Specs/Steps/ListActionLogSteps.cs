using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace TheS.Casinova.PlayerProfile.WebExecutors.Specs.Steps
{
    [Binding]
    public class ListActionLogSteps
    {
        [Given(@"Server has action log information as:")]
        public void GivenServerHasActionLogInformationAs(Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"Sent UserName: 'OhAe'")]
        public void GivenSentUserNameOhAe()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"Call ListActionLogExecutor")]
        public void WhenCallListActionLogExecutor()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"Action log information should be :")]
        public void ThenActionLogInformationShouldBe(Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"Action log information should be null")]
        public void ThenActionLogInformationShouldBeNull()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
