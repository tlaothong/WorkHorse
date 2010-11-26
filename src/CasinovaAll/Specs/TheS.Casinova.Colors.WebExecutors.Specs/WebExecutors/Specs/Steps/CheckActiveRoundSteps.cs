using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TheS.Casinova.Colors.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerfEx.Infrastructure.Validation;

namespace TheS.Casinova.Colors.WebExecutors.Specs.Steps
{
    [Binding]
    public class CheckActiveRoundSteps : ColorsGameStepsBase
    {
        private CheckActiveRoundToCreateCommand _cmd;

        [Given(@"Sent name '(.*)' to server")]
        public void GivenSentNameGameToServer(string name)
        {
            _cmd = new CheckActiveRoundToCreateCommand {
                GameRoundConfigName = new Models.GameRoundConfiguration {
                 ConfigName = name
                }
            };
        }

        [When(@"Call CheckActiveRoundExecutor\(\)")]
        public void WhenCallCheckActiveRoundExecutor()
        {
            try {
                CheckActiveRound.Execute(_cmd, (x) => { });
                Assert.Fail("Shouldn't be here");
            }
            catch (Exception ex) {
                Assert.IsInstanceOfType(ex,
                    typeof(ValidationErrorException));
            }

        }

        [Then(@"The system don't add ActiveRound")]
        public void ThenTheSystemDonTAddActiveRound()
        {
            Assert.IsTrue(true, "Check exception from WhenBlock");
        }
    }
}
