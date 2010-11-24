using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Rhino.Mocks;
using TheS.Casinova.ColorsGame.DAL;
using TheS.Casinova.ColorsGame.WebExecutors;
using TheS.Casinova.ColorsGame.BackServices;

namespace TheS.Casinova.ColorsGame.WebExecutors.Specs.Steps
{
    [Binding]
    public class CommonSteps
    {
        //Get game round winner
        public const string Key_GameRoundWinner = "gameRoundWinner";
        public const string Key_DacRoundWinner = "mockGameroundWinner";
 
        public const string Key_PayForWinnerExecutor = "winnerExecutor";
        public const string Key_Dac = "mockColorGameDataAccess";

        MockRepository Mocks { get { return SpecEventDefinitions.Mocks; } }

        //Get game round winner specs initialized
        [Given(@"The GameRoundWinner has been created and initialized")]
        public void GivenTheGameRoundWinnerHasBeenCreatedAndInitialized()
        {
            var dac = Mocks.DynamicMock<IColorsGameDataQuery>();

            ScenarioContext.Current[Key_DacRoundWinner] = dac;
            ScenarioContext.Current[Key_GameRoundWinner] = new GetGameRoundWinnerExecutor(dac);
        }

        [Given(@"The PayForWinnerInfoExecutor  has been created and initialized")]
        public void GivenThePayForWinnerInfoExecutorHasBeenCreatedAndInitialized()
 
        {
            var dac = Mocks.DynamicMock<IColorsGameBackService>();

            ScenarioContext.Current[Key_Dac] = dac;
            ScenarioContext.Current[Key_PayForWinnerExecutor] = new PayForColorsWinnerInfoExecutor(dac);
        }


    }
}
