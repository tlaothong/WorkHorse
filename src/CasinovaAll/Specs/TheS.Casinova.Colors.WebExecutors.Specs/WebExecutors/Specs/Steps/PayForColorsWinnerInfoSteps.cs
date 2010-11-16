using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Rhino.Mocks;
using TheS.Casinova.Colors.Commands;
using TheS.Casinova.Colors.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TheS.Casinova.Colors.WebExecutors.Specs.Steps
{
    [Binding]
    public class PayForColorsWinnerInfoSteps : ColorsGameStepsBase
    {
        [When(@"Call PayForColorsWinnerInfoExecutor\(userName '(.*)' GameRoundInfoRoundID '(.*)'\)")]
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
