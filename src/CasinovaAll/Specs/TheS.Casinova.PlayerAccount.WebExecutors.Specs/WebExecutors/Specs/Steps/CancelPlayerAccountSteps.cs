using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace TheS.Casinova.PlayerAccount.WebExecutors.Specs.Steps
{
    [Binding]
    public class CancelPlayerAccountSteps
    {
        [Given(@"Sent PlayerAccountID '-13'")]
        public void GivenSentPlayerAccountID_13()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"Call CancelPlayerAccountExecutor")]
        public void WhenCallCancelPlayerAccountExecutor()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"System can sent PlayerAccountID to backserver")]
        public void ThenSystemCanSentPlayerAccountIDToBackserver()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"System can't sent PlayerAccountID to backserver")]
        public void ThenSystemCanTSentPlayerAccountIDToBackserver()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
