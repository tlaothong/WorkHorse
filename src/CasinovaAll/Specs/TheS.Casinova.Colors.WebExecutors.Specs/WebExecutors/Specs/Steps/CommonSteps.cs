using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Rhino.Mocks;
using TheS.Casinova.TwoWins.DAL;
using TheS.Casinova.TwoWins.BackServices;

namespace TheS.Casinova.TwoWins.WebExecutors.Specs.Steps
{
    [Binding]
    public class CommonSteps
    {
        public const string Key_Dac_CreateGameRoundConfig = "mockDac_CreateTableConfig";
        public const string Key_CreateGameRoundConfig = "mock_CreateTableConfig";
      
        public const string Key_Dqr_GetGameResult = "mockDqr_GetGameResult";
        public const string Key_GetGameResult = "mock_GetGameResult";

        public const string Key_Dqr_ListGamePlayInfo = "mockDqr_ListGamePlayInfo";
        public const string Key_ListGamePlayInfo = "mock_ListGamePlayInfo";

        public const string Key_Dac_PayForWinnerInfo = "mockDac_PayForWinnerInformation";
        public const string Key_PayForWinnerInfo = " mock_PayForWinnerInformation";

        public const string Key_Dqr_ListActiveGameRounds = "mockDqr_ListActiveGameRounds";
        public const string Key_ListActiveGameRounds = "mock_ListActiveGameRounds";

        public const string Key_Dac_BetColorsGame = "mockDac_BetColorsGame";
        public const string Key_BetColorsGame = "mock_BetColorsGame";

        MockRepository Mocks { get { return SpecEventDefinitions.Mocks; } }

        //List active game round specs initialized
        [Given(@"The ListActiveGameRoundsExecutor has been created and initialized")]
        public void GivenTheListActiveGameRoundsExecutorHasBeenCreatedAndInitialized()
        {
            var dqr = Mocks.DynamicMock<IColorsGameDataQuery>();

            ScenarioContext.Current[Key_Dqr_ListActiveGameRounds] = dqr;
            ScenarioContext.Current[Key_ListActiveGameRounds] = new ListActiveGameRoundsExecutor(dqr);
        }

        //List game play information specs initialized
        [Given(@"The ListGamePlayInfoExecutor has been created and initialized")]
        public void GivenTheListGamePlayInfoExecutorHasBeenCreatedAndInitialized()
        {
            var dqr = Mocks.DynamicMock<IColorsGameDataQuery>();

            ScenarioContext.Current[Key_Dqr_ListGamePlayInfo] = dqr;
            ScenarioContext.Current[Key_ListGamePlayInfo] = new ListGamePlayInfoExecutor(dqr);
        }

        //Pay For Colors Winner Information specs initialized
        [Given(@"The PayForColorsWinnerInfoExecutor has been created and initialized")]
        public void GivenThePayForColorsWinnerInfoExecutorHasBeenCreatedAndInitialized()
        {
            var dac = Mocks.DynamicMock<IColorsGameBackService>();

            ScenarioContext.Current[Key_Dac_PayForWinnerInfo] = dac;
            ScenarioContext.Current[Key_PayForWinnerInfo] = new PayForColorsWinnerInfoExecutor(dac);
        }

        //Game round information specs initialized
        [Given(@"The GetGameResultExecutor has been created and initialized")]
        public void GivenTheGetGameResultExecutorHasBeenCreatedAndInitialized()
        {
            var dqr = Mocks.DynamicMock<IColorsGameDataQuery>();

            ScenarioContext.Current[Key_Dqr_GetGameResult] = dqr;
            ScenarioContext.Current[Key_GetGameResult] = new GetGameResultExecutor(dqr);
        }

        //Bet information space initialized
        [Given(@"The BetColorsExecutor has been created and initialized")]
        public void GivenTheBetColorsExecutorHasBeenCreatedAndInitialized()
        {
            var dac = Mocks.DynamicMock<IColorsGameBackService>();

            ScenarioContext.Current[Key_Dac_PayForWinnerInfo] = dac;
            ScenarioContext.Current[Key_PayForWinnerInfo] = new PayForColorsWinnerInfoExecutor(dac);
        }

        //CreateGameRoundConfigurations information space initialized
        [Given(@"The GameRoundConfigurations has been created and initialized")]
        public void GivenTheGameRoundConfigurationsHasBeenCreatedAndInitialized()
        {
            var dac = Mocks.DynamicMock<IGameTableBackService>();

            ScenarioContext.Current[Key_Dac_CreateGameRoundConfig] = dac;
            ScenarioContext.Current[Key_CreateGameRoundConfig] = new CreateGameRoundConfigExecutor(dac);
        }

    }
}
