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
        [Given(@"Expect execute PayForColorsWinnerInfoCommand")]
        public void GivenExpectExecutePayForColorsWinnerInfoCommand()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"Call PayForWinnerInformation\(TableID '1', RoundID '5'\) by UserName 'nit'")]
        public void WhenCallPayForWinnerInformationTableID1RoundID5ByUserNameNit()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the result should be TrackingID '5AE8C8A6-2FC0-4FCD-B1C4-B4CD3D465541'")]
        public void ThenTheResultShouldBeTrackingID5AE8C8A6_2FC0_4FCD_B1C4_B4CD3D465541()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
