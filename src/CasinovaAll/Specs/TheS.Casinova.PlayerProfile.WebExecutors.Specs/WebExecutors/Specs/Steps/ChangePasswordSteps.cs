using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace TheS.Casinova.PlayerProfile.WebExecutors.Specs.Steps
{
    [Binding]
    public class ChangePasswordSteps
    {
        [Given(@"Server has password information of Nit :")]
        public void GivenServerHasPasswordInformationOfNit(Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"Sent UserName 'Nit' OldPassword '' NewPassword '<NewPassWord>'")]
        public void GivenSentUserNameNitOldPasswordNewPasswordNewPassWord()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"Call ChangePasswordExecutor")]
        public void WhenCallChangePasswordExecutor()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"The system can update new password")]
        public void ThenTheSystemCanUpdateNewPassword()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"The system can't update new password")]
        public void ThenTheSystemCanTUpdateNewPassword()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
