using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace TheS.Casinova.MagicNine.WebExecutors.Specs.Steps
{
    [Binding]
    public class ListBetLogSteps
    {
        [Given(@"server has player information as:")]
        public void GivenServerHasPlayerInformationAs(Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"Expect execute ListBetLogCommand")]
        public void GivenExpectExecuteListBetLogCommand()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"Call ListBetLogExecutor\(userName'(.*)', roundId '(.*)'\)")]
        public void WhenCallListBetLogExecutorUserNameNitRoundId1(string usernmae, int roundId)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"The result of BetLog should be :")]
        public void ThenTheResultOfBetLogShouldBe(Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"The result of BetLog should be null")]
        public void ThenTheResultOfBetLogShouldBeNull()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
