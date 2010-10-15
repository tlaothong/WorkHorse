using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Rhino.Mocks;
using TheS.Casinova.MagicNine.DAL;
using TheS.Casinova.MagicNine.BackServices.BackExecutors;

namespace TheS.Casinova.MagicNine.BackServices.Specs.Steps
{
    [Binding]
    public class CommonSteps
    {
        public const string Key_Dac_SingleBet = "mockDac_SingleBet";
        public const string Key_Dac_UpdatePlayerInfoBalance = "mockDac_UpdatePlayerInfoBalance";
        public const string Key_Dac_UpdateGameRoundPot = "mockDac_UpdateGameRoundPot";

        public const string Key_Dqr_GetPlayerInfo = "mockDqr_GetPlayerInfo";
        public const string Key_Dqr_GetGameRoundPot = "mockDqr_GetGameRoundPot";

        public const string Key_SingleBet = "SingleBet";

        MockRepository Mocks { get { return SpecEventDefinitions.Mocks; } }

        [Given(@"The SingleBetExecutor has been created and initialized")]
        public void GivenTheSingleBetExecutorHasBeenCreatedAndInitialized()
        {
            var dac = Mocks.DynamicMock<IMagicNineGameDataAccess>();
            var dqr = Mocks.DynamicMock<IMagicNineGameDataBackQuery>();

            ScenarioContext.Current[Key_Dac_UpdatePlayerInfoBalance] = dac;
            ScenarioContext.Current[Key_Dac_SingleBet] = dac;
            ScenarioContext.Current[Key_Dac_UpdateGameRoundPot] = dac;

            ScenarioContext.Current[Key_Dqr_GetPlayerInfo] = dqr;
            ScenarioContext.Current[Key_Dqr_GetGameRoundPot] = dqr;

            ScenarioContext.Current[Key_SingleBet] = new SingleBetExecutor(dac, dqr);
        }
    }
}
