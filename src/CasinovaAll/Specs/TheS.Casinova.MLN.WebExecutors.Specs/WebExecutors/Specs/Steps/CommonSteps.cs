using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Rhino.Mocks;
using PerfEx.Infrastructure;
using PerfEx.Infrastructure.Validation;
using PerfEx.Infrastructure.CommandPattern;
using PerfEx.Infrastructure.Containers.StructureMapAdapter;
using SpecFlowAssist;
using TheS.Casinova.Common.Services;
using TheS.Casinova.MLN.Models;
using TheS.Casinova.MLN.Commands;
using TheS.Casinova.MLN.WebExecutors;
using TheS.Casinova.MLN.BackServices;
using TheS.Casinova.MLN.Validators;
using TheS.Casinova.MLN.DAL;


namespace TheS.Casinova.MLN.WebExecutors.Specs.Steps
{
    [Binding]
    public class CommonSteps
    {

        MockRepository Mocks { get { return SpecEventDefinitions.Mocks; } }

        //Create MLN information specs initialized
        [Given(@"The CreateMLNInfoExecutor has been created and initialized")]
        public void GivenTheCreateMLNInfoExecutorHasBeenCreatedAndInitialized()
        {
            var dac = Mocks.DynamicMock<IMLNModuleBackService>();

            IDependencyContainer container;

            setupValidators(out container);

            ScenarioContext.Current.Set<ICreateMLNInfo>(dac);
            ScenarioContext.Current.Set<CreateMLNInfoExecutor>(
               new CreateMLNInfoExecutor(dac, container));
        }

        //List MLN information specs initialized
        [Given(@"The ListMLNInfoExecutor has been created and initialized")]
        public void GivenTheListMLNInfoExecutorHasBeenCreatedAndInitialized()
        {
            var dqr = Mocks.DynamicMock<IMLNModuleDataQuery>();

            IDependencyContainer container;

            setupValidators(out container);

            ScenarioContext.Current.Set<IListMLNInfo>(dqr);
            ScenarioContext.Current.Set<ListMLNInfoExecutor>(
               new ListMLNInfoExecutor(dqr, container));
        }

        //List downline by level specs initialized
        [Given(@"The ListDownLineByLevelExecutor has been created and initialized")]
        public void GivenTheListDownLineByLevelExecutorHasBeenCreatedAndInitialized()
        {
            var dqr = Mocks.DynamicMock<IMLNModuleDataQuery>();

            IDependencyContainer container;

            setupValidators(out container);

            ScenarioContext.Current.Set<IListDownLineByLevel>(dqr);
            ScenarioContext.Current.Set<ListDownLineByLevelExecutor>(
               new ListDownLineByLevelExecutor(dqr, container));
        }
       
        private static void setupValidators(out IDependencyContainer container)
        {
            var fac = new StructureMapAbstractFactory();
            var reg = fac.CreateRegistry();

            reg.Register<IValidator<MLNInformation, NullCommand>
                , DataAnnotationValidator<MLNInformation, NullCommand>>();

            reg.Register<IValidator<MLNInformation, CreateMLNInfoCommand>
              , MLNInformation_CreateMLNInfoValidators>();

            reg.Register<IValidator<MLNInformation, ListDownLineByLevelCommand>
              , MLNInformation_ListDownLineByLevelValidators>();

            container = fac.CreateContainer(reg);
        }
    }
}