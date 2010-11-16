using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Rhino.Mocks;
using TheS.Casinova.TwoWins.Commands;
using TheS.Casinova.TwoWins.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TheS.Casinova.TwoWins.WebExecutors.Specs.Steps
{
    [Binding]
    public class PayForColorsWinnerInfoSteps : ColorsGameStepsBase
    {
        [When(@"Call PayForColorsWinnerInfoExecutor\(userName '(.*)' RoundID '(.*)'\)")]
        public void WhenCallPayForColorsWinnerInfoExecutorUserNameXRoundIDX(string userName, int roundID)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"The system can generate trckingID for pay colors winner information")]
        public void ThenTheSystemCanGenerateTrckingIDForPayColorsWinnerInformation()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"The system can't generate trackingID for  pay colors winner information")]
        public void ThenTheSystemCanTGenerateTrackingIDForPayColorsWinnerInformation()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
