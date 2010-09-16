using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Rhino.Mocks;
using TheS.Casinova.ColorsGame.BackServices;

namespace TheS.Casinova.ColorsGame.WebExecutors.Specs.Steps
{
    [Binding]
    public class CommonSteps
    {
        public const string Key_PayForWinnerExecutor = "winnerExecutor";
        public const string Key_Dac = "mockColorGameDataAccess";

        MockRepository Mocks { get { return SpecEventDefinitions.Mocks; } }

        [Given(@"The PayForColorsWinnerInfoExecutor has been created and initialized")]
        public void GivenThePayForColorsWinnerInfoExecutorHasBeenCreatedAndInitialized()
        {
            var dac = Mocks.DynamicMock<IColorsGameBackService>();

            ScenarioContext.Current[Key_Dac] = dac;
            ScenarioContext.Current[Key_PayForWinnerExecutor] = new PayForColorsWinnerInfoExecutor(dac);
        }
    }
}
