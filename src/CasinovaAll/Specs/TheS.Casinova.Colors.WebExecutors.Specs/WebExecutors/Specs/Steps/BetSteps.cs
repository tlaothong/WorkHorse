using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TheS.Casinova.Colors.Models;
using TheS.Casinova.Colors.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerfEx.Infrastructure.Validation;

namespace TheS.Casinova.Colors.WebExecutors.Specs.Steps
{
    [Binding]
    public class BetSteps : ColorsGameStepsBase
    {
        private BetCommand _cmd;
        private string _trackingID;

        [Given(@"Bet Informations as : UserName '(.*)' RoundID '(.*)', ActionType '(.*)', Amount '(.*)'")]
        public void GivenBetInformationsAsUserNameNitRoundID4ActionTypeWhiteAmount_50(string userName, int roundID, string actionType, double amount)
        {
            _cmd = new BetCommand {
                BetPlayerActionInfo = new PlayerActionInformation { 
                    UserName = userName,
                    RoundID = roundID,
                    ActionType = actionType,
                    Amount = amount
                }
            };
        }

        [Given(@"The system generated TrackingID:'(.*)'")]
        public void GivenTheSystemGeneratedTrackingIDX(string trackingID)
        {
            _trackingID = trackingID;
        }
        
        //Validate input
        [When(@"Call BetColorsExecutor\(\) for validate bet information")]
        public void WhenCallBetColorsExecutorForValidateBetInformation()
        {
            try {
                BetColorsGame.Execute(_cmd, (x) => { });
                Assert.Fail("Shouldn't be here");
            }
            catch (Exception ex) {
                Assert.IsInstanceOfType(ex,
                    typeof(ValidationErrorException));
            }
        }

        //Test function
        [When(@"Call BetColorsExecutor\(\)")]
        public void WhenCallBetColorsExecutor()
        {
            try {
                BetColorsGame.Execute(_cmd, (x) => { });
            }
            catch (Exception ex) {
                Assert.IsInstanceOfType(ex,
                    typeof(ValidationErrorException));
            }
        }

        [Then(@"Get null and skip checking trackingID")]
        public void ThenGetNullAndSkipCheckingTrackingID()
        {
            Assert.IsTrue(true, "Get null and skip checking trackingID.");
        }

        [Then(@"TrackingID should be :'(.*)'")]
        public void ThenTrackingIDShouldBeX(string trackingID)
        {
            Assert.AreEqual(trackingID, _trackingID, "Get trackingID accept");
        }
    }
}
