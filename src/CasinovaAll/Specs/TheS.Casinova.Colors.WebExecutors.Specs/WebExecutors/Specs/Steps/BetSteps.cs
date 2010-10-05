using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace TheS.Casinova.Colors.WebExecutors.Specs.Steps
{
    [Binding]
    public class BetSteps
    {
        [Given(@"The BetInformation has been created and initialized")]
        public void GivenTheBetInformationHasBeenCreatedAndInitialized()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"Balance is '(.*)'")]
        public void GivenBalanceIs200(int balance)
        {
            ScenarioContext.Current.Pending();
        }

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

        [When(@"Call PlayerBet\(RoundID '(.*)', Amount '(.*)', Color '(.*)'\) by userName 'nit'")]
        public void WhenCallPlayerBetRoundID_5Amount100ColorBlackByUserNameNit(int roundId, int amount, string color)
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

        [Then(@"Balance should be '(.*)'")]
        public void ThenBalanceShouldBe0(int balance)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
