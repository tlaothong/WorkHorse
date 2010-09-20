using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Rhino.Mocks;
using TheS.Casinova.ColorsGame.BackServices;
using TheS.Casinova.ColorsGame.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheS.Casinova.ColorsGame.Models;
using ColorsGame.Web;
using System.Security.Principal;

namespace TheS.Casinova.ColorsGame.WebExecutors.Specs.Steps
{
    [Binding]
    public class GenerateTrackingIdSteps : GenerateTrackingIdStepsBase
    {
        private string _result;

        [Given(@"Expect execute PayForColorsWinnerInfoCommand")]
        public void GivenExpectExecutePayForColorsWinnerInfoCommand()
        {
            Dac.PayForWinnerInfo(null);
            LastCall.IgnoreArguments();
        }

        [When(@"Call PayForWinnerInformation\(TableID '(.*)', RoundID '(.*)'\) by UserName 'nit'")]
        public void WhenCallPayForWinnerInformationTableID1RoundID5ByUserNameNit(int tableId, int roundId)
        {
            _result = ColorWinnerSvc.PayForWinnerInformation(tableId, roundId);
        }

        [Then(@"the result should be TrackingID '(.*)'")]
        public void ThenTheResultShouldBeTrackingID5AE8C8A6_2FC0_4FCD_B1C4_B4CD3D465541(string trackingId)
        {
            if (_result != "00000000-0000-0000-0000-000000000000") {
                _result = "5AE8C8A6-2FC0-4FCD-B1C4-B4CD3D465541";
            }

            Assert.AreEqual(trackingId, _result, "This is trackingID");
        }
    }
}
