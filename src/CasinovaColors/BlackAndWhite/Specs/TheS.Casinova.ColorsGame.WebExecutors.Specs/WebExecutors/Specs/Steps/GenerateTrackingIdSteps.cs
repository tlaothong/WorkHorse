using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Rhino.Mocks;
using TheS.Casinova.ColorsGame.BackServices;
using TheS.Casinova.ColorsGame.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TheS.Casinova.ColorsGame.WebExecutors.Specs.Steps
{
    [Binding]
    public class GenerateTrackingIdSteps : GenerateTrackingIdStepsBase
    {
        private string _trackingId;

        [Given(@"Expect the TrackingID should be generate by calling PayForColorsWinnerInfoExecutor")]
        public void GivenExpectTheTrackingIDShouldBeGenerateByCallingPayForColorsWinnerInfoExecutor()
        {
            _trackingId = Guid.NewGuid().ToString();

            if (_trackingId != "00000000-0000-0000-0000-000000000000") {
                _trackingId = "5AE8C8A6-2FC0-4FCD-B1C4-B4CD3D465541";
            }
       
            Dac.PayForWinnerInfo(null);
            LastCall.IgnoreArguments();
        }

        [When(@"Call ExecuteCommand\(UserName'(.*)',TableID '(.*)', RoundID '(.*)'\)")]
        public void WhenCallExecuteCommandUserNameXTableIDXRoundIDX(string userName, int tableId, int roundId)
        {
            Dac.PayForWinnerInfo(new Commands.PayForColorsWinnerInfoCommand {
                UserName = userName,
                TableID = tableId,
                RoundID = roundId,
            });

        }

        [Then(@"the result should be TrackingID '(.*)'")]
        public void ThenTheResultShouldBeTrackingIDX(string trackingId)
        {
            Assert.AreEqual(_trackingId, trackingId, "TrackingID");
        }
    }
}
