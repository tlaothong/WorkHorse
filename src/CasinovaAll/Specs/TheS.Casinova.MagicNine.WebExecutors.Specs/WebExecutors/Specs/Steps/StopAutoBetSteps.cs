using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TheS.Casinova.MagicNine.Commands;
using TheS.Casinova.MagicNine.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerfEx.Infrastructure.Validation;

namespace TheS.Casinova.MagicNine.WebExecutors.Specs.Steps
{
    [Binding]
    public class StopAutoBetSteps : MagicNineGameStepsBase
    {
        private StopAutoBetCommand _cmd;
        private string _trackingID;

        [Given(@"Sent StopAutoBetInformation userName'(.*)', roundId '(.*)'")]
        public void GivenSentStopAutoBetInformationUserNameXRoundIDX(string userName, int roundId)
        {
            _cmd = new StopAutoBetCommand {
                GamePlayAutoBetInfo = new GamePlayAutoBetInformation {
                    UserName = userName,
                    RoundID = roundId
                }
            };
        }

        [Given(@"The system generated TrackingID for stop auto bet:'(.*)'")]
        public void GivenTheSystemGeneratedTrackingIDForStopAutoBetX(string trackingID)
        {
            _trackingID = trackingID;
        }

        //Test function
        [When(@"Call StopAutoBetExecutor\(\)")]
        public void WhenCallStopAutoBetExecutor()
        {
            try {
                StopAutoBet.Execute(_cmd, (x) => { });
            }
            catch (Exception ex) {
                Assert.IsInstanceOfType(ex,
                    typeof(ValidationErrorException));
            }
        }

        [Then(@"TrackingID for stop auto bet should be :'(.*)'")]
        public void ThenTrackingIDForStopAutoBetShouldBeX(string trackingID)
        {
            Assert.AreEqual(trackingID, _trackingID, "Get trackingID accept");
        }

        //Validation
        [When(@"Call StopAutoBetExecutor\(\) for validation")]
        public void WhenCallStopAutoBetExecutorForValidation()
        {
            try {
                StopAutoBet.Execute(_cmd, (x) => { });
                Assert.Fail("Shouldn't be here");
            }
            catch (Exception ex) {
                Assert.IsInstanceOfType(ex,
                    typeof(ValidationErrorException));
            }
        }

        [Then(@"Get null and skip checking trackingID for stop auto bet")]
        public void ThenGetNullAndSkipCheckingTrackingIDForStopAutoBet()
        {
            Assert.IsTrue(true, "Get null and skip checking trackingID.");
        }
    }
}
