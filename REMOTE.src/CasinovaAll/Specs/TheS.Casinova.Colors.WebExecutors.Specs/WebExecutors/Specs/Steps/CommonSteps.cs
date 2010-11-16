using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Rhino.Mocks;
using TheS.Casinova.Colors.DAL;
using TheS.Casinova.Colors.BackServices;
using SpecFlowAssist;

namespace TheS.Casinova.Colors.WebExecutors.Specs.Steps
{
    [Binding]
    public class CommonSteps
    {
        public const string Key_Dac_CreateGameRoundConfig = "CreateTableConfigExecutotr";
        public const string Key_Dac_BetColor = "BetExecutor";
        public const string Key_Dqr_GetGameResult = "GetGameResultExecutor";
        public const string Key_Dac_PayForWinnerInfo = "PayForWinnerExecutor";
        public const string Key_Dqr_ListActiveGameRoundsExecutor = "ActiveGameRoundsExecutor";
        public const string Key_Dqr_ListGamePlayInfo = "GamePlayInfoExecutor";
        public const string Key_Dac = "mockColorGameDataAccess";
        public const string Key_Dqr = "mockColorGameDataQuery";

        MockRepository Mocks { get { return SpecEventDefinitions.Mocks; } }

        //List active game round specs initialized
        [Given(@"The ActiveGameRound has been created and initialized")]
        public void GivenTheActiveGameRoundHasBeenCreatedAndInitialized()
        {
            var dqr = Mocks.DynamicMock<IColorsGameDataQuery>();

            //ScenarioContext.Current[Key_Dqr] = dqr;
            //ScenarioContext.Current[Key_Dqr_ListActiveGameRoundsExecutor] = new ListActiveGameRoundsExecutor(dqr);
            ScenarioContext.Current.Set<ListActiveGameRoundsExecutor>(
                new ListActiveGameRoundsExecutor(dqr));
        }

        //List game play information specs initialized
        [Given(@"The GamePlayInformation has been created and initialized")]
        public void GivenTheGamePlayInformationHasBeenCreatedAndInitialized()
        {
            var dqr = Mocks.DynamicMock<IColorsGameDataQuery>();

            ScenarioContext.Current[Key_Dqr] = dqr;
            ScenarioContext.Current[Key_Dqr_ListGamePlayInfo] = new ListGamePlayInfoExecutor(dqr);
        }

        //Pay For Colors Winner Information specs initialized
        [Given(@"The PayForcolorsWinnerInfo has been created and initialized")]
        public void GivenThePayForcolorsWinnerInfoHasBeenCreatedAndInitialized()
        {
            var dac = Mocks.DynamicMock<IColorsGameBackService>();

            ScenarioContext.Current[Key_Dac] = dac;
            ScenarioContext.Current[Key_Dac_PayForWinnerInfo] = new PayForColorsWinnerInfoExecutor(dac);
        }

        //Game round information specs initialized
        [Given(@"The GameRoundInformation has been created and initialized")]
        public void GivenTheGameRoundInformationHasBeenCreatedAndInitialized()
        {
            var dqr = Mocks.DynamicMock<IColorsGameDataQuery>();

            ScenarioContext.Current[Key_Dqr] = dqr;
            ScenarioContext.Current[Key_Dqr_GetGameResult] = new GetGameResultExecutor(dqr);
        }

        //Bet information space initialized
        [Given(@"The BetInformation has been created and initialized")]
        public void GivenTheBetInformationHasBeenCreatedAndInitialized()
        {
            var dac = Mocks.DynamicMock<IColorsGameBackService>();

            ScenarioContext.Current[Key_Dac] = dac;
            ScenarioContext.Current[Key_Dac_BetColor] = new BetColorsExecutor(dac);
        }

        //CreateGameRoundConfigurations information space initialized
        [Given(@"The GameRoundConfigurations has been created and initialized")]
        public void GivenTheGameRoundConfigurationsHasBeenCreatedAndInitialized()
        {
            var dac = Mocks.DynamicMock<IGameTableBackService>();

            ScenarioContext.Current[Key_Dac] = dac;
            // TODO: Send dependency container
            ScenarioContext.Current[Key_Dac_CreateGameRoundConfig] = new CreateGameRoundConfigExecutor(dac, null);
        }

    }
}
