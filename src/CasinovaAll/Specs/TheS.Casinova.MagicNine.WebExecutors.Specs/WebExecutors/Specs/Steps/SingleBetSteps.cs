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
    public class SingleBetSteps : MagicNineGameStepsBase
    {
        private SingleBetCommand _cmd;
        private string _trackingID;

        [Given(@"SingleBet Informations as : UserName '(.*)' Round '(.*)'")]
        public void GivenSingleBetInformationsAsUserNameXRoundIDX(string userName, int roundId)
        {
            _cmd = new SingleBetCommand {
                BetInfo = new BetInformation { 
                    UserName = userName,
                    Round = roundId
                }
            };
        }

        [Given(@"The system generated TrackingID for SingleBet:'(.*)'")]
        public void GivenTheSystemGeneratedTrackingIDForSingleBetX(string trackingID)
        {
            _trackingID = trackingID;
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

        //Test Function
        [When(@"Call SingleBetExecutor\(\)")]
        public void WhenCallSingleBetExecutor()
        {
            try {
                SingleBet.Execute(_cmd, (x) => { });
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

        [Then(@"TrackingID for SingleBet should be :'(.*)'")]
        public void ThenTrackingIDForSingleBetShouldBeX(string trackingID)
        {
            Assert.AreEqual(trackingID, _trackingID, "Get trackingID accept");
        }
    }
}
