using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace TheS.Casinova.ChipExchange.WebExecutors.Specs
{
    [Binding]
    public class PayVoucherSteps
    {
        [Given(@"Server has user profile information for pay voucher:")]
        public void GivenServerHasUserProfileInformationForPayVoucher(Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"Sent UserName'(.*)' the player's profile should recieved")]
        public void GivenSentUserNameNitThePlayerSProfileShouldRecieve(string userName)
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"Sent UserName'Noy' the player's profile should recieved null")]
        public void GivenSentUserNameNoyThePlayerSProfileShouldRecievedNull()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"Expected executed PayVoucherCommand")]
        public void GivenExpectedExecutedPayVoucherCommand()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"Call PaVoucherExecutor\(UserName'(.*)', Amount'(.*)'\)")]
        public void WhenCallPaVoucherExecutorUserNameNitAmount500(string userName, double amount)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"The system can sent information to back server \#PayVoucher")]
        public void ThenTheSystemCanSentInformationToBackServerPayVoucher()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"The system can't sent information to back server \#PayVoucher")]
        public void ThenTheSystemCanTSentInformationToBackServerPayVoucher()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
