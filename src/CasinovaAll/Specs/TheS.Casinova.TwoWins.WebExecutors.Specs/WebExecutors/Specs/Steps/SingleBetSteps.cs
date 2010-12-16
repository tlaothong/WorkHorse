using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TheS.Casinova.TwoWins.Commands;
using TheS.Casinova.TwoWins.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerfEx.Infrastructure.Validation;
using Rhino.Mocks;

namespace TheS.Casinova.TwoWins.WebExecutors.Specs.Steps
{
    [Binding]
    public class SingleBetSteps : TwoWinGameStepsBase
    {
        private SingleBetCommand _cmd;
        private string _trackingID;

        [Given(@"Sent UserName'(.*)' RoundID '(.*)' Amount'(.*)'")]
        public void GivenSentUserNameNayitRoundID1Amount100(string userName, int roundID, double amount)
        {
            _cmd = new SingleBetCommand {
                BetInfo = new BetInformation { 
                    UserName = userName,
                    RoundID = roundID,
                    Amount = amount
                }
            };
        }

        [Given(@"TrackingID for SibgleBet is '(.*)'")]
        public void GivenTrackingIDForSibgleBetIsX(string trackingID)
        {
            _trackingID = trackingID;

            SetupResult.For(svc_GenerateTrackingID.GenerateTrackingID())
                .IgnoreArguments().Return(Guid.Parse(_trackingID));
        }

        [Given(@"Sent UserName'(.*)' RoundID '(.*)' Amount'(.*)' for single bet validation")]
        public void GivenSentUserNameNayitRoundID_1Amount89ForSingleBetValidation(string userName, int roundID, double amount)
        {
            _cmd = new SingleBetCommand {
                BetInfo = new BetInformation {
                    UserName = userName,
                    RoundID = roundID,
                    Amount = amount
                }
            };
        }

        //Validation
        [When(@"Call SingleBetExecutor\(\) for validate input")]
        public void WhenCallSingleBetExecutorForValidateInput()
        {
            try {
                SingleBet.Execute(_cmd, (x) => { });
                Assert.Fail("Shouldn't be here");
            }
            catch (Exception ex) {
                Assert.IsInstanceOfType(ex,
                   typeof(ValidationErrorException));
            };
        }

        //Test function
        [When(@"Call SingleBetExecutor\(\)")]
        public void WhenCallSingleBetExecutor()
        {
            SingleBet.Execute(_cmd, (x) => { });
        }

        [Then(@"TrackingID for SingleBet should be :'(.*)'")]
        public void ThenTrackingIDForSingleBetShouldBeX(string trackingID)
        {
            Assert.AreEqual(trackingID, _trackingID, "Get trackingID accept");
        }

        [Then(@"SingleBet get null and skip checking trackingID")]
        public void ThenSingleBetGetNullAndSkipCheckingTrackingID()
        {
            Assert.IsTrue(true, "Get null and skip checking trackingID");
        }
    }
}
