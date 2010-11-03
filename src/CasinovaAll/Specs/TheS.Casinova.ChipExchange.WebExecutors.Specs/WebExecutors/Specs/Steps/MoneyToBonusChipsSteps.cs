using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace TheS.Casinova.ChipExchange.WebExecutors.Specs.Steps
{
    [Binding]
    public class MoneyToBonusChipsSteps
    {
        

        [Given(@"Server has bonus point information as :")]
        public void GivenServerHasBonusPointInformationAs(Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"Server has player account information for money to bonus chips:")]
        public void GivenServerHasPlayerAccountInformationForMoneyToBonusChips(Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"The chips exchange information for money to bonus chips :")]
        public void GivenTheChipsExchangeInformationForMoneyToBonusChips(Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"Sent UserName'Boy' the player's bonus point should recieve")]
        public void GivenSentUserNameBoyThePlayerSBonusPointShouldRecieve()
        {
            ScenarioContext.Current.Pending();
        }


        [Given(@"Sent CardType 'Primary' UserName'Boy' the player's account for money to bonus chips should recieve")]
        public void GivenSentCardTypePrimaryUserNameBoyThePlayerSAccountForMoneyToBonusChipsShouldRecieve()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"Expected executed MoneyToBonusChipsCommand")]
        public void GivenExpectedExecutedMoneyToBonusChipsCommand()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"Call MoneyToBonusChipsExecutor \(CardType '(.*)' Amonut '(.*)' UserName'(.*)'\) for money to bonus chips")]
        public void WhenCallMoneyToBonusChipsExecutorCardTypePrimaryAmonut1000UserNameForMoneyToBonusChips(string cardType, string amount, string userName)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"The system can sent chips exchange information to back server \#MoneyToBonusChips")]
        public void ThenTheSystemCanSentChipsExchangeInformationToBackServerMoneyToBonusChips()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"The system can't sent chips exchange information to back server \#MoneyToBonusChips")]
        public void ThenTheSystemCanTSentChipsExchangeInformationToBackServerMoneyToBonusChips()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
