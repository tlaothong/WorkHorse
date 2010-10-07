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
        [Given(@"System has userName 'tle','boy','ae','ku','au'")]
        public void GivenSystemHasUserNameTleBoyAeKuAu()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"TrackingID is '(.*)'")]
        public void GivenTrackingIDIsX(string trackingId)
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"Expected call PayForWinnerInfo")]
        public void GivenExpectedCallPayForWinnerInfo()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"Call PayForWinnerInfo\(RoundID '(.*)'\) by userName '(.*)'")]
        public void WhenCallPayForWinnerInfoRoundID5ByUserNameNit(int roundId, string userName)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"TrackingID of PayForWinner should be '(.*)'")]
        public void ThenTrackingIDShouldBeX(string trackingId)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"TrackingID  of PayForWinner should be null")]
        public void ThenTrackingIDOfPayForWinnerShouldBeNull()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
