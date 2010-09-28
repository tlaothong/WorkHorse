using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Rhino.Mocks;
using TheS.Casinova.Colors.DAL;

namespace TheS.Casinova.Colors.WebExecutors.Specs.Steps
{
    [Binding]
    public class CommonSteps
    {
        public const string Key_ListActiveGameRoundsExecutor = "ActiveGameRoundsExecutor";
        public const string Key_Dac = "mockColorGameDataAccess";

        MockRepository Mocks { get { return SpecEventDefinitions.Mocks; } }

        //Color game specs initialized
        [Given(@"The ColorsGame has been created and initialized")]
        public void GivenTheGameRoundWinnerHasBeenCreatedAndInitialized()
        {
            var dac = Mocks.DynamicMock<IColorsGameDataQuery>();

            ScenarioContext.Current[Key_Dac] = dac;
            ScenarioContext.Current[Key_ListActiveGameRoundsExecutor] = new ListActiveGameRoundsExecutor(dac);
        }
    }
}
