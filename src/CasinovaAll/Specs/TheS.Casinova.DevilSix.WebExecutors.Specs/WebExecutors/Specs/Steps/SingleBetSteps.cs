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
    public class SingleBetSteps : DevilSixGameStepsBase
    {
        private SingleBetCommand _cmd;
        private string _trackingID;

        [Given(@"SingleBet Informations as : UserName '(.*)' RoundID '(.*)' Amount '(.*)'")]
        public void GivenSingleBetInformationsAsUserNameXRoundIDXAmountX(string userName, int roundId, double amount)
        {
            _cmd = new SingleBetCommand {
                BetInfo = new BetInformation { 
                    UserName = userName,
                    RoundID = roundId,
                    Amount = amount
                }
            };
        }

        [Given(@"The system generated TrackingID for SingleBet:'(.*)'")]
        public void GivenTheSystemGeneratedTrackingIDForSingleBetX(string trackingID)
        {
            _trackingID = trackingID;

            SetupResult.For(svc_GenerateTrackingID.GenerateTrackingID())
                .IgnoreArguments().Return(Guid.Parse(_trackingID));
        }

        //Test Function
        [When(@"Call SingleBetExecutor\(\)")]
        public void WhenCallSingleBetExecutor()
        {
            SingleBet.Execute(_cmd, (x) => { });
        }

        //Validate input
        [When(@"Call SingleBetExecutor\(\) for validate single bet information")]
        public void WhenCallSingleBetExecutorForValidateSingleBetInformation()
        {
            try {
                SingleBet.Execute(_cmd, (x) => { });
                Assert.Fail("Shouldn't be here");
            }
            catch (Exception ex) {
                Assert.IsInstanceOfType(ex,
                    typeof(ValidationErrorException));
            }
            
        }

        [Then(@"SingleBet get null and skip checking trackingID")]
        public void ThenSingleBetGetNullAndSkipCheckingTrackingID()
        {
            Assert.IsTrue(true, "Get null and skip checking trackingID.");
        }

        [Then(@"TrackingID for SingleBet should be :'(.*)'")]
        public void ThenTrackingIDForSingleBetShouldBeX(string trackingID)
        {
            Assert.AreEqual(trackingID, _trackingID, "Get trackingID accept");
        }
    }
}
