﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TheS.Casinova.Colors.Models;
using Rhino.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheS.Casinova.Colors.Commands;

namespace TheS.Casinova.Colors.WebExecutors.Specs.Steps
{
    [Binding]
    public class ListActiveGameRoundsSteps : ColorsGameStepsBase
    {
          private ListActiveGameRoundsCommand _cmd;
          private IEnumerable<ActiveGameRounds> expectActiveRound;



        [Given(@"The active game rounds are :")]
        public void GivenTheActiveGameRoundsAre(Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"Call ListActiveGameRoundsExecutor")]
        public void WhenCallListActiveGameRoundsExecutor()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"The result should be:")]
        public void ThenTheResultShouldBe(Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"The active game rounds should be null:")]
        public void ThenTheActiveGameRoundsShouldBeNull()
        {
            ScenarioContext.Current.Pending();
        }

    }
}
