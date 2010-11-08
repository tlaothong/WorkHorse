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
        [Given(@"Server has bonus points information for money to bonus chips exchange:")]
        public void GivenServerHasBonusPointsInformationForMoneyToBonusChipsExchange(Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"Server has player account information for money to bonus chips exchange:")]
        public void GivenServerHasPlayerAccountInformationForMoneyToBonusChipsExchange(Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"The chips exchange information for money to bonus chips exchange:")]
        public void GivenTheChipsExchangeInformationForMoneyToBonusChipsExchange(Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"Sent UserName'Boy' the player's bonus points should recieved")]
        public void GivenSentUserNameBoyThePlayerSBonusPointShouldRecieve()
        {
            ScenarioContext.Current.Pending();
        }


        [Given(@"Sent AccountType 'Primary' UserName'Boy' the player's account for money to bonus chips should recieved")]
        public void GivenSentAccountTypePrimaryUserNameBoyThePlayerSAccountForMoneyToBonusChipsShouldRecieve()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"Expected executed MoneyToBonusChipsCommand")]
        public void GivenExpectedExecutedMoneyToBonusChipsCommand()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"Call MoneyToBonusChipsExecutor \(AccountType '(.*)' Amonut '(.*)' UserName'(.*)'\) for money to bonus chips")]
        public void WhenCallMoneyToBonusChipsExecutorAccountTypePrimaryAmonut1000UserNameForMoneyToBonusChips(string cardType, string amount, string userName)
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
