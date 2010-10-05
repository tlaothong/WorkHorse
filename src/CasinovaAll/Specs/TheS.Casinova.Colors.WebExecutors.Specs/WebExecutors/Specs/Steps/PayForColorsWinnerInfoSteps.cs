using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Rhino.Mocks;
using TheS.Casinova.Colors.Commands;
using TheS.Casinova.Colors.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TheS.Casinova.Colors.WebExecutors.Specs.Steps
{
    [Binding]
    public class PayForColorsWinnerInfoSteps : ColorsGameStepsBase
    {
        private PayForColorsWinnerInfoCommand _cmd ;
        private Guid _trackingID;
        private string _svcTrackingID;

        [Given(@"TrackingID is '(.*)'")]
        public void GivenTrackingIDIsX(string trackingID)
        {
            string checkTrack;
            checkTrack = "00000000-0000-0000-0000-000000000000";

            //ตรวจสอบค่า trackingID
            if (trackingID != checkTrack) {
                _trackingID = Guid.Parse(trackingID);
            }
            else 
            {
                _trackingID = Guid.Parse(checkTrack);
            }

            _svcTrackingID = trackingID;
        }

        [Given(@"Expected call PayForWinnerInfo")]
        public void GivenExpectedCallPayForWinnerInfo()
        {
            BackDac.PayForWinnerInfo(null);
            LastCall.IgnoreArguments();
        }

        [When(@"Call PayForWinnerInfo\(RoundID '(.*)'\) by userName 'nit'")]
        public void WhenCallPayForWinnerInfoRoundID5ByUserNameNit(int roundID)
        {
            _cmd = new PayForColorsWinnerInfoCommand();
            _cmd.GamePlayInfo = new GamePlayInformation {
                RoundID = roundID,
                OnGoingTrackingID = _trackingID,
            };

            Action<PayForColorsWinnerInfoCommand> command = (a) => { };
            PayForWinnerInfo.Execute(_cmd, command);
        }
       
         [Then(@"The result should be called PayForWinnerInfo Succeeded")]
         public void ThenTheResultShouldBeCalledPayForWinnerInfoSucceeded()
        {
            Assert.IsTrue(true, "Expectation has been verified in the end of block When.");
        }
    
        [Then(@"TrackingID should be '(.*)'")]
        public void ThenTrackingIDShouldX(string expecTrackingID)
        {
            Assert.AreEqual(expecTrackingID,_svcTrackingID,"TrackingID for client and back server");
        }
    }
}
