using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Rhino.Mocks;
using TheS.Casinova.Colors.DAL;
using TheS.Casinova.Colors.BackServices;
using SpecFlowAssist;
using PerfEx.Infrastructure;
using PerfEx.Infrastructure.Containers.StructureMapAdapter;
using TheS.Casinova.Colors.Models;
using TheS.Casinova.Colors.Commands;
using TheS.Casinova.Colors.Validators;
using PerfEx.Infrastructure.Validation;
using PerfEx.Infrastructure.CommandPattern;

namespace TheS.Casinova.Colors.WebExecutors.Specs.Steps
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

            //ScenarioContext.Current[Key_Dqr] = dqr;
            //ScenarioContext.Current[Key_Dqr_ListActiveGameRoundsExecutor] = new ListActiveGameRoundsExecutor(dqr);
            ScenarioContext.Current.Set<ListActiveGameRoundsExecutor>(
                new ListActiveGameRoundsExecutor(dqr));
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
        [Given(@"The CreateGameRoundConfigExecutor has been created and initialized")]
        public void GivenTheCreateGameRoundConfigExecutorHasBeenCreatedAndInitialized()
        {
            var dac = Mocks.DynamicMock<IGameTableBackService>();
            IDependencyContainer container;

            setupValidators(out container);
            
            ScenarioContext.Current[Key_Dac_CreateGameRoundConfig] = dac;
            // TODO: Send dependency container
            ScenarioContext.Current[Key_CreateGameRoundConfig] = new CreateGameRoundConfigExecutor(dac, container);
        }

        private static void setupValidators(out IDependencyContainer container)
        {
            var fac = new StructureMapAbstractFactory();
            var reg = fac.CreateRegistry();

            //reg.Register<IValidator<GameRoundConfiguration, NullCommand>
            //    , DataAnnotationValidator<GameRoundConfiguration, NullCommand>>();
            reg.Register<IValidator<GameRoundConfiguration, CreateGameRoundConfigurationCommand>
                , GameRoundConfiguration_CreateGameRoundConfigurationValidator>();

            container = fac.CreateContainer(reg);
        }

    }
}
