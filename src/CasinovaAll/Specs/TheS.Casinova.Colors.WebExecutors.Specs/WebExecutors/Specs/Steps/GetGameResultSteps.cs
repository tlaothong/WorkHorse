using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TheS.Casinova.Colors.Models;
using Rhino.Mocks;
using TheS.Casinova.Colors.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TheS.Casinova.Colors.WebExecutors.Specs.Steps
{
    [Binding]
    public class GetGameResultSteps : ColorsGameStepsBase
    {
        //private GetGameResultCommand _cmd;
        //private GameRoundInformation _getGameResult;

        [Given(@"Server has game result information")]
        public void GivenServerHasGameResultInformation(Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"Call GetGameResultExecutor\(GameRoundInfoRoundID'(.*)'\)")]
        public void WhenCallGetGameResultExecutorRoundIDX(int roundId)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the game result should be : GameRoundInfoRoundID '(.*)' StartTime '(.*)' EndTime '(.*)' BlackPot '(.*)' WhitePot '(.*)' HandCount '(.*)'")]
        public void ThenTheGameResultShouldBeRoundIDXStartTimeXEndTimeXBlackPotXWhitePotXHandCountX(int round, string startTime, string endTime, double blackPot, double whitePot,int handCount)
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
