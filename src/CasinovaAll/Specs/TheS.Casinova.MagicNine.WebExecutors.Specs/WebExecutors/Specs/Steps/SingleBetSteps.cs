using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace TheS.Casinova.MagicNine.WebExecutors.Specs.Steps
{
    [Binding]
    public class SingleBetSteps
    {
        [Given(@"Web service has TrackingID : 'DA1FE75E-9042-4FC5-B3CF-1E973D2152F7'")]
        public void GivenWebServiceHasTrackingIDDA1FE75E_9042_4FC5_B3CF_1E973D2152F7()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"Expect execute SingleBetCommand")]
        public void GivenExpectExecuteSingleBetCommand()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"Call SingleBetExecutor\(userName'Nit', roundId '1'\)")]
        public void WhenCallSingleBetExecutorUserNameNitRoundId1()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"TrackingID for client and back server should be : 'DA1FE75E-9042-4FC5-B3CF-1E973D2152F7'")]
        public void ThenTrackingIDForClientAndBackServerShouldBeDA1FE75E_9042_4FC5_B3CF_1E973D2152F7()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"TrackingID for client and back server should be null")]
        public void ThenTrackingIDForClientAndBackServerShouldBeNull()
        {
            ScenarioContext.Current.Pending();
        }

    }
}
