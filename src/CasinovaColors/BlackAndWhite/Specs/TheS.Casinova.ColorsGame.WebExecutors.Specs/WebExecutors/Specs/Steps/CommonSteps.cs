using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Rhino.Mocks;
using TheS.Casinova.ColorsGame.DAL;
using TheS.Casinova.ColorsGame.WebExecutors;

namespace TheS.Casinova.ColorsGame.WebExecutors.Specs.Steps
{
    [Binding]
    public class CommonSteps
    {
        //Get game round winner
        public const string Key_GameRoundWinner = "gameRoundWinner";
        public const string Key_DacRoundWinner = "mockGameroundWinner";

        MockRepository Mocks { get { return SpecEventDefinitions.Mocks; } }

        //Get game round winner specs initialized
        [Given(@"The GameRoundWinner has been created and initialized")]
        public void GivenTheGameRoundWinnerHasBeenCreatedAndInitialized()
        {
            var dac = Mocks.DynamicMock<IColorsGameDataQuery>();

            ScenarioContext.Current[Key_DacRoundWinner] = dac;
            ScenarioContext.Current[Key_GameRoundWinner] = new GetGameRoundWinnerExecutor(dac);
        }


    }
}
