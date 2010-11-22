using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace TheS.Casinova.MagicNine.WebExecutors.Specs.Steps
{
    [Binding]
    public class StartAutoBetSteps
    {
        [Given(@"Sent StartAutoBetInformation userName'(.*)', roundId '(.*)',amount '(.*)', Interval '(.*)'")]
        public void GivenSentStartAutoBetInformationUserNameNitRoundId0Amount100Interval10(string userName, int roundId, int amount, int interval)
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"Web service has BetTrackingID for start auto bet: 'DA1FE75E-9042-4FC5-B3CF-1E973D2152F7'")]
        public void GivenWebServiceHasTrackingIDForStartAutoBetDA1FE75E_9042_4FC5_B3CF_1E973D2152F7()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"Call StartAutoBetExecutor\(userName'(.*)', roundId '(.*)',amount '(.*)', Interval '(.*)'\)")]
        public void WhenCallStartAutoBetExecutorUserNameNitRoundId0Amount100Interval10(string userName, int roundId, int amount, int interval)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"BetTrackingID of  start auto bet for client and back server should be : 'DA1FE75E-9042-4FC5-B3CF-1E973D2152F7'")]
        public void ThenTrackingIDOfStartAutoBetForClientAndBackServerShouldBeDA1FE75E_9042_4FC5_B3CF_1E973D2152F7()
        {
            ScenarioContext.Current.Pending();
        }

         [Then(@"The system can't sent StartAutoBetInformation to back server")]
         public void ThenTheSystemCanTSentStartAutoBetInformationToBackServer()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
