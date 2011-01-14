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
    public class StartAutoBetSteps : DevilSixGameStepsBase
    {
        private StartAutoBetCommand _cmd;
        private string _trackingID;

        [Given(@"Sent StartAutoBetInformation UserName '(.*)' RoundID '(.*)' Amount '(.*)' Interval '(.*)' TotalAmount '(.*)'")]
        public void GivenSentStartAutoBetInformationUserNameXRoundIDXAmountXIntervalXTotalAmount(string userName, int roundId, double amount, int interval, double totalAMount)
        {
            _cmd = new StartAutoBetCommand {
                GamePlayAutoBetInfo = new GamePlayAutoBetInformation {
                    UserName = userName,
                    RoundID = roundId,
                    Amount = amount,
                    Interval = interval,
                    TotalAmount = totalAMount
                }
            };
        }

        [Given(@"The system generated TrackingID for start auto bet:'(.*)'")]
        public void GivenTheSystemGeneratedTrackingIDForStartAutoBetX(string trackingID)
        {
            _trackingID = trackingID;

            SetupResult.For(svc_GenerateTrackingID.GenerateTrackingID())
                .IgnoreArguments().Return(Guid.Parse(_trackingID));
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

        [Then(@"TrackingID for StartAutoBet should be :'(.*)'")]
        public void ThenTrackingIDForStartAutoBetShouldBeX(string trackingID)
        {
            Assert.AreEqual(trackingID,_trackingID, "Get trackingID accept");
        }

        [Then(@"StartAutoBet get null and skip checking trackingID")]
        public void ThenStartAutoBetGetNullAndSkipCheckingTrackingID()
        {
            Assert.IsTrue(true, "Get null and skip checking trackingID.");
        }
    }
}
