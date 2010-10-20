using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace TheS.Casinova.MagicNine.WebExecutors.Specs.Steps
{
    [Binding]
    public class ListGamePlayAutoBetInfoSteps
    {
        [Given(@"server has game play auto bet information as:")]
        public void GivenServerHasGamePlayAutoBetInformationAs(Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"Call ListGamePlayAutoBetInfoExecutor")]
        public void WhenCallListGamePlayAutoBetInfoExecutor()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"The GamePlayAutoBetInformation should be as :")]
        public void ThenTheGamePlayAutoBetInformationShouldBeAs(Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"The GamePlayAutoBetInformation should be null")]
        public void ThenTheGamePlayAutoBetInformationShouldBeNull()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
