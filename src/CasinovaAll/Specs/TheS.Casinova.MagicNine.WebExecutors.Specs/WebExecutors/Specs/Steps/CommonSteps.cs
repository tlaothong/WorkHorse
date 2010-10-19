using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Rhino.Mocks;
using TheS.Casinova.Colors.WebExecutors;
using TheS.Casinova.MagicNine.DAL;
using TheS.Casinova.MagicNine.BackServices;

namespace TheS.Casinova.MagicNine.WebExecutors.Specs.Steps
{
    [Binding]
    public class CommonSteps
    {
        public const string Key_Dqr_ListActiveGameRound = "ListActiveGameRound";
        public const string Key_ListActiveGameRound = "ListActiveGameRoundExecutor";
        public const string Key_Dac_Singlebet = "SingleBet";
        public const string Key_SingleBetExecutor = "SingleBetExecutor";
        public const string Key_Dqr_ListBetLog = "ListBetLog";
        public const string Key_ListBetLogExecutor = "ListBetLogExecutor";
  

        MockRepository Mocks { get { return SpecEventDefinitions.Mocks; } }

        //List bet log specs initialized
        [Given(@"The BetInformation has been created and initialized")]
        public void GivenTheBetInformationHasBeenCreatedAndInitialized()
        {
             var dqr = Mocks.DynamicMock<IMagicNineGameDataQuery>();
             var dac = Mocks.DynamicMock<IMagicNineGameBackService>();


             ScenarioContext.Current[Key_Dac_Singlebet] = dac;
             ScenarioContext.Current[Key_Dqr_ListBetLog] = dqr;

             ScenarioContext.Current[Key_SingleBetExecutor] = new SingleBetExecutor(dac);
             ScenarioContext.Current[Key_ListBetLogExecutor] = new ListBetLogExecutor(dqr);
        }

        //List active game round specs initialized
        [Given(@"The GameRoundInformation has been created and initialized")]
        public void GivenTheGameRoundInformationHasBeenCreatedAndInitialized()
        {
            var dqr = Mocks.DynamicMock<IMagicNineGameDataQuery>();

            ScenarioContext.Current[Key_Dqr_ListActiveGameRound] = dqr;
            ScenarioContext.Current[Key_ListActiveGameRound] = new ListActiveGameRoundExecutor(dqr);
        }
    }
}
