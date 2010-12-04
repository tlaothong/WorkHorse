using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Rhino.Mocks;
using TheS.Casinova.PlayerAccount.DAL;
using TheS.Casinova.PlayerAccount.BackServices.BackExecutors;
using PerfEx.Infrastructure;
using PerfEx.Infrastructure.Containers.StructureMapAdapter;
using TheS.Casinova.PlayerAccount.Models;
using TheS.Casinova.PlayerAccount.Commands;
using TheS.Casinova.PlayerAccount.BackServices.Validators;
using PerfEx.Infrastructure.Validation;
using SpecFlowAssist;
using TheS.Casinova.PlayerProfile.Models;

namespace TheS.Casinova.PlayerAccount.BackServices.Specs.Steps
{
    [Binding]
    public class CommonSteps
    {
        //public const string Key_Dac_CreatePlayerAccount = "mockDac_CreatePlayerAccount";
        //public const string Key_Dac_CancelPlayerAccount = "mockDac_CancelPlayerAccount";

        public const string Key_Dqr_GetPlayerAccount = "mockDqr_GetPlayerAccount";
        public const string Key_Dqr_GetUserProfile = "mcokDqr_GetUserProfile";
        public const string Key_Dqr_GetPlayerAccountByAccountType = "mockDqr_GetPlayerAccountByAccountType";

        //public const string Key_CreatePlayerAccount = "CreatePlayerAccount";
        //public const string Key_CancelPlayerAccount = "CancelPlayerAccount";

        MockRepository Mocks { get { return SpecEventDefinitions.Mocks; } }

        [Given(@"The CreatePlayerAccountExecutor has been created and initialized")]
        public void GivenTheCreatePlayerAccountExecutorHasBeenCreatedAndInitialized()
        {
            var dac = Mocks.DynamicMock<IPlayerAccountDataAccess>();
            var dqr = Mocks.DynamicMock<IPlayerAccountDataBackQuery>();
            var container = Mocks.DynamicMock<IDependencyContainer>();

            ScenarioContext.Current.Set<DAL.ICreatePlayerAccount>(dac);
            ScenarioContext.Current.Set<IGetPlayerAccountInfo>(dqr);

            ScenarioContext.Current.Set<IPlayerAccountDataBackQuery>(dqr);

            setupValidators(out container);

            ScenarioContext.Current.Set<CreatePlayerAccountExecutor>(
                new CreatePlayerAccountExecutor(container, dac));
        }

        [Given(@"The EditPlayerAccountExecutor has been created and initialized")]
        public void GivenTheEditPlayerAccountExecutorHasBeenCreatedAndInitialized()
        {
            var dac = Mocks.DynamicMock<IPlayerAccountDataAccess>();
            var dqr = Mocks.DynamicMock<IPlayerAccountDataBackQuery>();
            var container = Mocks.DynamicMock<IDependencyContainer>();

            ScenarioContext.Current.Set<DAL.IEditPlayerAccount>(dac);
            ScenarioContext.Current.Set<IGetPlayerAccountInfoByAccountType>(dqr);

            ScenarioContext.Current.Set<IPlayerAccountDataBackQuery>(dqr);

            setupValidators(out container);
            ScenarioContext.Current.Set<EditPlayerAccountExecutor>(
                new EditPlayerAccountExecutor(container, dac));
        }


        [Given(@"The CancelPlayerAccountExecutor has been created and initialized")]
        public void GivenTheCancelPlayerAccountExecutorHasBeenCreatedAndInitialized()
        {
            var dac = Mocks.DynamicMock<IPlayerAccountDataAccess>();
            var dqr = Mocks.DynamicMock<IPlayerAccountDataBackQuery>();
            var container = Mocks.DynamicMock<IDependencyContainer>();

            ScenarioContext.Current.Set<DAL.ICancelPlayerAccount>(dac);
            ScenarioContext.Current.Set<IGetUserProfile>(dqr);
            ScenarioContext.Current.Set<IGetPlayerAccountInfoByAccountType>(dqr);

            ScenarioContext.Current.Set<IPlayerAccountDataBackQuery>(dqr);

            setupValidators(out container);
            ScenarioContext.Current.Set<CancelPlayerAccountExecutor>(
                new CancelPlayerAccountExecutor(container, dac));
        }

        [Given(@"The ActivatePlayerAccount has been created and initialized")]
        public void GivenTheActivatePlayerAccountHasBeenCreatedAndInitialized()
        {
            var dac = Mocks.DynamicMock<IPlayerAccountDataAccess>();
            var dqr = Mocks.DynamicMock<IPlayerAccountDataBackQuery>();
            var container = Mocks.DynamicMock<IDependencyContainer>();

            ScenarioContext.Current.Set<DAL.IActivatePlayerAccount>(dac);
            ScenarioContext.Current.Set<IGetUserProfile>(dqr);
            ScenarioContext.Current.Set<IGetPlayerAccountInfoByAccountType>(dqr);

            ScenarioContext.Current.Set<IPlayerAccountDataBackQuery>(dqr);

            setupValidators(out container);
            ScenarioContext.Current.Set<ActivatePlayerAccountExecutor>(
                new ActivatePlayerAccountExecutor(container, dac));
        }

        private static void setupValidators(out IDependencyContainer container)
        {
            var fac = new StructureMapAbstractFactory();
            var reg = fac.CreateRegistry();

            reg.Register<IValidator<PlayerAccountInformation, CreatePlayerAccountCommand>
                , PlayerAccountInfo_CreatePlayerAccountValidators>();
            reg.Register<IValidator<PlayerAccountInformation, EditPlayerAccountCommand>
                , PlayerAccountInfo_EditPlayerAccountInfoValidators>();
            reg.Register<IValidator<PlayerAccountInformation, CancelPlayerAccountCommand>
                , PlayerAccountInfo_CancelPlayerAccountInfoValidators>();
            reg.Register<IValidator<UserProfile, CancelPlayerAccountCommand>
                , UserProfile_CancelPlayerAccountValidators>();
            reg.Register<IValidator<PlayerAccountInformation, ActivatePlayerAccountCommand>
                , PlayerAccountInfo_ActivatePlayerAccountValidators>();
            reg.Register<IValidator<UserProfile, ActivatePlayerAccountCommand>
                , UserProfile_ActivatePlayerAccountValidators>();


            reg.RegisterInstance<IPlayerAccountDataBackQuery>
                (ScenarioContext.Current.Get<IPlayerAccountDataBackQuery>());
            reg.Register<IServiceObjectProvider<IPlayerAccountDataBackQuery>,
                DependencyInjectionServiceObjectProviderAdapter<IPlayerAccountDataBackQuery, IPlayerAccountDataBackQuery>>();

            reg.RegisterInstance<IPlayerAccountDataBackQuery>
                (ScenarioContext.Current.Get<IPlayerAccountDataBackQuery>());
            reg.Register<IServiceObjectProvider<IPlayerAccountDataBackQuery>,
                DependencyInjectionServiceObjectProviderAdapter<IPlayerAccountDataBackQuery, IPlayerAccountDataBackQuery>>();
            container = fac.CreateContainer(reg);
        }
    }
}
