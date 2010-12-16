using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Rhino.Mocks;
using TheS.Casinova.Colors.WebExecutors;
using PerfEx.Infrastructure.Containers.StructureMapAdapter;
using PerfEx.Infrastructure;
using TheS.Casinova.TwoWins.Models;
using TheS.Casinova.TwoWins.Commands;
using PerfEx.Infrastructure.Validation;
using TheS.Casinova.TwoWins.DAL;
using SpecFlowAssist;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.TwoWins.BackServices;
using TheS.Casinova.TwoWins.Validators;
using TheS.Casinova.Common.Services;

namespace TheS.Casinova.TwoWins.WebExecutors.Specs.Steps
{
    [Binding]
    public class CommonSteps
    {
        MockRepository Mocks { get { return SpecEventDefinitions.Mocks; } }

        //List active game round specs initialized
        [Given(@"The ListGameRoundInfoExecutor has been created and initialized")]
        public void GivenTheListGameRoundInfoExecutorHasBeenCreatedAndInitialized()
        {
            var dqr = Mocks.DynamicMock<ITwoWinsGameDataQuery>();
            IDependencyContainer container;

            setupValidators(out container);

            ScenarioContext.Current.Set<IListGameRoundInfo>(dqr);
            ScenarioContext.Current.Set<ListGameRoundInfoExecutor>(
               new ListGameRoundInfoExecutor(dqr, container));
        }

        //Get game status specs initialized
        [Given(@"The GetGameStatusExecutor has been created and initialized")]
        public void GivenTheGetGameStatusExecutorHasBeenCreatedAndInitialized()
        {
            var dqr = Mocks.DynamicMock<ITwoWinsGameDataQuery>();
            IDependencyContainer container;

            setupValidators(out container);

            ScenarioContext.Current.Set<IGetGameStatus>(dqr);
            ScenarioContext.Current.Set<GetGameStatusExecutor>(
               new GetGameStatusExecutor(dqr, container));
        }

        //List single action log specs initialized
        [Given(@"The ListSingleActionLogExecutor has been created and initialized")]
        public void GivenTheListSingleActionLogExecutorHasBeenCreatedAndInitialized()
        {
            var dqr = Mocks.DynamicMock<ITwoWinsGameDataQuery>();
            IDependencyContainer container;

            setupValidators(out container);

            ScenarioContext.Current.Set<IListSingleActionLog>(dqr);
            ScenarioContext.Current.Set<ListSingleActionLogExecutor>(
               new ListSingleActionLogExecutor(dqr, container));
        }

        //List game play information specs initialized
        [Given(@"The ListGamePlayInfoExecutor has been created and initialized")]
        public void GivenTheListGamePlayInfoExecutorHasBeenCreatedAndInitialized()
        {
            var dqr = Mocks.DynamicMock<ITwoWinsGameDataQuery>();
            IDependencyContainer container;

            setupValidators(out container);

            ScenarioContext.Current.Set<IListGamePlayInfo>(dqr);
            ScenarioContext.Current.Set<ListGamePlayInfoExecutor>(
               new ListGamePlayInfoExecutor(dqr, container));
        }

        //List bet data specs initialized
        [Given(@"The ListBetDataExecutor has been created and initialized")]
        public void GivenTheListBetDataExecutorHasBeenCreatedAndInitialized()
        {
            var dqr = Mocks.DynamicMock<ITwoWinsGameDataQuery>();
            IDependencyContainer container;

            setupValidators(out container);

            ScenarioContext.Current.Set<IListBetData>(dqr);
            ScenarioContext.Current.Set<ListBetDataExecutor>(
               new ListBetDataExecutor(dqr, container));
        }

        //List range action log specs initialized
        [Given(@"The ListRangeActionLogExecutor has been created and initialized")]
        public void GivenTheListRangeActionLogExecutorHasBeenCreatedAndInitialized()
        {
            var dqr = Mocks.DynamicMock<ITwoWinsGameDataQuery>();
            IDependencyContainer container;

            setupValidators(out container);

            ScenarioContext.Current.Set<IListRangeActionLog>(dqr);
            ScenarioContext.Current.Set<ListRangeActionLogExecutor>(
               new ListRangeActionLogExecutor(dqr, container));
        }

