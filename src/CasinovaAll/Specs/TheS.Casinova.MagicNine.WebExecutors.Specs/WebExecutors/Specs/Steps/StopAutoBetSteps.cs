using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace TheS.Casinova.MagicNine.WebExecutors.Specs.Steps
{
    [Binding]
    public class StopAutoBetSteps
    {
        [Given(@"Sent StopAutoBetInformation userName'(.*)'")]
        public void GivenSentStopAutoBetInformationUserNameNit(string userName)
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"Web service has TrackingID for stop auto bet: 'DA1FE75E-9042-4FC5-B3CF-1E973D2152F7'")]
        public void GivenWebServiceHasTrackingIDForStopAutoBetDA1FE75E_9042_4FC5_B3CF_1E973D2152F7()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"Call StopAutoBetExecutor\(userName'Nit'\)")]
        public void WhenCallStopAutoBetExecutorUserNameNit()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"The system can't sent StopAutoBetInformation to back server")]
        public void ThenTheSystemCanTSentStopAutoBetInformationToBackServer()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"TrackingID of  stop auto bet for client and back server should be : 'DA1FE75E-9042-4FC5-B3CF-1E973D2152F7'")]
        public void ThenTrackingIDOfStopAutoBetForClientAndBackServerShouldBeDA1FE75E_9042_4FC5_B3CF_1E973D2152F7()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
