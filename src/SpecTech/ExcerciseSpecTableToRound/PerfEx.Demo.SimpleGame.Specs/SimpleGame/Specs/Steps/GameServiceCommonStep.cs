using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Rhino.Mocks;
using PerfEx.Demo.SimpleGame.DAL;

namespace PerfEx.Demo.SimpleGame.Specs.Steps {
    [Binding]
    public class GameServiceCommonStep {
        public const string Key_ColorGameService = "colorGameService";
        public const string Key_Dac = "mockColorGameDataAccess";

        MockRepository Mocks { get { return SpecEventDefinitions.Mocks; } }

        [Given(@"The ColorGameService has been created and initialized")]
        public void GivenTheColorGameServiceHasBeenCreatedAndInitialized() {
            var dac = Mocks.DynamicMock<IColorGameDataAccess>();

            ScenarioContext.Current[Key_Dac] = dac;
            ScenarioContext.Current[Key_ColorGameService] = new ColorGameService(dac);
        }
    }
}
