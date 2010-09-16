using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Rhino.Mocks;

namespace ColorsGame.Specs.Steps {
    [Binding]
    public class RequestGamePlayInfoStep {

        private string _username;
        MockRepository Mocks { get { return SpecEventDefinitions.Mocks; } }

        [Given(@"I have enter username '(.*)'")]
        public void GivenIHaveEnterUsernameTitleUpz(string username) {
            _username = username;
        }

        [When(@"execute GetGamePlayInformation")]
        public void WhenExecuteGetGamePlayInformation() {
            ScenarioContext.Current.Pending();
        }

        [Then(@"Send request to server")]
        public void ThenSendRequestToServer() {
           
        }
    }
}
