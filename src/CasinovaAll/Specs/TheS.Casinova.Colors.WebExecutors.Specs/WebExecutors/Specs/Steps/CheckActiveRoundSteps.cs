using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace TheS.Casinova.TwoWins.WebExecutors.Specs.Steps
{
    [Binding]
    public class CheckActiveRoundSteps
    {
        [Given(@"Active round has'(.*)', Expect active round '(.*)'")]
        public void GivenActiveRoundHas6ExpectActiveRound5(int activeRound, int expectActiveRound)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"Execute CheckActiveRoundToCreateCommand")]
        public void WhenExecuteCheckActiveRoundToCreateCommand()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"The system sent command to back server")]
        public void ThenTheSystemSentCommandToBackServer()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"The system don't add ActiveRound")]
        public void ThenTheSystemDonTAddActiveRound()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
