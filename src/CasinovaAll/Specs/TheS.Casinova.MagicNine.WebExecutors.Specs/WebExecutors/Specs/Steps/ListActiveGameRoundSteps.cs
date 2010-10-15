using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TheS.Casinova.MagicNine.Models;
using Rhino.Mocks;
using TheS.Casinova.MagicNine.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TheS.Casinova.MagicNine.WebExecutors.Specs.Steps
{
    [Binding]
    public class ListActiveGameRoundSteps : MagicNineGameStepsBase
    {
        //private IEnumerable<GameRoundInformation> _activeGameRound;
        //private ListActiveGameRoundCommand _cmd;

        [Given(@"server has 4 game round information  in data")]
        public void GivenServerHas4GameRoundInformationInData(Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"call ListActiveGameRoundExecutor\(\)")]
        public void WhenCallListActiveGameRoundExecutor()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the result should be as:")]
        public void ThenTheResultShouldBeAs(Table table)
        {
            ScenarioContext.Current.Pending();

        }

        [Then(@"the result should be null")]
        public void ThenTheResultShouldBeNull()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
