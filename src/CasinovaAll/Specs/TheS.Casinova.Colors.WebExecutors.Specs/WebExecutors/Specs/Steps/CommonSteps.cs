using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Rhino.Mocks;
using TheS.Casinova.Colors.DAL;
using TheS.Casinova.Colors.BackServices;

namespace TheS.Casinova.Colors.WebExecutors.Specs.Steps
{
    [Binding]
    public class CommonSteps
    {
        public const string Key_Dac_BetColor = "BetExecutor";
        public const string Key_Dqr_GetBalance = "GetBalance";
        public const string Key_Dqr_GetGameResult = "GetGameResultExecutor";
        public const string Key_Dac_PayForWinnerInfo = "PayForWinnerExecutor";
        public const string Key_Dqr_ListActiveGameRoundsExecutor = "ActiveGameRoundsExecutor";
        public const string Key_Dqr_ListGamePlayInfo = "GamePlayInfoExecutor";
        public const string Key_Dac = "mockColorGameDataAccess";

        MockRepository Mocks { get { return SpecEventDefinitions.Mocks; } }

        //List active game round specs initialized
        [Given(@"The ActiveGameRound has been created and initialized")]
        public void GivenTheActiveGameRoundHasBeenCreatedAndInitialized()
        {
            var dac = Mocks.DynamicMock<IColorsGameDataQuery>();

            ScenarioContext.Current[Key_Dac] = dac;
            ScenarioContext.Current[Key_Dqr_ListActiveGameRoundsExecutor] = new ListActiveGameRoundsExecutor(dac);
        }

        //List game play information specs initialized
        [Given(@"The GamePlayInformation has been created and initialized")]
        public void GivenTheGamePlayInformationHasBeenCreatedAndInitialized()
        {
            var dac = Mocks.DynamicMock<IColorsGameDataQuery>();

            ScenarioContext.Current[Key_Dac] = dac;
            ScenarioContext.Current[Key_Dqr_ListGamePlayInfo] = new ListGamePlayInfoExecutor(dac);
        }

        //Pay For Colors Winner Information specs initialized
        [Given(@"The PayForcolorsWinnerInfo has been created and initialized")]
        public void GivenThePayForcolorsWinnerInfoHasBeenCreatedAndInitialized()
        {
            var dac = Mocks.DynamicMock<IColorsGameBackService>();

            ScenarioContext.Current[Key_Dac] = dac;
            ScenarioContext.Current[Key_Dac_PayForWinnerInfo] = new PayForColorsWinnerInfoExecutor(dac);
        }

        //Game round information specs initialized
        [Given(@"The GameRoundInformation has been created and initialized")]
        public void GivenTheGameRoundInformationHasBeenCreatedAndInitialized()
        {
            var dac = Mocks.DynamicMock<IColorsGameDataQuery>();

            ScenarioContext.Current[Key_Dac] = dac;
            ScenarioContext.Current[Key_Dqr_GetGameResult] = new GetGameResultExecutor(dac);
        }

        //Bet information space initialized
        [Given(@"The BetInformation has been created and initialized")]
        public void GivenTheBetInformationHasBeenCreatedAndInitialized()
        {
            var dac = Mocks.DynamicMock<IColorsGameBackService>();
            var dqr = Mocks.DynamicMock<IColorsGameDataQuery>();

            ScenarioContext.Current[Key_Dac] = dac;
            ScenarioContext.Current[Key_Dqr_GetBalance] = dqr;
            ScenarioContext.Current[Key_Dac_BetColor] = new BetColorsExecutor(dac,dqr);
        }

    }
}
