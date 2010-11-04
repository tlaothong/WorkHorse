using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace TheS.Casinova.ChipExchange.WebExecutors.Specs.Steps
{
    [Binding]
    public class MoneyToChipsSteps
    {
       
        [Given(@"Server has player account information as:")]
        public void GivenServerHasPlayerAccountInformationAs(Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"Sent AccountType 'Primary' UserName'Boy' the player's account should recieve")]
        public void GivenSentAccountTypePrimaryUserNameBoyThePlayerSAccountShouldRecieve()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"The chips exchange information as :")]
        public void GivenTheChipsExchangeInformationAs(Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"Expected executed MoneyToChipsCommand")]
        public void GivenExpectedExecutedMoneyToChipsCommand()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"Call MoneyToChipsExecutor \(AccountType '(.*)' Amonut '(.*)' UserName'(.*)'\) for money to chips")]
        public void WhenCallMoneyToChipsExecutorAccountTypePrimaryAmonutUserNameBoyForMoneyToChips(string cardType, string amount, string userName)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"The system can sent chips exchange information to back server \#MoneyToChip")]
        public void ThenTheSystemCanSentChipsExchangeInformationToBackServerMoneyToChip()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"The system can't sent chips exchange information to back server \#MoneyToChip")]
        public void ThenTheSystemCanTSentChipsExchangeInformationToBackServerMoneyToChip()
        {
            ScenarioContext.Current.Pending();
        }
        
    }
}
