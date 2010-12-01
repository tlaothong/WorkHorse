using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Rhino.Mocks;
using TheS.Casinova.Colors.WebExecutors;
using TheS.Casinova.PlayerAccount.BackServices;
using TheS.Casinova.PlayerAccount.Commands;
using TheS.Casinova.PlayerAccount.DAL;
using PerfEx.Infrastructure;
using PerfEx.Infrastructure.Validation;
using TheS.Casinova.PlayerAccount.Models;
using PerfEx.Infrastructure.Containers.StructureMapAdapter;
using SpecFlowAssist;

namespace TheS.Casinova.PlayerAccount.WebExecutors.Specs.Steps
{
    [Binding]
    public class CommonSteps
    {
        public const string Key_Dac_CancelPlayerAccount = "mockDac_CancelPlayerAccount";
        public const string Key_CancelPlayerAccount = "mock_CancelPlayerAccount";
        public const string Key_Dqr_GetPlayerAccount = "mockDqr_GetPlayerAccount";
        public const string Key_GetPlayerAccount = "mock_GetPlayerAccount";
        public const string Key_Dac_EditPlayerAccount = "mockDac_EditPlayerAccount";
        public const string Key_EditPlayerAccount = "mock_EditPlayerAccount";
        public const string Key_Dac_CreatePlayerAccount = "mockDac_CreatePlayerAccount";
        public const string Key_CreatePlayerAccount = "mock_CreatePlayerAccount";

        MockRepository Mocks { get { return SpecEventDefinitions.Mocks; } }

        //Cancel player account specs initialized
        [Given(@"The CancelPlayerAccountExecutor has been created and initialized")]
        public void GivenTheCancelPlayerAccountExecutorHasBeenCreatedAndInitialized()
        {
            var dac = Mocks.DynamicMock<IPlayerAccountModuleBackService>();

            ScenarioContext.Current[Key_Dac_CancelPlayerAccount] = dac;
            ScenarioContext.Current[Key_CancelPlayerAccount] = new CancelPlayerAccountCommand();
        }

        //List player account specs initialized
        [Given(@"The ListPlayerAccountExecutor has been created and initialized")]
        public void GivenTheListPlayerAccountExecutorHasBeenCreatedAndInitialized()
        {
            var dqr = Mocks.DynamicMock<IPlayerAccountModuleDataQuery>();

            IDependencyContainer container;

            setupValidators(out container);

            ScenarioContext.Current.Set<IListPlayerAccount>(dqr);
            ScenarioContext.Current.Set<ListPlayerAccountExecutor>(
               new ListPlayerAccountExecutor(dqr, container));
        }

        //Get player account specs initialized
        [Given(@"The GetPlayerAccountExecutor has been created and initialized")]
        public void GivenTheGetPlayerAccountExecutorHasBeenCreatedAndInitialized()
        {
            var dqr = Mocks.DynamicMock<IPlayerAccountModuleDataQuery>();

            ScenarioContext.Current[Key_Dqr_GetPlayerAccount] = dqr;
            ScenarioContext.Current[Key_GetPlayerAccount] = new GetPlayerAccountCommand();
        }

        //Edit player account specs initialized
        [Given(@"The EditPlayerAccountExecutor has been created and initialized")]
        public void GivenTheEditPlayerAccountExecutorHasBeenCreatedAndInitialized()
        {
            var dac = Mocks.DynamicMock<IPlayerAccountModuleBackService>();

            ScenarioContext.Current[Key_Dac_EditPlayerAccount] = dac;
            ScenarioContext.Current[Key_EditPlayerAccount] = new EditPlayerAccountCommand();
        }

        //Create player account specs initialized
        [Given(@"The CreatePlayerAccountExecutor has been created and initialized")]
        public void GivenTheCreatePlayerAccountExecutorHasBeenCreatedAndInitialized()
        {
            var dac = Mocks.DynamicMock<IPlayerAccountModuleBackService>();

            ScenarioContext.Current[Key_Dac_CreatePlayerAccount] = dac;
            ScenarioContext.Current[Key_CreatePlayerAccount] = new CreatePlayerAccountCommand();
        }

        private static void setupValidators(out IDependencyContainer container)
        {
            var fac = new StructureMapAbstractFactory();
            var reg = fac.CreateRegistry();

            reg.Register<IValidator<PlayerAccountInformation, ListPlayerAccountCommand>
                , DataAnnotationValidator<PlayerAccountInformation, ListPlayerAccountCommand>>();

            container = fac.CreateContainer(reg);
        }

    }
}
