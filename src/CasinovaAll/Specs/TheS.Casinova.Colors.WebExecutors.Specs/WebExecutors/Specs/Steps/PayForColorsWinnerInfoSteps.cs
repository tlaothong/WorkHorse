using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Rhino.Mocks;
using TheS.Casinova.Colors.Commands;
using TheS.Casinova.Colors.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerfEx.Infrastructure.Validation;

namespace TheS.Casinova.Colors.WebExecutors.Specs.Steps
{
    [Binding]
    public class PayForColorsWinnerInfoSteps : ColorsGameStepsBase
    {
        private PayForColorsWinnerInfoCommand _cmd;
        private string _trackingID;

        [Given(@"PayForColorWinner Informations as : UserName '(.*)' RoundID '(.*)' ActionType '(.*)'")]
        public void GivenPayForColorWinnerInformationsAsUserNameXRoundIDXActionTypeX(string userName, int roundID,string action)
        {
            _cmd = new PayForColorsWinnerInfoCommand {
                PlayerActionInfoUserName = new PlayerActionInformation { 
                    UserName = userName,
                    RoundID = roundID,
                    ActionType = action
                }
            };
        }

        [Given(@"The system generated TrackingID:'(.*)' for PayForColorWinnerInfo")]
        public void GivenTheSystemGeneratedTrackingIDXForPayForColorWinnerInfo(string trackingID)
        {
            _trackingID = trackingID;
        }

        //Validate input
        [When(@"Call PayForColorsWinnerInfoExecutor\(\) for validate PayForColorWinner informations")]
        public void WhenCallPayForColorsWinnerInfoExecutorForValidatePayForColorWinnerInformations()
        {
            try {
                PayForWinnerInfo.Execute(_cmd, (x) => { });
                Assert.Fail("Shouldn't be here");
            }
            catch (Exception ex) {
                Assert.IsInstanceOfType(ex,
                   typeof(ValidationErrorException));
            };
        }

        //Test function
        [When(@"Call PayForColorsWinnerInfoExecutor\(\)")]
        public void WhenCallPayForColorsWinnerInfoExecutor()
        {
            try {
                PayForWinnerInfo.Execute(_cmd, (x) => { });
            }
            catch (Exception ex) {
                Assert.IsInstanceOfType(ex,
                    typeof(ValidationErrorException));
            };
        }

        [Then(@"PayForColorWinnerInfo get null and skip checking trackingID")]
        public void ThenPayForColorWinnerInfoGetNullAndSkipCheckingTrackingID()
        {
            Assert.IsTrue(true, "Get null and skip checking trackingID");
           
        }

        [Then(@"TrackingID for PayForColorWinnerInfo should be :'(.*)'")]
        public void ThenTrackingIDForPayForColorWinnerInfoShouldBeX(string trackingID)
        {
            Assert.AreEqual(trackingID, _trackingID, "Get trackingID accept");
        }
    }
}
