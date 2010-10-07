using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rhino.Mocks;
using TechTalk.SpecFlow;
using TheS.Casinova.Colors.DAL;
using TheS.Casinova.Colors.BackServices.BackExecutors;
using TheS.Casinova.Colors.Models;

namespace TheS.Casinova.Colors.BackServices.Specs
{
    [Binding]
    public class CommonSteps
    {
        public const string Key_Dac_UpdatePlayerInfoBalance = "mockDac_UpdatePlayerInfoBalance";
        public const string Key_Dac_CreatePlayerActionInfo = "mockDac_CreatePlayerActionInfo";
        public const string Key_Dac_UpdateOnGoingTrackingID = "mockDac_UpdateOnGoingTrackingID";
        public const string Key_Dac_UpdateRoundWinner = "mockDac_UpdateRoundWinner";

        public const string Key_Dqr_GetPlayerInfo = "mockDqr_GetPlayerInfo";
        public const string Key_Dqr_ListPlayerActionInfo = "mockDqr_ListPlayerActionInfo";
        public const string Key_Dqr_GetRoundInfo = "mockDqr_GetRoundInfo";

        public const string Key_PayForColorsWinnerInfoExecutor = "PayForColorsWinnerInfoExecutor";
        public const string Key_BetColorExecutor = "BetColorExecutor";

        MockRepository Mocks { get { return SpecEventDefinitions.Mocks; } }

        [Given(@"The PayForColorsWinnerInfoExecutor has been created and initialized")]
        public void GivenThePayForColorsWinnerInfoExecutorHasBeenCreatedAndInitialized()
        {
            var dac = Mocks.DynamicMock<IColorsGameDataAccess>();
            var dqr = Mocks.DynamicMock<IColorsGameDataBackQuery>();

            ScenarioContext.Current[Key_Dac_UpdatePlayerInfoBalance] = dac; 
            ScenarioContext.Current[Key_Dac_CreatePlayerActionInfo] = dac;
            ScenarioContext.Current[Key_Dac_UpdateRoundWinner] = dac;
            ScenarioContext.Current[Key_Dac_UpdateOnGoingTrackingID] = dac;

            ScenarioContext.Current[Key_Dqr_GetPlayerInfo] = dqr;
            ScenarioContext.Current[Key_Dqr_ListPlayerActionInfo] = dqr;
            ScenarioContext.Current[Key_Dqr_GetRoundInfo] = dqr;

            ScenarioContext.Current[Key_PayForColorsWinnerInfoExecutor] = new PayForColorsWinnerInfoExecutor(dac, dqr);
        }

        [Given(@"The BetColorExecutor has been created and initialized")]
        public void GivenTheBetColorExecutorHasBeenCreatedAndInitialized()
        {
            var dac = Mocks.DynamicMock<IColorsGameDataAccess>();
            var dqr = Mocks.DynamicMock<IColorsGameDataBackQuery>();

            ScenarioContext.Current[Key_Dac_UpdatePlayerInfoBalance] = dac;
            ScenarioContext.Current[Key_Dac_CreatePlayerActionInfo] = dac;

            ScenarioContext.Current[Key_Dqr_GetPlayerInfo] = dqr;

            ScenarioContext.Current[Key_BetColorExecutor] = new BetColorExecutor(dac, dqr);
        }
    }
}
