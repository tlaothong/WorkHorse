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

        public const string Key_Dqr_ListBetLog = "mockDqr_ListBetLog";
        public const string Key_Dqr_GetPlayerInfo = "mockDqr_GetPlayerInfo";

        MockRepository Mocks { get { return SpecEventDefinitions.Mocks; } }
    }
}
