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
    public class CommonSteps
    {
        public const string Key_Dac = "mockColorsGameDataAccess";
        public const string Key_Dqr = "mockColorsGameDataBackQuery";
        public const string Key_PayForColorsWinnerInfoExecutor = "PayForColorsWinnerInfoExecutor";
        public const string Key_SaveTableConfigurationExecutor = "SaveTableConfiguration";
        public const string Key_CreateGameRoundExecutor = "CreateGameRoundExecutor";

        MockRepository Mocks { get { return SpecEventDefinitions.Mocks; } }

        [Given(@"The PayForColorsWinnerInfoExecutor has been created and initialized")]
        public void GivenThePayForColorsWinnerInfoExecutorHasBeenCreatedAndInitialized()
        {
            var dac = Mocks.DynamicMock<IColorsGameDataAccess>();
            var dqr = Mocks.DynamicMock<IColorsGameDataBackQuery>();

            ScenarioContext.Current[Key_Dac] = dac;
            ScenarioContext.Current[Key_Dqr] = dqr;
            ScenarioContext.Current[Key_PayForColorsWinnerInfoExecutor] = new PayForColorsWinnerInfoExecutor(dac, dqr);
        }

        [Given(@"The SaveTableConfiguration has been created and initialized")]
        public void GivenTheSaveTableConfigurationHasBeenCreatedAndInitialized()
        {
            var dac = Mocks.DynamicMock<IColorsGameDataAccess>();

            ScenarioContext.Current[Key_Dac] = dac;
            ScenarioContext.Current[Key_SaveTableConfigurationExecutor] = new SaveTableConfigurationExecutor(dac);
        }
        
        [Given(@"The CreateGameRoundExecutor has been created and initialized")]
        public void GivenTheCreateGameRoundExecutorHasBeenCreatedAndInitialized()
        {
            var dac = Mocks.StrictMock<IColorsGameDataAccess>();
            var dqr = Mocks.Stub<IColorsGameDataBackQuery>();

            ScenarioContext.Current[Key_Dac] = dac;
            ScenarioContext.Current[Key_Dqr] = dqr;
            ScenarioContext.Current[Key_CreateGameRoundExecutor] = new CreateGameRoundExecutor(dac, dqr);
        }
    }
}
