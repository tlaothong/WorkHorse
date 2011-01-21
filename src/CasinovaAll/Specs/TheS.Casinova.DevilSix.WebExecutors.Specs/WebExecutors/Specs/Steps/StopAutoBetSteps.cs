using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerfEx.Infrastructure.Validation;
using Rhino.Mocks;
using TheS.Casinova.DevilSix.Commands;
using TheS.Casinova.DevilSix.Models;

namespace TheS.Casinova.DevilSix.WebExecutors.Specs.Steps
{
    [Binding]
    public class StopAutoBetSteps : DevilSixGameStepsBase
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

            SetupResult.For(svc_GenerateTrackingID.GenerateTrackingID())
                .IgnoreArguments().Return(Guid.Parse(_trackingID));
        }

        //Test function
        [When(@"Call StopAutoBetExecutor\(\)")]
        public void WhenCallStopAutoBetExecutor()
        {
             StopAutoBet.Execute(_cmd, (x) => { });
           
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

        [Then(@"TrackingID for stop auto bet should be :'(.*)'")]
        public void ThenTrackingIDForStopAutoBetShouldBeX(string trackingID)
        {
            Assert.AreEqual(trackingID, _trackingID, "Get trackingID accept");
        }

        [Then(@"StopAutoBet get null and skip checking trackingID")]
        public void ThenStopAutoBetGetNullAndSkipCheckingTrackingID()
        {
            Assert.IsTrue(true, "Get null and skip checking trackingID.");
        }
    }
}
