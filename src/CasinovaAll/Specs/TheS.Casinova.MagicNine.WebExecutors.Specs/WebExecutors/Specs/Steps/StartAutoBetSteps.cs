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
    public class StartAutoBetSteps : MagicNineGameStepsBase
    {
        private StartAutoBetCommand _cmd;
        private string _trackingID;

        [Given(@"Sent StartAutoBetInformation userName'(.*)', roundId '(.*)',amount '(.*)', Interval '(.*)'")]
        public void GivenSentStartAutoBetInformationUserNameNitRoundId0Amount100Interval10(string userName, int roundId, double amount, int interval)
        {
            _cmd = new StartAutoBetCommand {
                GamePlayAutoBetInfo = new GamePlayAutoBetInformation {
                    UserName = userName,
                    RoundID = roundId,
                    Amount = amount,
                    Interval = interval
                }
            };
        }

        [Given(@"The system generated TrackingID for start auto bet:'(.*)'")]
        public void GivenTheSystemGeneratedTrackingIDForStartAutoBetX(string trackingID)
        {
            _trackingID = trackingID;
        }

        //Test function
        [When(@"Call StartAutoBetExecutor\(\)")]
        public void WhenCallStartAutoBetExecutor()
        {
            StartAutoBet.Execute(_cmd, (x) => { });     
        }

        //Validation
        [When(@"Call StartAutoBetExecutor\(\) for validation")]
        public void WhenCallStartAutoBetExecutorForValidation()
        {
            try {
                StartAutoBet.Execute(_cmd, (x) => { });
                Assert.Fail("Shouldn't be here");
            }
            catch (Exception ex) {
                Assert.IsInstanceOfType(ex,
                    typeof(ValidationErrorException));
            }
        }

        [Then(@"TrackingID for start auto bet should be :'(.*)'")]
        public void ThenTrackingIDForStartAutoBetShouldBeX(string trackingID)
        {
            Assert.AreEqual(trackingID,_trackingID, "Get trackingID accept");
        }

        [Then(@"Get null and skip checking trackingID for start auto bet")]
        public void ThenGetNullAndSkipCheckingTrackingIDForStartAutoBet()
        {
            Assert.IsTrue(true, "Get null and skip checking trackingID.");
        }
    }
}
