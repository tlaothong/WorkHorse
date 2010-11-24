using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace TheS.Casinova.PlayerProfile.WebExecutors.Specs.Steps
{
    [Binding]
    public class RegisterUserSteps
    {
        [Given(@"Server has UserName information as:")]
        public void GivenServerHasUserNameInformationAs(Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"Sent UserName 'OhAe' Password'1234' Email'sirinarin@hotmail\.com' CellPhone'0892165437' Upline'Tummy'")]
        public void GivenSentUserNameOhAePassword1234EmailSirinarinHotmail_ComCellPhone0892165437UplineTummy()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"Call RegisterUserExecutor")]
        public void WhenCallRegisterUserExecutor()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"The server can sent RegisterUser information")]
        public void ThenTheServerCanSentRegisterUserInformation()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"The server can't sent RegisterUser information")]
        public void ThenTheServerCanTSentRegisterUserInformation()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
