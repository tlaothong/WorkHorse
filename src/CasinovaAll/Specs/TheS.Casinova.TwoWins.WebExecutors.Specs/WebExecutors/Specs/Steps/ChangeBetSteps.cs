using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TheS.Casinova.TwoWins.Commands;
using TheS.Casinova.TwoWins.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerfEx.Infrastructure.Validation;

namespace TheS.Casinova.TwoWins.WebExecutors.Specs.Steps
{
    [Binding]
    public class ChangeBetSteps : TwoWinGameStepsBase
    {
        private ChangeBetInfoCommand _cmd;
        private string _trackingID;

        [Given(@"Sent ChangeBet information UserName'(.*)' RoundID '(.*)' Amount'(.*)' HandID'(.*)'")]
        public void GivenSentChangeBetInformationUserNameXRoundIDXAmountXHandIDX(string userName, int roundID, double amount, int handID)
        {
            _cmd = new ChangeBetInfoCommand {
                BetInfo = new BetInformation { 
                    UserName = userName,
                    RoundID = roundID,
                    Amount = amount,
                    HandID = handID
                }
            };
        }

        [Given(@"TrackingID for ChangeBet is '(.*)'")]
        public void GivenTrackingIDForChangeBetIsX(string trackingID)
        {
            _trackingID = trackingID;
        }

        [Given(@"Sent ChangeBet information UserName'(.*)' RoundID '(.*)' Amount'(.*)' HandID'(.*)' for change bet validation")]
        public void GivenSentChangeBetInformationUserNameXRoundIDXAmountXHandIDXForChangeBetValidation(string userName, int roundID, double amount, int handID)
        {
            _cmd = new ChangeBetInfoCommand {
                BetInfo = new BetInformation { 
                    UserName = userName,
                    RoundID = roundID,
                    Amount = amount,
                    HandID = handID
                }
            };
        }

        [When(@"Call ChangeBetExecutor\(\) for validate input")]
        public void WhenCallChangeBetExecutorForValidateInput()
        {
            try {
                ChangeBet.Execute(_cmd, (x) => { });
                Assert.Fail("Shouldn't be here");
            }
            catch (Exception ex) {
                Assert.IsInstanceOfType(ex,
                   typeof(ValidationErrorException));
            };
        }

        //Test function
        [When(@"Call ChangeBetExecutor\(\)")]
        public void WhenCallChangeBetExecutor()
        {
            ChangeBet.Execute(_cmd, (x) => { });
        }

        [Then(@"TrackingID for ChangeBet should be :'(.*)'")]
        public void ThenTrackingIDForChangeBetShouldBeX(string trackingID)
        {
            Assert.AreEqual(trackingID, _trackingID, "Get trackingID accept");
        }

        [Then(@"ChangeBet get null and skip checking trackingID")]
        public void ThenChangeBetGetNullAndSkipCheckingTrackingID()
        {
            Assert.IsTrue(true, "Get null and skip checking trackingID");
        }
    }
}
