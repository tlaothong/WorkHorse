using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace TheS.Casinova.ChipExchange.WebExecutors.Specs.Steps
{
    [Binding]
    public class ChipsToBonusChipsSteps : ChipsExchangeModuleStepsBase
    {
        [Given(@"Sent UserName'Boy' the player's bonus points for chips to bonus chips exchange should recieved")]
        public void GivenSentUserNameBoyThePlayerSBonusPointsForChipsToBonusChipsExchangeShouldRecieved()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"Sent UserName'Boy' the player's profile for chips to bonus chips exchange should recieved")]
        public void GivenSentUserNameBoyThePlayerSProfileForChipsToBonusChipsExchangeShouldRecieved()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"Server has bonus points information for chips to bonus chips exchange:")]
        public void GivenServerHasBonusPointsInformationForChipsToBonusChipsExchange(Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"Server has user profile information for chips to bonus chips:")]
        public void GivenServerHasUserProfileInformationForChipsToBonusChips(Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"Sent UserName'Boy' Amount '1000' for chips to bonus chips exchange")]
        public void GivenSentUserNameBoyAmount1000ForChipsToBonusChipsExchange()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"Call ChipsToBonusChipsExecutor\(\)")]
        public void WhenCallChipsToBonusChipsExecutor()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"The system can sent chips to bonus chips exchange information to back server")]
        public void ThenTheSystemCanSentChipsToBonusChipsExchangeInformationToBackServer()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
