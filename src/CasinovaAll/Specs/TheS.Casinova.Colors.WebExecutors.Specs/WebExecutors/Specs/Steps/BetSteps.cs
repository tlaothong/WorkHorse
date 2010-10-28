using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TheS.Casinova.TwoWins.Models;

namespace TheS.Casinova.TwoWins.WebExecutors.Specs.Steps
{
    [Binding]
    public class BetSteps : ColorsGameStepsBase
    {

        [Given(@"TrackingID of PlayerBet is '(.*)'")]
        public void GivenTrackingIDOfPlayerBetIsX(string trackingId)
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"Expected call PlayerBet")]
        public void GivenExpectedCallPlayerBet()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"Call PlayerBet\(RoundID '(.*)', Amount '(.*)', Color '(.*)'\) by userName '(.*)'")]
        public void WhenCallPlayerBetRoundID_5Amount100ColorBlackByUserNameNit(int roundId, int amount, string color, string userName)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"TrackingID of PlayerBet should be '(.*)'")]
        public void ThenTrackingIDOfPlayerBetShouldBeX(string trackingId)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"TrackingID of PlayerBet should be null")]
        public void ThenTrackingIDOfPlayerBetShouldBeNull()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
