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

namespace TheS.Casinova.PlayerAccount.BackServices.Specs.Steps
{
    [Binding]
    public class CommonSteps
    {
        public const string Key_Dac_CreatePlayerAccountInfo = "mockDac_CreatePlayerAccountInfo";
        public const string Key_Dac_CancelPlayerAccountInfo = "mockDac_CancelPlayerAccountInfo";

        public const string Key_Dqr_GetPlayerAccountInfo = "mockDqr_GetPlayerAccountInfo";

        public const string Key_CreatePlayerAccountInfo = "CreatePlayerAccountInfo";
        public const string Key_CancelPlayerAccountInfo = "CancelPlayerAccountInfo";

        MockRepository Mocks { get { return SpecEventDefinitions.Mocks; } }

        [Given(@"The CreatePlayerAccountExecutor has been created and initialized")]
        public void GivenTheCreatePlayerAccountExecutorHasBeenCreatedAndInitialized()
        {
            var dac = Mocks.DynamicMock<IPlayerAccountDataAccess>();
            var dqr = Mocks.DynamicMock<IPlayerAccountDataBackQuery>();
            var container = Mocks.DynamicMock<IDependencyContainer>();

            ScenarioContext.Current[Key_Dac_CancelPlayerAccountInfo] = dac;

            setupValidators(out container);
            ScenarioContext.Current[Key_CreatePlayerAccountInfo] = new CreatePlayerAccountExecutor(container, dac);
        }

        private static void setupValidators(out IDependencyContainer container)
        {
            var fac = new StructureMapAbstractFactory();
            var reg = fac.CreateRegistry();

            reg.Register<IValidator<PlayerAccountInformation, CreatePlayerAccountCommand>
                , PlayerAccountInfo_CreatePlayerAccountValidators>();

            reg.RegisterInstance<IPlayerAccountDataBackQuery>
                (ScenarioContext.Current.Get<IPlayerAccountDataBackQuery>());
            reg.Register<IServiceObjectProvider<IPlayerAccountDataBackQuery>,
                DependencyInjectionServiceObjectProviderAdapter<IPlayerAccountDataBackQuery, IPlayerAccountDataBackQuery>>();

            container = fac.CreateContainer(reg);
        }
    }
}
