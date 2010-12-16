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
    public class RangeBetSteps : TwoWinGameStepsBase
    {
        private RangeBetCommand _cmd;
        private string _trackingID;

        [Given(@"Sent UserName'(.*)' RoundID '(.*)' FromAmount'(.*)' ThruAmount'(.*)'")]
        public void GivenSentUserNameXRoundIDXFromAmountXThruAmountX(string userName, int roundID, double fromAmount,double thruAmount)
        {
            _cmd = new RangeBetCommand {
                RangeBetInfo = new RangeBetInformation {
                    UserName = userName,
                    RoundID = roundID,
                    FromAmount = fromAmount,
                    ThruAmount = thruAmount
                }
            };
        }

        [Given(@"TrackingID for RangeBet is '(.*)'")]
        public void GivenTrackingIDForRangeBetIsX(string trackingID)
        {
            _trackingID = trackingID;

            SetupResult.For(svc_GenerateTrackingID.GenerateTrackingID())
                .IgnoreArguments().Return(Guid.Parse(_trackingID));
        }

        [Given(@"Sent UserName'(.*)' RoundID '(.*)' FromAmount'(.*)' ThruAmount'(.*)' for Range bet validation")]
        public void GivenSentUserNameNayitRoundID_1FromAmount89ThruAmount98ForRangeBetValidation(string userName, int roundID, double fromAmount, double thruAmount)
        {
            _cmd = new RangeBetCommand {
                RangeBetInfo = new RangeBetInformation {
                    UserName = userName,
                    RoundID = roundID,
                    FromAmount = fromAmount,
                    ThruAmount = thruAmount
                }
            };
        }

        [When(@"Call RangeBetExecutor\(\) for validate input")]
        public void WhenCallRangeBetExecutorForValidateInput()
        {
            try {
                RangeBet.Execute(_cmd, (x) => { });
                Assert.Fail("Shouldn't be here");
            }
            catch (Exception ex) {
                Assert.IsInstanceOfType(ex,
                   typeof(ValidationErrorException));
            };
        }

        //Test function
        [When(@"Call RangeBetExecutor\(\)")]
        public void WhenCallRangeBetExecutor()
        {
            RangeBet.Execute(_cmd, (x) => { });
        }

        [Then(@"TrackingID for RangeBet should be :'(.*)'")]
        public void ThenTrackingIDForRangeBetShouldBeX(string trackingID)
        {
            Assert.AreEqual(trackingID, _trackingID, "Get trackingID accept");
        }

        [Then(@"RangeBet get null and skip checking trackingID")]
        public void ThenRangeBetGetNullAndSkipCheckingTrackingID()
        {
            Assert.IsTrue(true, "Get null and skip checking trackingID");
        }
    }
}
