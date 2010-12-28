using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using SpecFlowAssist;
using Rhino.Mocks;
using TheS.Casinova.Twowins.BackServices;
using TheS.Casinova.TwoWins.DAL;
using TheS.Casinova.TwoWins.BackServices.BackExecutors;
using PerfEx.Infrastructure;
using PerfEx.Infrastructure.Containers.StructureMapAdapter;
using TheS.Casinova.PlayerProfile.Models;
using TheS.Casinova.TwoWins.Commands;
using TheS.Casinova.TwoWins.BackServices.Validators;
using PerfEx.Infrastructure.Validation;
using TheS.Casinova.TwoWins.Models;

namespace TheS.Casinova.TwoWins.BackServices.Specs.Steps
{
    [Binding]
    public class CommonSteps
    {
        MockRepository Mocks { get { return SpecEventDefinitions.Mocks; } }

        [Given(@"\(Twowins_SingleBet\)The SingleBetExecutor has been created and initialized")]
        public void GivenTwowins_SingleBetTheSingleBetExecutorHasBeenCreatedAndInitialized()
        {
            var dac = Mocks.DynamicMock<ITwowinsDataAccess>();
            var dqr = Mocks.DynamicMock<ITwowinsDataBackQuery>();
            var container = Mocks.DynamicMock<IDependencyContainer>();

            ScenarioContext.Current.Set<IGetUserProfile>(dqr);
            ScenarioContext.Current.Set<IGetRoundInfo>(dqr);

            ScenarioContext.Current.Set<IUpdateRoundInfo>(dac);
            ScenarioContext.Current.Set<IUpdateUserProfile>(dac);
            ScenarioContext.Current.Set<ICreateActionLogInfo>(dac);
            ScenarioContext.Current.Set<ICreateBetInfo>(dac);

            ScenarioContext.Current.Set<ITwowinsDataBackQuery>(dqr);

            setupValidators(out container);
            ScenarioContext.Current.Set<SingleBetExecutor>(
                new SingleBetExecutor(container, dac, dqr));
        }

        [Given(@"\(Twowins_RangeBet\)The RangeBetExecutor has been created and initialized")]
        public void GivenTwowins_RangeBetTheRangeBetExecutorHasBeenCreatedAndInitialized()
        {
            var dac = Mocks.DynamicMock<ITwowinsDataAccess>();
            var dqr = Mocks.DynamicMock<ITwowinsDataBackQuery>();
            var container = Mocks.DynamicMock<IDependencyContainer>();

            ScenarioContext.Current.Set<IGetUserProfile>(dqr);
            ScenarioContext.Current.Set<IGetRoundInfo>(dqr);

            ScenarioContext.Current.Set<IUpdateRoundInfo>(dac);
            ScenarioContext.Current.Set<IUpdateUserProfile>(dac);
            ScenarioContext.Current.Set<ICreateActionLogInfo>(dac);
            ScenarioContext.Current.Set<ICreateBetInfo>(dac);

            ScenarioContext.Current.Set<ITwowinsDataBackQuery>(dqr);

            setupValidators(out container);
            ScenarioContext.Current.Set<RangeBetExecutor>(
                new RangeBetExecutor(container, dac, dqr));
        }

        [Given(@"\(Twowins_ChangeBet\)The ChangeBetExecutor has been created and initialized")]
        public void GivenTwowins_ChangeBetTheChangeBetExecutorHasBeenCreatedAndInitialized()
        {
            var dac = Mocks.DynamicMock<ITwowinsDataAccess>();
            var dqr = Mocks.DynamicMock<ITwowinsDataBackQuery>();
            var container = Mocks.DynamicMock<IDependencyContainer>();

            ScenarioContext.Current.Set<IGetUserProfile>(dqr);
            ScenarioContext.Current.Set<IGetRoundInfo>(dqr);
            ScenarioContext.Current.Set<IGetBetInfo>(dqr);

            ScenarioContext.Current.Set<IUpdateRoundInfo>(dac);
            ScenarioContext.Current.Set<IUpdateUserProfile>(dac);
            ScenarioContext.Current.Set<ICreateActionLogInfo>(dac);
            ScenarioContext.Current.Set<IChangeBetInfo>(dac);

            ScenarioContext.Current.Set<ITwowinsDataBackQuery>(dqr);

            setupValidators(out container);
            ScenarioContext.Current.Set<ChangeBetExecutor>(
                new ChangeBetExecutor(container, dac, dqr));
        }

        [Given(@"\(Twowins_CalculateGameRoundWinner\)The CalculateGameRoundWinnerExecutor has been created and initialized")]
        public void GivenTwowins_CalculateGameRoundWinnerTheCalculateGameRoundWinnerExecutorHasBeenCreatedAndInitialized()
        {
            var dac = Mocks.DynamicMock<ITwowinsDataAccess>();
            var dqr = Mocks.DynamicMock<ITwowinsDataBackQuery>();
            var container = Mocks.DynamicMock<IDependencyContainer>();

            ScenarioContext.Current.Set<IListBetInfoByRoundID>(dqr);
            ScenarioContext.Current.Set<IGetRoundWinnerInfo>(dqr);
            ScenarioContext.Current.Set<IGetRoundInfo>(dqr);
            ScenarioContext.Current.Set<IUpdateRoundWinnerInfo>(dac);

            ScenarioContext.Current.Set<ITwowinsDataBackQuery>(dqr);
            
            setupValidators(out container);
            ScenarioContext.Current.Set<CalculateGameRoundWinnerExecutor>(
                new CalculateGameRoundWinnerExecutor(container, dac, dqr));
      }

        private static void setupValidators(out IDependencyContainer container)
        {
            var fac = new StructureMapAbstractFactory();
            var reg = fac.CreateRegistry();

            reg.Register<IValidator<UserProfile, SingleBetCommand>
                , UserProfile_SingleBetValidator>();
            reg.Register<IValidator<BetInformation, SingleBetCommand>
                , BetInfo_SingleBetValidator>();
            reg.Register<IValidator<UserProfile, RangeBetCommand>
                , UserProfile_RangeBetValidator>();
            reg.Register<IValidator<RangeBetInformation, RangeBetCommand>
                , RangeBetInfo_RangeBetValidator>();
            reg.Register<IValidator<UserProfile, ChangeBetInfoCommand>
                , UserProfile_ChangeBetValidator>();
            reg.Register<IValidator<BetInformation, ChangeBetInfoCommand>
                , BetInfo_ChangeBetValidator>();
            reg.Register<IValidator<RoundInformation, CalculateGameRoundWinnerCommand>
                , RoundInfo_CalculateGameRoundWinnerValidator>();

            reg.RegisterInstance<ITwowinsDataBackQuery>
                (ScenarioContext.Current.Get<ITwowinsDataBackQuery>());
            reg.Register<IServiceObjectProvider<ITwowinsDataBackQuery>,
                DependencyInjectionServiceObjectProviderAdapter<ITwowinsDataBackQuery, ITwowinsDataBackQuery>>();

            container = fac.CreateContainer(reg);
        }
    }
}
