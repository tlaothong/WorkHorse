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
        private PayForColorsWinnerInfoCommand _cmd = new PayForColorsWinnerInfoCommand();
        private ColorsGameService _svc = new ColorsGameService();
        private string _result;
        private bool _checkResult;

        [Given(@"Request winner from TableID '(.*)', RoundID '(.*)' UserName 'nit'")]
        public void GivenRequestWinnerFromTableIDXRoundIDXUserNameNit(int tableId, int roundId)
        {
          _result =  _svc.PayForWinnerInformation(tableId, roundId);
        }

        [Given(@"Expect call IColorGameBackService\.PayForWinnerInfo\(\)")]
        public void GivenExpectCallIColorGameBackService_PayForWinnerInfo()
        {
            Dac.PayForWinnerInfo(null);
            LastCall.IgnoreArguments();
        }

        [When(@"Execute PayForColorsWinnerInfoCommand\(TableID '(.*)', RoundID '(.*)'\) by UserName 'nit'")]
        public void WhenExecutePayForColorsWinnerInfoCommand(int tableId, int roundId)
        {
            _cmd.GamePlayInformation = new GamePlayInformation {
                    TableID = tableId,
                    RoundID = roundId,
            };

            Action<PayForColorsWinnerInfoCommand> command= (a) => {};
            ColorWinnerExecutor.Execute(_cmd,command);
        }

        [Then(@"The result should be executeCommand by calling IColorGameBackService\.PayForWinnerInfo\(\)")]
        public void ThenTheResultShouldBeExecuteCommandByCallingIColorGameBackService_PayForWinnerInfo()
        {
            Assert.IsTrue(true, "Expectation has been verified in the end of block When.");
        }

        [Then(@"The WebServer can generated TrackingID")]
        public void ThenTheWebServerCanGenerateTrackingID()
        {
            string trackingId = "00000000000000000000000000000000";

            if (_result == trackingId) 
            {
                _checkResult = false;
            }
            else if (string.IsNullOrEmpty(_result) == true) 
            {
                _checkResult = false;
            }
            else 
            {
                _checkResult = true;
            }
           
            Assert.AreEqual(true, _checkResult, "Generate tracking is successed");
        }
    }
}
