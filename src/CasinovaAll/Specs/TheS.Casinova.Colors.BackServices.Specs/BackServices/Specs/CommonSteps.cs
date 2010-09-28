using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rhino.Mocks;
using TechTalk.SpecFlow;
using TheS.Casinova.Colors.DAL;
using TheS.Casinova.Colors.BackServices.BackExecutors;

namespace TheS.Casinova.Colors.BackServices.Specs
{
    [Binding]
    public class CommonSteps
    {
        public const string Key_Dac = "mockColorsGameDataAccess";
        public const string Key_PayForColorsWinnerInfoExecutor = "PayForColorsWinnerInfoExecutor";

        MockRepository Mocks { get { return SpecEventDefinitions.Mocks; } }

        [Given(@"The PayForColorsWinnerInfoExecutor has been created and initialized")]
        public void GivenThePayForColorsWinnerInfoExecutorHasBeenCreatedAndInitialized()
        {
            var dac = Mocks.DynamicMock<IColorsGameDataAccess>();

            ScenarioContext.Current[Key_Dac] = dac;
            ScenarioContext.Current[Key_PayForColorsWinnerInfoExecutor] = new PayForColorsWinnerInfoExecutor(dac);
        }
    }
}
