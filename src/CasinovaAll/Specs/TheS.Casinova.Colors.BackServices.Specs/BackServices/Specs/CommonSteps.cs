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
        public const string Key_Dqr = "mockColorsGameDataBackQuery";
        public const string Key_Dqr_GetPlayerInfo = "mockDqr_GetPlayerInfo";
        public const string Key_Dqr_ListPlayerActionInfo = "mockDqr_ListPlayerActionInfo";
        public const string Key_Dqr_GetGameRoundWinner = "mockDqr_GetGameRoundWinner";
        public const string Key_PayForColorsWinnerInfoExecutor = "PayForColorsWinnerInfoExecutor";

        MockRepository Mocks { get { return SpecEventDefinitions.Mocks; } }

        [Given(@"The PayForColorsWinnerInfoExecutor has been created and initialized")]
        public void GivenThePayForColorsWinnerInfoExecutorHasBeenCreatedAndInitialized()
        {
            var dac = Mocks.DynamicMock<IColorsGameDataAccess>();
            var dqr = Mocks.DynamicMock<IColorsGameDataBackQuery>();

            ScenarioContext.Current[Key_Dac] = dac;
            ScenarioContext.Current[Key_Dqr] = dqr;
            ScenarioContext.Current[Key_Dqr_GetPlayerInfo] = dqr;
            ScenarioContext.Current[Key_Dqr_ListPlayerActionInfo] = dqr;
            ScenarioContext.Current[Key_Dqr_GetGameRoundWinner] = dqr;
            ScenarioContext.Current[Key_PayForColorsWinnerInfoExecutor] = new PayForColorsWinnerInfoExecutor(dac, dqr);
        }
    }
}
