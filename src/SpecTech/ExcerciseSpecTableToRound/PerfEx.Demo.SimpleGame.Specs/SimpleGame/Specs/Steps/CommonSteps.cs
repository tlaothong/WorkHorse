using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Rhino.Mocks;
using PerfEx.Demo.SimpleGame.DAL;

namespace PerfEx.Demo.SimpleGame.Specs.Steps
{
    [Binding]
    public class CommonSteps
    {
        public const string Key_TableConfigurator = "tableConfigurator";
        public const string Key_Dac = "mockGameTableDataAccess";

        MockRepository Mocks { get { return SpecEventDefinitions.Mocks; } }

        [Given(@"The GameTableConfigurator has been created and initialized")]
        public void GivenTheGameTableConfiguratorHasBeenCreatedAndInitialized()
        {
            var dac = Mocks.DynamicMock<IGameTableDataAccess>();

            ScenarioContext.Current[Key_Dac] = dac;
            ScenarioContext.Current[Key_TableConfigurator] = new GameTableConfigurator(dac);
        }
    }
}
