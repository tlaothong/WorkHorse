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
using TheS.Casinova.PlayerAccount.Validator;

namespace TheS.Casinova.PlayerAccount.WebExecutors.Specs.Steps
{
    [Binding]
    public class CommonSteps
    {

        MockRepository Mocks { get { return SpecEventDefinitions.Mocks; } }

        //Cancel player account specs initialized
        [Given(@"The CancelPlayerAccountExecutor has been created and initialized")]
        public void GivenTheCancelPlayerAccountExecutorHasBeenCreatedAndInitialized()
        {
            var dac = Mocks.DynamicMock<IPlayerAccountModuleBackService>();

            IDependencyContainer container;

            setupValidators(out container);

            ScenarioContext.Current.Set<ICancelPlayerAccount>(dac);
            ScenarioContext.Current.Set<CancelPlayerAccountExecutor>(
               new CancelPlayerAccountExecutor(dac, container));
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

            IDependencyContainer container;

            setupValidators(out container);

            ScenarioContext.Current.Set<IGetPlayerAccount>(dqr);
            ScenarioContext.Current.Set<GetPlayerAccountExecutor>(
               new GetPlayerAccountExecutor(dqr, container));
        }

        //Edit player account specs initialized
        [Given(@"The EditPlayerAccountExecutor has been created and initialized")]
        public void GivenTheEditPlayerAccountExecutorHasBeenCreatedAndInitialized()
        {
            var dac = Mocks.DynamicMock<IPlayerAccountModuleBackService>();

            IDependencyContainer container;

            setupValidators(out container);

            ScenarioContext.Current.Set<IEditPlayerAccount>(dac);
            ScenarioContext.Current.Set<EditPlayerAccountExecutor>(
               new EditPlayerAccountExecutor(dac, container));
        }

        //Create player account specs initialized
        [Given(@"The CreatePlayerAccountExecutor has been created and initialized")]
        public void GivenTheCreatePlayerAccountExecutorHasBeenCreatedAndInitialized()
        {
            var dac = Mocks.DynamicMock<IPlayerAccountModuleBackService>();

            IDependencyContainer container;

            setupValidators(out container);

            ScenarioContext.Current.Set<ICreatePlayerAccount>(dac);
            ScenarioContext.Current.Set<CreatePlayerAccountExecutor>(
               new CreatePlayerAccountExecutor(dac, container));
        }

        private static void setupValidators(out IDependencyContainer container)
        {
            var fac = new StructureMapAbstractFactory();
            var reg = fac.CreateRegistry();

            reg.Register<IValidator<PlayerAccountInformation, ListPlayerAccountCommand>
                , DataAnnotationValidator<PlayerAccountInformation, ListPlayerAccountCommand>>();

            reg.Register<IValidator<PlayerAccountInformation, GetPlayerAccountCommand>
              , DataAnnotationValidator<PlayerAccountInformation, GetPlayerAccountCommand>>();

            reg.Register<IValidator<PlayerAccountInformation, GetPlayerAccountCommand>
               , PlayerAccountInformation_GetPlayerAccountValidators>();

            reg.Register<IValidator<PlayerAccountInformation, CreatePlayerAccountCommand>
             , PlayerAccountInformation_CreatePlayerAccountValidators>();

            reg.Register<IValidator<PlayerAccountInformation, CreatePlayerAccountCommand>
             , DataAnnotationValidator<PlayerAccountInformation, CreatePlayerAccountCommand>>();

            reg.Register<IValidator<PlayerAccountInformation, EditPlayerAccountCommand>
            , PlayerAccountInformation_EditPlayerAccountValidators>();

            reg.Register<IValidator<PlayerAccountInformation, EditPlayerAccountCommand>
             , DataAnnotationValidator<PlayerAccountInformation, EditPlayerAccountCommand>>();

            reg.Register<IValidator<PlayerAccountInformation, CancelPlayerAccountCommand>
           , PlayerAccountInformation_CancelPlayerAccountValidators>();

            reg.Register<IValidator<PlayerAccountInformation, CancelPlayerAccountCommand>
             , DataAnnotationValidator<PlayerAccountInformation, CancelPlayerAccountCommand>>();

            container = fac.CreateContainer(reg);
        }

    }
}
