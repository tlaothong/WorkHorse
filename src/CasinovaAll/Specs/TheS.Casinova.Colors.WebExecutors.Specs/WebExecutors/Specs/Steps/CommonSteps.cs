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
        public const string Key_GetGameResult = "GetGameResultExecutor";
        public const string Key_PayForWinnerInfo = "PayForWinnerExecutor";
        public const string Key_ListActiveGameRoundsExecutor = "ActiveGameRoundsExecutor";
        public const string Key_ListGamePlayInfo = "GamePlayInfoExecutor";
        public const string Key_Dac = "mockColorGameDataAccess";

        MockRepository Mocks { get { return SpecEventDefinitions.Mocks; } }

        //List active game round specs initialized
        [Given(@"The ActiveGameRound has been created and initialized")]
        public void GivenTheActiveGameRoundHasBeenCreatedAndInitialized()
        {
            var dac = Mocks.DynamicMock<IColorsGameDataQuery>();

            ScenarioContext.Current[Key_Dac] = dac;
            ScenarioContext.Current[Key_ListActiveGameRoundsExecutor] = new ListActiveGameRoundsExecutor(dac);
        }

        //List game play information specs initialized
        [Given(@"The GamePlayInformation has been created and initialized")]
        public void GivenTheGamePlayInformationHasBeenCreatedAndInitialized()
        {
            var dac = Mocks.DynamicMock<IColorsGameDataQuery>();

            ScenarioContext.Current[Key_Dac] = dac;
            ScenarioContext.Current[Key_ListGamePlayInfo] = new ListGamePlayInfoExecutor(dac);
        }

        //Pay For Colors Winner Information specs initialized
        [Given(@"The PayForcolorsWinnerInfo has been created and initialized")]
        public void GivenThePayForcolorsWinnerInfoHasBeenCreatedAndInitialized()
        {
            var dac = Mocks.DynamicMock<IColorsGameBackService>();

            ScenarioContext.Current[Key_Dac] = dac;
            ScenarioContext.Current[Key_PayForWinnerInfo] = new PayForColorsWinnerInfoExecutor(dac);
        }

        //Game round information specs initialized
        [Given(@"The GameRoundInformation has been created and initialized")]
        public void GivenTheGameRoundInformationHasBeenCreatedAndInitialized()
        {
            var dac = Mocks.DynamicMock<IColorsGameDataQuery>();

            ScenarioContext.Current[Key_Dac] = dac;
            ScenarioContext.Current[Key_GetGameResult] = new GetGameResultExecutor(dac);
        }

    }
}
