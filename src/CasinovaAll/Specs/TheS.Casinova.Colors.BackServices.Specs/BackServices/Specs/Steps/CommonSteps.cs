using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rhino.Mocks;
using TechTalk.SpecFlow;
using TheS.Casinova.Colors.DAL;
using TheS.Casinova.Colors.BackServices.BackExecutors;
using TheS.Casinova.Colors.Models;
using PerfEx.Infrastructure;
using TheS.Casinova.Colors.BackServices.Validators;
using PerfEx.Infrastructure.Containers.StructureMapAdapter;
using TheS.Casinova.PlayerProfile.Models;
using TheS.Casinova.Colors.Commands;
using PerfEx.Infrastructure.Validation;
using SpecFlowAssist;
using PerfEx.Infrastructure.CommandPattern;

namespace TheS.Casinova.Colors.BackServices.Specs
{
    [Binding]
    public class CommonSteps
    {
        public const string Key_Dac_UpdatePlayerInfoBalance = "mockDac_UpdatePlayerInfoBalance";
        public const string Key_Dac_CreatePlayerActionInfo = "mockDac_CreatePlayerActionInfo";
        public const string Key_Dac_UpdateOnGoingTrackingID = "mockDac_UpdateOnGoingTrackingID";
        public const string Key_Dac_UpdateRoundWinner = "mockDac_UpdateRoundWinner";
        public const string Key_Dac_CreateGameRoundConfigutions = "mockDac_CreateGameRoundConfigutions";
        public const string Key_Dac_CreateGameRound = "mockDac_CreateGameRound";

        public const string Key_Dqr_GetPlayerInfo = "mockDqr_GetPlayerInfo";
        public const string Key_Dqr_ListPlayerActionInfo = "mockDqr_ListPlayerActionInfo";
        public const string Key_Dqr_GetRoundInfo = "mockDqr_GetRoundInfo";
        public const string Key_Dqr_ListActiveGameRound = "mockDqr_ListActiveGameRound";
        public const string Key_Dqr_GetGameRoundConfiguration = "mockDqr_GetGameRoundConfiguration";

        public const string Key_PayForColorsWinnerInfoExecutor = "PayForColorsWinnerInfoExecutor";
        public const string Key_BetColorExecutor = "BetColorExecutor";
        public const string Key_CreateGameRoundConfigurations = "CreateGameRoundConfigurations";
        public const string Key_CreateGameRound = "CreateGameRound";
        public const string Key_CalculateGameRoundWinner = "CalculateGameRoundWinner";

        public const string Key_UserProfile_BetColorValidator = "UserProfile_BetColorValidator";

        MockRepository Mocks { get { return SpecEventDefinitions.Mocks; } }

        [Given(@"The PayForColorsWinnerInfoExecutor has been created and initialized")]
        public void GivenThePayForColorsWinnerInfoExecutorHasBeenCreatedAndInitialized()
        {
            var dac = Mocks.DynamicMock<IColorsGameDataAccess>();
            var dqr = Mocks.DynamicMock<IColorsGameDataBackQuery>();
            var container = Mocks.DynamicMock<IDependencyContainer>();

            ScenarioContext.Current[Key_Dac_UpdatePlayerInfoBalance] = dac; 
            ScenarioContext.Current[Key_Dac_CreatePlayerActionInfo] = dac;
            ScenarioContext.Current[Key_Dac_UpdateRoundWinner] = dac;
            ScenarioContext.Current[Key_Dac_UpdateOnGoingTrackingID] = dac;

            ScenarioContext.Current[Key_Dqr_GetPlayerInfo] = dqr;
            ScenarioContext.Current[Key_Dqr_ListPlayerActionInfo] = dqr;
            ScenarioContext.Current[Key_Dqr_GetRoundInfo] = dqr;

            setupValidators(out container);
            ScenarioContext.Current[Key_PayForColorsWinnerInfoExecutor] = new PayForColorsWinnerInfoExecutor(container, dac, dqr);
        }

