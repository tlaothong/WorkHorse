using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TheS.Casinova.TwoWins.Models;
using Rhino.Mocks;
using TheS.Casinova.TwoWins.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TheS.Casinova.TwoWins.WebExecutors.Specs.Steps
{
    [Binding]
    public class GetGameResultSteps : ColorsGameStepsBase
    {
        //private GetGameResultCommand _cmd;
        //private GameRoundInformation _getGameResult;

        [Given(@"Server has game information")]
        public void GivenServerHasGameInformation(Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"Call GetGameResultExecutor\(RoundID'(.*)'\)")]
        public void WhenCallGetGameResultExecutorRoundIDX(int roundId)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the game result should be")]
        public void ThenTheGameResultShouldBe(Table table)
        {
            ScenarioContext.Current.Pending();

        }
        [Then(@"the game result should be throw exception")]
        public void ThenTheGameResultShouldBeThrowException()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