        //List bet log specs initialized
        [Given(@"The ListBetLogInfoExecutor has been created and initialized")]
        public void GivenTheListBetLogInfoExecutorHasBeenCreatedAndInitialized()
        {
            var dqr = Mocks.DynamicMock<ITwoWinsGameDataQuery>();
            IDependencyContainer container;

            setupValidators(out container);

            ScenarioContext.Current.Set<IListBetLogInfo>(dqr);
            ScenarioContext.Current.Set<ListBetLogInfoExecutor>(
               new ListBetLogInfoExecutor(dqr, container));
        }

        //Single bet specs initialized
        [Given(@"The SingleBetExecutor has been created and initialized")]
        public void GivenTheSingleBetExecutorHasBeenCreatedAndInitialized()
        {
            var dac = Mocks.DynamicMock<ITwoWinsGameBackService>();
            var svc = Mocks.DynamicMock<IGenerateTrackingID>();
            IDependencyContainer container;

            setupValidators(out container);

            ScenarioContext.Current.Set<ISingleBet>(dac);
            ScenarioContext.Current.Set<IGenerateTrackingID>(svc);
            ScenarioContext.Current.Set<SingleBetExecutor>(
               new SingleBetExecutor(dac, container, svc));
        }

        //Range bet specs initialized
        [Given(@"The RangeBetExecutor has been created and initialized")]
        public void GivenTheRangeBetExecutorHasBeenCreatedAndInitialized()
        {
            var dac = Mocks.DynamicMock<ITwoWinsGameBackService>();
            var svc = Mocks.DynamicMock<IGenerateTrackingID>();
            IDependencyContainer container;

            setupValidators(out container);

            ScenarioContext.Current.Set<IRangeBet>(dac);
            ScenarioContext.Current.Set<IGenerateTrackingID>(svc);
            ScenarioContext.Current.Set<RangeBetExecutor>(
               new RangeBetExecutor(dac, container, svc));
        }

        //Change bet specs initialized
        [Given(@"The ChangeBetExecutor has been created and initialized")]
        public void GivenTheChangeBetExecutorHasBeenCreatedAndInitialized()
        {
            var dac = Mocks.DynamicMock<ITwoWinsGameBackService>();
            var svc = Mocks.DynamicMock<IGenerateTrackingID>();
            IDependencyContainer container;

            setupValidators(out container);

            ScenarioContext.Current.Set<IChangeBetInfo>(dac);
            ScenarioContext.Current.Set<IGenerateTrackingID>(svc);
            ScenarioContext.Current.Set<ChangeBetExecutor>(
               new ChangeBetExecutor(dac, container, svc));
        }


        private static void setupValidators(out IDependencyContainer container)
        {
            var fac = new StructureMapAbstractFactory();
            var reg = fac.CreateRegistry();

            reg.Register<IValidator<RoundInformation, NullCommand>
                , DataAnnotationValidator<RoundInformation, NullCommand>>();

            reg.Register<IValidator<ActionLogInformation, NullCommand>
               , DataAnnotationValidator<ActionLogInformation, NullCommand>>();

            reg.Register<IValidator<TotalBetInformation, NullCommand>
           , DataAnnotationValidator<TotalBetInformation, NullCommand>>();

            reg.Register<IValidator<BetInformation, NullCommand>
          , DataAnnotationValidator<BetInformation, NullCommand>>();

            reg.Register<IValidator<BetInformation, SingleBetCommand>
               , BetInformation_SingleBetValidators>();

            reg.Register<IValidator<BetInformation, ChangeBetInfoCommand>
               , BetInformation_ChangeBetInfoValidators>();

            reg.Register<IValidator<RangeBetInformation, NullCommand>
         , DataAnnotationValidator<RangeBetInformation, NullCommand>>();

            reg.Register<IValidator<RangeBetInformation, RangeBetCommand>
               , RangeBetInformation_RangeBetValidators>();

            container = fac.CreateContainer(reg);
        }
    }
}
