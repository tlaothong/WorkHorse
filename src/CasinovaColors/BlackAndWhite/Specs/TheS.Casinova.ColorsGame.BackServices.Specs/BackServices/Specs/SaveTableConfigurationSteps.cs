using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Rhino.Mocks;
using TheS.Casinova.ColorsGame.DAL;
using TheS.Casinova.ColorsGame.BackServices.BackExecutors;

namespace TheS.Casinova.ColorsGame.BackServices.Specs
{
    [Binding]
    public class SaveTableConfigurationSteps : ColorsGameStepsBase
    {
        MockRepository Mocks { get { return SpecEventDefinitions.Mocks; } }

        [Given(@"Expect the tables should be saved by calling ICreateGameTableConfiguration\.Create\(\)")]
        public void GivenExpectTheTablesShouldBeSavedByCallingICreateGameTableConfiguration_Create()
        {
            var dac = Mocks.DynamicMock<IColorsGameDataAccess>();

            SaveTableConfigurationExecutor saveTableCfgExecutor = new SaveTableConfigurationExecutor(dac);
        }

        [Given(@"The GameTableConfigurator has been created and initialized")]
        public void GivenTheGameTableConfiguratorHasBeenCreatedAndInitialized()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the tables should be saved by calling IColorsGameDataAccess\.Create\(\)")]
        public void ThenTheTablesShouldBeSavedByCallingIColorsGameDataAccess_Create()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"call SaveTableConfiguration\(name: 'config1', tables: as follows\)")]
        public void WhenCallSaveTableConfigurationNameConfig1TablesAsFollows(Table table)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
