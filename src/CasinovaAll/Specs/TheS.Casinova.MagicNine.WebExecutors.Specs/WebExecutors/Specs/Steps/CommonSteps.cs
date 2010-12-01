using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Rhino.Mocks;
using TheS.Casinova.MagicNine.WebExecutors;
using TheS.Casinova.MagicNine.DAL;
using TheS.Casinova.MagicNine.BackServices;
using PerfEx.Infrastructure;
using TheS.Casinova.MagicNine.Models;
using PerfEx.Infrastructure.Validation;
using PerfEx.Infrastructure.CommandPattern;
using PerfEx.Infrastructure.Containers.StructureMapAdapter;
using TheS.Casinova.MagicNine.Commands;
using SpecFlowAssist;


namespace TheS.Casinova.MagicNine.WebExecutors.Specs.Steps
{
    [Binding]
    public class CommonSteps
    {

        MockRepository Mocks { get { return SpecEventDefinitions.Mocks; } }

        //List bet log specs initialized
        [Given(@"The ListBetLogExecutor has been created and initialized")]
        public void GivenTheListBetLogExecutorHasBeenCreatedAndInitialized()
        {
            var dqr = Mocks.DynamicMock<IMagicNineGameDataQuery>();

            IDependencyContainer container;

            setupValidators(out container);

            ScenarioContext.Current.Set<IListBetLog>(dqr);
            ScenarioContext.Current.Set<ListBetLogExecutor>(
               new ListBetLogExecutor(dqr, container));
        }

        //Single bet specs initialized
        [Given(@"The SingleBetExecutor has been created and initialized")]
        public void GivenTheSingleBetExecutorHasBeenCreatedAndInitialized()
        {
            var dac = Mocks.DynamicMock<IMagicNineGameBackService>();

            IDependencyContainer container;
            setupValidators(out container);
            ScenarioContext.Current.Set<ISingleBet>(dac);
            ScenarioContext.Current.Set<SingleBetExecutor>(
                new SingleBetExecutor(dac, container));

        }

        //List active game round specs initialized
        [Given(@"The ListActiveGameRoundInfoExecutor has been created and initialized")]
        public void GivenTheListActiveGameRoundInfoExecutorHasBeenCreatedAndInitialized()
        {
            var dqr = Mocks.DynamicMock<IMagicNineGameDataQuery>();

            ScenarioContext.Current.Set<IListActiveGameRoundInfo>(dqr);
            ScenarioContext.Current.Set<ListActiveGameRoundInfoExecutor>(
                new ListActiveGameRoundInfoExecutor(dqr));
        }

        //List game play auto bet information specs initialized
        [Given(@"The ListGamePlayAutoBetInfoExecutor has been created and initialized")]
        public void GivenTheListGamePlayAutoBetInfoExecutorHasBeenCreatedAndInitialized()
        {
            var dqr = Mocks.DynamicMock<IMagicNineGameDataQuery>();

            IDependencyContainer container;
            setupValidators(out container);
            ScenarioContext.Current.Set<IListGamePlayAutoBetInfo>(dqr);
            ScenarioContext.Current.Set<ListGamePlayAutoBetInfoExecutor>(
                new ListGamePlayAutoBetInfoExecutor(dqr, container));
        }

        //Start  auto bet information specs initialized
        [Given(@"The StartAutoBetExecutor has been created and initialized")]
        public void GivenTheStartAutoBetExecutorHasBeenCreatedAndInitialized()
        {
            var dac = Mocks.DynamicMock<IMagicNineGameBackService>();

            IDependencyContainer container;
            setupValidators(out container);
            ScenarioContext.Current.Set<IStartAutoBet>(dac);
            ScenarioContext.Current.Set<StartAutoBetExecutor>(
                new StartAutoBetExecutor(dac, container));
        }

        //Stop auto bet information specs initialized
        [Given(@"The StopAutoBetExecutor has been created and initialized")]
        public void GivenTheStopAutoBetExecutorHasBeenCreatedAndInitialized()
        {
            var dac = Mocks.DynamicMock<IMagicNineGameBackService>();

            IDependencyContainer container;
            setupValidators(out container);
            ScenarioContext.Current.Set<IStopAutoBet>(dac);
            ScenarioContext.Current.Set<StopAutoBetExecutor>(
                new StopAutoBetExecutor(dac, container));
        }

        private static void setupValidators(out IDependencyContainer container)
        {
            var fac = new StructureMapAbstractFactory();
            var reg = fac.CreateRegistry();

            reg.Register<IValidator<BetInformation, NullCommand>
                , DataAnnotationValidator<BetInformation, NullCommand>>();

            reg.Register<IValidator<GamePlayAutoBetInformation, StartAutoBetCommand>
               , DataAnnotationValidator<GamePlayAutoBetInformation, StartAutoBetCommand>>();

            reg.Register<IValidator<GamePlayAutoBetInformation, StopAutoBetCommand>
               , DataAnnotationValidator<GamePlayAutoBetInformation, StopAutoBetCommand>>();

            reg.Register<IValidator<GamePlayAutoBetInformation, ListGamePlayAutoBetInfoCommand>
              , DataAnnotationValidator<GamePlayAutoBetInformation, ListGamePlayAutoBetInfoCommand>>();


            container = fac.CreateContainer(reg);
        }
    }
}