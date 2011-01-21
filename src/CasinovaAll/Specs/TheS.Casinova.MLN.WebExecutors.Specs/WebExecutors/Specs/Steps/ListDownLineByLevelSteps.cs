using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace TheS.Casinova.MLN.WebExecutors.Specs.Steps
{
    [Binding]
    public class ListDownLineByLevelSteps
    {
        [Given(@"Sent UserName'(.*)'")]
        public void GivenSentUserNameX(string userName)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"Call ListDownLineBylavelExecutor\(\)")]
        public void WhenCallListDownLineBylavelExecutor()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"DowwnLineLevel1 information should be as:")]
        public void ThenDowwnLineLevel1InformationShouldBeAs(Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"DowwnLineLevel2 information should be as:")]
        public void ThenDowwnLineLevel2InformationShouldBeAs(Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"DowwnLineLevel3 information should be as:")]
        public void ThenDowwnLineLevel3InformationShouldBeAs(Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"Call ListDownLineBylavelExecutor\(\)")]
        public void WhenCallListDownLineBylavelExecutor()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
