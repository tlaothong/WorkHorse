using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace TheS.Casinova.PlayerProfile.WebExecutors.Specs.Steps
{
    [Binding]
    public class ChangeEmailSteps
    {
        [Given(@"Server has email information of Nit :")]
        public void GivenServerHasEmailInformationOfNit(Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"Sent UserName 'Nit' OldEmail 'nayit_nit@hotmail\.com' NewEmail ''")]
        public void GivenSentUserNameNitOldEmailNayit_NitHotmail_ComNewEmail()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"Call ChangeEmailExecutor")]
        public void WhenCallChangeEmailExecutor()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"The system can update new email")]
        public void ThenTheSystemCanUpdateNewEmail()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"The system can't update new email")]
        public void ThenTheSystemCanTUpdateNewEmail()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
