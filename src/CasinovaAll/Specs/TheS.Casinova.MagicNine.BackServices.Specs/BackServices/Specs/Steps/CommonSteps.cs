﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Rhino.Mocks;
using TheS.Casinova.MagicNine.DAL;
using TheS.Casinova.MagicNine.BackServices.BackExecutors;
using PerfEx.Infrastructure;
using PerfEx.Infrastructure.Containers.StructureMapAdapter;
using TheS.Casinova.PlayerProfile.Models;
using TheS.Casinova.MagicNine.Commands;
using PerfEx.Infrastructure.Validation;
using TheS.Casinova.MagicNine.Validators;

namespace TheS.Casinova.MagicNine.BackServices.Specs.Steps
{
    [Binding]
    public class CommonSteps
    {
        public const string Key_Dac_SingleBet = "mockDac_SingleBet";
        public const string Key_Dac_UpdatePlayerInfoBalance = "mockDac_UpdatePlayerInfoBalance";
        public const string Key_Dac_UpdateGameRoundPot = "mockDac_UpdateGameRoundPot";

        public const string Key_Dqr_GetPlayerInfo = "mockDqr_GetPlayerInfo";
        public const string Key_Dqr_GetGameRoundPot = "mockDqr_GetGameRoundPot";

        public const string Key_SingleBet = "SingleBet";

        public const string Key_StartAutoBet = "StartAutoBet";
        public const string Key_StopAutoBet = "StopAutoBet";
        public const string Key_AutoBetEngine = "AutoBetEngine";

        MockRepository Mocks { get { return SpecEventDefinitions.Mocks; } }

        [Given(@"The SingleBetExecutor has been created and initialized")]
        public void GivenTheSingleBetExecutorHasBeenCreatedAndInitialized()
        {
            var dac = Mocks.DynamicMock<IMagicNineGameDataAccess>();
            var dqr = Mocks.DynamicMock<IMagicNineGameDataBackQuery>();
            var container = Mocks.DynamicMock<IDependencyContainer>();

            ScenarioContext.Current[Key_Dac_UpdatePlayerInfoBalance] = dac;
            ScenarioContext.Current[Key_Dac_SingleBet] = dac;
            ScenarioContext.Current[Key_Dac_UpdateGameRoundPot] = dac;

            ScenarioContext.Current[Key_Dqr_GetPlayerInfo] = dqr;
            ScenarioContext.Current[Key_Dqr_GetGameRoundPot] = dqr;

            setupValidators(out container);
            ScenarioContext.Current[Key_SingleBet] = new SingleBetExecutor(container, dac, dqr);
        }

        [Given(@"The StartAutoBetExecutor has been created and initialized")]
        public void GivenTheStartAutoBetExecutorHasBeenCreatedAndInitialized()
        {
            var dac = Mocks.DynamicMock<IMagicNineGameDataAccess>();
            var dqr = Mocks.DynamicMock<IMagicNineGameDataBackQuery>();
            var svc = Mocks.DynamicMock<IAutoBetEngine>();

            ScenarioContext.Current[Key_Dac_UpdatePlayerInfoBalance] = dac;

            ScenarioContext.Current[Key_Dqr_GetPlayerInfo] = dqr;

            ScenarioContext.Current[Key_AutoBetEngine] = svc;

            ScenarioContext.Current[Key_StartAutoBet] = new StartAutoBetExecutor(svc, dac, dqr);
        }

        [Given(@"The StopAutoBetExecutor has been created and initialized")]
        public void GivenTheStนยAutoBetExecutorHasBeenCreatedAndInitialized()
        {
            var dac = Mocks.DynamicMock<IMagicNineGameDataAccess>();
            var dqr = Mocks.DynamicMock<IMagicNineGameDataBackQuery>();
            var svc = Mocks.DynamicMock<IAutoBetEngine>();

            ScenarioContext.Current[Key_AutoBetEngine] = svc;

            ScenarioContext.Current[Key_StopAutoBet] = new StopAutoBetExecutor(svc);
        }

        private static void setupValidators(out IDependencyContainer container)
        {
            var fac = new StructureMapAbstractFactory();
            var reg = fac.CreateRegistry();

            reg.Register<IValidator<UserProfile, SingleBetCommand>
                , UserProfileValidators>();

            //reg.RegisterInstance<IColorsGameDataBackQuery>
            //    (ScenarioContext.Current.Get<IColorsGameDataBackQuery>(Key_Dac_CreatePlayerActionInfo));
            //reg.Register<IServiceObjectProvider<IColorsGameDataBackQuery>,
            //    DependencyInjectionServiceObjectProviderAdapter<IColorsGameDataBackQuery, IColorsGameDataBackQuery>>();

            container = fac.CreateContainer(reg);
        }
    }
}