        [Given(@"The BetColorExecutor has been created and initialized")]
        public void GivenTheBetColorExecutorHasBeenCreatedAndInitialized()
        {
            var dac = Mocks.DynamicMock<IColorsGameDataAccess>();
            var dqr = Mocks.DynamicMock<IColorsGameDataBackQuery>();
            var container = Mocks.DynamicMock<IDependencyContainer>();

            ScenarioContext.Current[Key_Dac_UpdatePlayerInfoBalance] = dac;
            ScenarioContext.Current[Key_Dac_CreatePlayerActionInfo] = dac;

            ScenarioContext.Current[Key_Dqr_GetPlayerInfo] = dqr;

            setupValidators(out container);
            ScenarioContext.Current[Key_BetColorExecutor] = new BetColorExecutor(container, dac, dqr);
        }

        [Given(@"The CreateGameRoundConfigurationExecutor has been created and initialized")]
        public void GivenTheCreateGameRoundConfigurationsExecutorHasBeenCreatedAndInitialized()
        {
            var dac = Mocks.DynamicMock<IColorsGameDataAccess>();

            ScenarioContext.Current[Key_Dac_CreateGameRoundConfigutions] = dac;

            ScenarioContext.Current[Key_CreateGameRoundConfigurations] = new CreateGameRoundConfigurationExecutor(dac);
        }

        [Given(@"The CreateGameRoundsExecutor has been created and initialized")]
        public void GivenTheCreateGameRoundsExecutorHasBeenCreatedAndInitialized()
        {
            var dac = Mocks.DynamicMock<IColorsGameDataAccess>();
            var dqr = Mocks.DynamicMock<IColorsGameDataBackQuery>();

            ScenarioContext.Current[Key_Dac_CreateGameRound] = dac;

            ScenarioContext.Current[Key_Dqr_ListActiveGameRound] = dqr;
            ScenarioContext.Current[Key_Dqr_GetGameRoundConfiguration] = dqr;

            ScenarioContext.Current[Key_CreateGameRound] = new CreateGameRoundExecutor(dac, dqr);
        }

        [Given(@"The CalculateGameRoundWinnerExecutor has been created and initialized")]
        public void GivenTheCalculateGameRoundWinnerExecutorHasBeenCreatedAndInitialized()
        {
            var dac = Mocks.DynamicMock<IColorsGameDataAccess>();
            var dqr = Mocks.DynamicMock<IColorsGameDataBackQuery>();

            ScenarioContext.Current[Key_Dqr_GetPlayerInfo] = dqr;
            ScenarioContext.Current[Key_Dqr_GetRoundInfo] = dqr;
            ScenarioContext.Current[Key_Dqr_ListPlayerActionInfo] = dqr;

            ScenarioContext.Current[Key_CalculateGameRoundWinner] = new CalculateGameRoundWinnerExecutor(dqr);
        }

        private static void setupValidators(out IDependencyContainer container)
        {
            var fac = new StructureMapAbstractFactory();
            var reg = fac.CreateRegistry();

            reg.Register<IValidator<UserProfile, BetCommand>
                , UserProfileValidators>();
            reg.Register<IValidator<PlayerActionInformation, NullCommand>
                , PlayerActionInformationValidators>();
            reg.Register<IValidator<UserProfile, PayForColorsWinnerInfoCommand>
                , UserProfile_PayForWinnerInfoValidators>();


            //reg.RegisterInstance<IColorsGameDataBackQuery>
            //    (ScenarioContext.Current.Get<IColorsGameDataBackQuery>(Key_Dac_CreatePlayerActionInfo));
            //reg.Register<IServiceObjectProvider<IColorsGameDataBackQuery>,
            //    DependencyInjectionServiceObjectProviderAdapter<IColorsGameDataBackQuery, IColorsGameDataBackQuery>>();

            container = fac.CreateContainer(reg);
        }
    }
}
