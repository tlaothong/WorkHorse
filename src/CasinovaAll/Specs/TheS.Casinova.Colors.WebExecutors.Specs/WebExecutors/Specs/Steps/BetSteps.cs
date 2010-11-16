using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TheS.Casinova.Colors.Models;

namespace TheS.Casinova.Colors.WebExecutors.Specs.Steps
{
    [Binding]
    public class BetSteps : ColorsGameStepsBase
    {
        [When(@"Call BetColorsExecutor\(UserName '(.*)' RoundID '(.*)', ActionType '(.*)', Amount '(.*)'\)")]
        public void WhenCallBetColorsExecutorUserNameRoundIDXActionTypeXAmountX(string userName, int round, string actionType, double amount)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"The system can generate trckingID for bet colors game")]
        public void ThenTheSystemCanGenerateTrckingIDForBetColorsGame()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"The system can't generate trackingID for bet colors game")]
        public void ThenTheSystemCanTGenerateTrackingIDForBetColorsGame()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
