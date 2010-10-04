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
        public const string Key_Dac_UpdatePlayerInfo = "mockDac_UpdatePlayerInfo";
        public const string Key_Dac_CreatePlayerActionInfo = "mockDac_CreatePlayerActionInfo";
        public const string Key_Dac_UpdateOnGoingTrackingID = "mockDac_UpdateOnGoingTrackingID";
        public const string Key_Dac_UpdateRoundWinner = "mockDac_UpdateRoundWinner";

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
            var eektua = Mocks.DynamicMock<IUpdateOnGoingTrackingID>();

            ScenarioContext.Current[Key_Dac_UpdatePlayerInfo] = dac; 
            ScenarioContext.Current[Key_Dac_CreatePlayerActionInfo] = dac;
            ScenarioContext.Current[Key_Dac_UpdateOnGoingTrackingID] = eektua;
            ScenarioContext.Current[Key_Dac_UpdateRoundWinner] = dac;

            ScenarioContext.Current[Key_Dqr_GetPlayerInfo] = dqr;
            ScenarioContext.Current[Key_Dqr_ListPlayerActionInfo] = dqr;
            ScenarioContext.Current[Key_Dqr_GetGameRoundWinner] = dqr;

            ScenarioContext.Current[Key_PayForColorsWinnerInfoExecutor] = new PayForColorsWinnerInfoExecutor(dac, eektua, dqr);
        }
    }
}
