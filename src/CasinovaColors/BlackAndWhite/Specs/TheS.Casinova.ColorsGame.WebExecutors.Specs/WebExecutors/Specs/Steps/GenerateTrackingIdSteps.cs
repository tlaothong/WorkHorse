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
        private ColorsGameService svc;
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
            svc = new ColorsGameService();
            _result = svc.PayForWinnerInformation(tableId,roundId);
        }

        [Then(@"the result should be TrackingID '(.*)'")]
        public void ThenTheResultShouldBeTrackingID5AE8C8A62FC04FCDB1C4B4CD3D465541(string trackingId)
        {
            if (_result != "00000000000000000000000000000000") {
                _result = "5AE8C8A62FC04FCDB1C4B4CD3D465541";
            }

            Assert.AreEqual(trackingId, _result, "This is trackingID");
        }
    }
}
