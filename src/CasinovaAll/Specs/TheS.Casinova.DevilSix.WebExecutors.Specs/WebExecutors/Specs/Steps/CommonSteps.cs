using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Rhino.Mocks;
using PerfEx.Infrastructure;
using PerfEx.Infrastructure.Validation;
using PerfEx.Infrastructure.CommandPattern;
using SpecFlowAssist;
using TheS.Casinova.DevilSix.Validators;
using TheS.Casinova.Common.Services;
using TheS.Casinova.DevilSix.Models;
using TheS.Casinova.DevilSix.BackServices;
using PerfEx.Infrastructure.Containers.StructureMapAdapter;
using TheS.Casinova.DevilSix.DAL;
using TheS.Casinova.DevilSix.Commands;


namespace TheS.Casinova.DevilSix.WebExecutors.Specs.Steps
{
    [Binding]
    public class CommonSteps
    {
        MockRepository Mocks { get { return SpecEventDefinitions.Mocks; } }

        //List bet log specs initialized
        [Given(@"The ListBetLogExecutor has been created and initialized")]
        public void GivenTheListBetLogExecutorHasBeenCreatedAndInitialized()
        {
            var dqr = Mocks.DynamicMock<IDevilSixGameDataQuery>();

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
            var dac = Mocks.DynamicMock<IDevilSixGameBackService>();
            var svc = Mocks.DynamicMock<IGenerateTrackingID>();

            IDependencyContainer container;
            setupValidators(out container);
            ScenarioContext.Current.Set<ISingleBet>(dac);
            ScenarioContext.Current.Set<IGenerateTrackingID>(svc);
            ScenarioContext.Current.Set<SingleBetExecutor>(
                new SingleBetExecutor(dac, container, svc));

        }

        //List active game round specs initialized
        [Given(@"The ListActiveGameRoundInfoExecutor has been created and initialized")]
        public void GivenTheListActiveGameRoundInfoExecutorHasBeenCreatedAndInitialized()
        {
            var dqr = Mocks.DynamicMock<IDevilSixGameDataQuery>();

            ScenarioContext.Current.Set<IListActiveGameRoundInfo>(dqr);
            ScenarioContext.Current.Set<ListActiveGameRoundInfoExecutor>(
                new ListActiveGameRoundInfoExecutor(dqr));
        }

        //List game play auto bet information specs initialized
        [Given(@"The ListGamePlayAutoBetInfoExecutor has been created and initialized")]
        public void GivenTheListGamePlayAutoBetInfoExecutorHasBeenCreatedAndInitialized()
        {
            var dqr = Mocks.DynamicMock<IDevilSixGameDataQuery>();

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
            var dac = Mocks.DynamicMock<IDevilSixGameBackService>();
            var svc = Mocks.DynamicMock<IGenerateTrackingID>();

            IDependencyContainer container;
            setupValidators(out container);
            ScenarioContext.Current.Set<IStartAutoBet>(dac);
            ScenarioContext.Current.Set<IGenerateTrackingID>(svc);
            ScenarioContext.Current.Set<StartAutoBetExecutor>(
                new StartAutoBetExecutor(dac, container, svc));
        }

        //Stop auto bet information specs initialized
        [Given(@"The StopAutoBetExecutor has been created and initialized")]
        public void GivenTheStopAutoBetExecutorHasBeenCreatedAndInitialized()
        {
            var dac = Mocks.DynamicMock<IDevilSixGameBackService>();
            var svc = Mocks.DynamicMock<IGenerateTrackingID>();

            IDependencyContainer container;
            setupValidators(out container);
            ScenarioContext.Current.Set<IStopAutoBet>(dac);
            ScenarioContext.Current.Set<IGenerateTrackingID>(svc);
            ScenarioContext.Current.Set<StopAutoBetExecutor>(
                new StopAutoBetExecutor(dac, container, svc));
        }

        //List single action log information specs initialized
        [Given(@"The ListSingleActionLogInfoExecutor has been created and initialized")]
        public void GivenTheListSingleActionLogInfoExecutorHasBeenCreatedAndInitialized()
        {
            var dqr = Mocks.DynamicMock<IDevilSixGameDataQuery>();
           
            IDependencyContainer container;
            setupValidators(out container);

            ScenarioContext.Current.Set<IListSingleActionLog>(dqr);
            ScenarioContext.Current.Set<ListSingleActionLogExecutor>(
                new ListSingleActionLogExecutor(dqr, container));
        }

        private static void setupValidators(out IDependencyContainer container)
        {
            var fac = new StructureMapAbstractFactory();
            var reg = fac.CreateRegistry();

            reg.Register<IValidator<BetInformation, NullCommand>
                , DataAnnotationValidator<BetInformation, NullCommand>>();

            reg.Register<IValidator<BetInformation, SingleBetCommand>
               , BetInformation_SingleBetValidators>();

            reg.Register<IValidator<BetInformation, ListSingleActionLogCommand>
               , BetInformation_ListSingleActionLogValidators>();

            reg.Register<IValidator<BetInformation, ListBetLogCommand>
              , BetInformation_ListBetLogValidators>();

            reg.Register<IValidator<GamePlayAutoBetInformation, NullCommand>
              , DataAnnotationValidator<GamePlayAutoBetInformation, NullCommand>>();

            reg.Register<IValidator<GamePlayAutoBetInformation, StartAutoBetCommand>
              , GamePlayAutoBetInformation_StartAutoBetValidators>();

            reg.Register<IValidator<GamePlayAutoBetInformation, StopAutoBetCommand>
               , DataAnnotationValidator<GamePlayAutoBetInformation, StopAutoBetCommand>>();

            reg.Register<IValidator<GamePlayAutoBetInformation, StopAutoBetCommand>
               , GamePlayAutoBetInformation_StopAutoBetValidators>();

            container = fac.CreateContainer(reg);
        }
    }
}