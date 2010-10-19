using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace TheS.Casinova.Colors.WebExecutors.Specs.Steps
{
    [Binding]
    public class CreateGameRoundConfigSteps
    {
        [When(@"Call Create\(Name'(.*)',TableAmount'(.*)', GameDuration'(.*)', Interval'(.*)'\)")]
        public void WhenCallCreateNameTableAmount5GameDurationGameDurationInterval10(string name, int tableAmount, int gameDuration, int interval)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"The system can sent GameRoundConfigurations to back server")]
        public void ThenTheSystemCanSentGameRoundConfigurationsToBackServer()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"The system can't sent GameRoundConfigurations to back server")]
        public void ThenTheSystemCanTSentGameRoundConfigurationsToBackServer()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
