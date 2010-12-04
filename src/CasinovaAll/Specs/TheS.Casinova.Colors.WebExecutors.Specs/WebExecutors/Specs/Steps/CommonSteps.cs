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
        MockRepository Mocks { get { return SpecEventDefinitions.Mocks; } }

        //List active game round specs initialized
        [Given(@"The ListActiveGameRoundsExecutor has been created and initialized")]
        public void GivenTheListActiveGameRoundsExecutorHasBeenCreatedAndInitialized()
        {
            var dqr = Mocks.DynamicMock<IColorsGameDataQuery>();

            ScenarioContext.Current.Set<IListActiveGameRounds>(dqr);
            ScenarioContext.Current.Set<ListActiveGameRoundsExecutor>(
                new ListActiveGameRoundsExecutor(dqr));
        }

        //List game play information specs initialized
        [Given(@"The ListGamePlayInfoExecutor has been created and initialized")]
        public void GivenTheListGamePlayInfoExecutorHasBeenCreatedAndInitialized()
        {
            var dqr = Mocks.DynamicMock<IColorsGameDataQuery>();

            IDependencyContainer container;
            setupValidators(out container);
            ScenarioContext.Current.Set<IListGamePlayInformation>(dqr);
            ScenarioContext.Current.Set<ListGamePlayInfoExecutor>(
                new ListGamePlayInfoExecutor(dqr,container));
        }

        //Pay For Colors Winner Information specs initialized
        [Given(@"The PayForColorsWinnerInfoExecutor has been created and initialized")]
        public void GivenThePayForColorsWinnerInfoExecutorHasBeenCreatedAndInitialized()
        {
            var dac = Mocks.DynamicMock<IColorsGameBackService>();

            IDependencyContainer container;
            setupValidators(out container);
            ScenarioContext.Current.Set<IPayForWinner>(dac);
            ScenarioContext.Current.Set<PayForColorsWinnerInfoExecutor>(
                new PayForColorsWinnerInfoExecutor(dac, container));
        }

        //Game round information specs initialized
        [Given(@"The GetGameResultExecutor has been created and initialized")]
        public void GivenTheGetGameResultExecutorHasBeenCreatedAndInitialized()
        {
            var dqr = Mocks.DynamicMock<IColorsGameDataQuery>();

            IDependencyContainer container;
            setupValidators(out container);

            ScenarioContext.Current.Set<IGetGameResult>(dqr);
            ScenarioContext.Current.Set<GetGameResultExecutor>(
               new GetGameResultExecutor(dqr,container));
        }

        //Bet information space initialized
        [Given(@"The BetColorsExecutor has been created and initialized")]
        public void GivenTheBetColorsExecutorHasBeenCreatedAndInitialized()
        {
            var dac = Mocks.DynamicMock<IColorsGameBackService>();

            IDependencyContainer container;
            setupValidators(out container);

            ScenarioContext.Current.Set<IBet>(dac);
            ScenarioContext.Current.Set<BetColorsExecutor>(
               new BetColorsExecutor(dac, container));
        }

        //CreateGameRoundConfigurations information space initialized
        [Given(@"The CreateGameRoundConfigExecutor has been created and initialized")]
        public void GivenTheCreateGameRoundConfigExecutorHasBeenCreatedAndInitialized()
        {
            var dac = Mocks.DynamicMock<IGameTableBackService>();
            IDependencyContainer container;

            setupValidators(out container);

            ScenarioContext.Current.Set<ICreateGameTableConfigurations>(dac);
            ScenarioContext.Current.Set<CreateGameRoundConfigExecutor>(
               new CreateGameRoundConfigExecutor(dac, container));
        }

        //CheckActiveRound information space initialized
        [Given(@"The CheckActiveRoundExecutor has been created and initialized")]
        public void GivenTheCheckActiveRoundExecutorHasBeenCreatedAndInitialized()
        {
            var dac = Mocks.DynamicMock<IGameTableBackService>();
            var dqr = Mocks.DynamicMock<IColorsGameDataQuery>();
            IDependencyContainer container;

            setupValidators(out container);

            ScenarioContext.Current.Set<ICheckActiveRoundToCreate>(dac);
            ScenarioContext.Current.Set<IGetGameRoundConfigurations>(dqr);
            ScenarioContext.Current.Set<IListActiveGameRounds>(dqr);
            ScenarioContext.Current.Set<CheckActiveRoundToCreateExecutor>(
               new CheckActiveRoundToCreateExecutor(dac,dqr, container));
        }

        private static void setupValidators(out IDependencyContainer container)
        {
            var fac = new StructureMapAbstractFactory();
            var reg = fac.CreateRegistry();

            reg.Register<IValidator<GameRoundConfiguration, CreateGameRoundConfigurationCommand>
                , DataAnnotationValidator<GameRoundConfiguration, CreateGameRoundConfigurationCommand>>();

            reg.Register<IValidator<GameRoundConfiguration, CreateGameRoundConfigurationCommand>
                , GameRoundConfiguration_CreateGameRoundConfigurationValidators>();

            reg.Register<IValidator<GameRoundInformation, NullCommand>
               , DataAnnotationValidator<GameRoundInformation, NullCommand>>();

            reg.Register<IValidator<GamePlayInformation, NullCommand>
              , DataAnnotationValidator<GamePlayInformation, NullCommand>>();

            reg.Register<IValidator<PlayerActionInformation, BetCommand>
             , DataAnnotationValidator<PlayerActionInformation, BetCommand>>();

            reg.Register<IValidator<PlayerActionInformation, PayForColorsWinnerInfoCommand>
             , DataAnnotationValidator<PlayerActionInformation, PayForColorsWinnerInfoCommand>>();

            reg.Register<IValidator<PlayerActionInformation, BetCommand>
                , PlayerActionInformation_BetValidators>();

            container = fac.CreateContainer(reg);
        }

    }
}
