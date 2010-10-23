using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace TheS.Casinova.PlayerProfile.WebExecutors.Specs.Steps
{
    [Binding]
    public class GetUserProfileSteps
    {
        [Given(@"Server has user profile information as:")]
        public void GivenServerHasUserProfileInformationAs(Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"Sent UserName: 'OhAe'")]
        public void GivenSentUserNameOhAe()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"Call GetUserProfileExecutor")]
        public void WhenCallGetUserProfileExecutor()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"User Profile information should be :")]
        public void ThenUserProfileInformationShouldBe(Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"User Profile information should be null")]
        public void ThenUserProfileInformationShouldBeNull()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
