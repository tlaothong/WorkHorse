using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Rhino.Mocks;
using ColorsGame.Web;
using TheS.Casinova.ColorsGame.BackServices;

namespace TheS.Casinova.ColorsGame.WebExecutors.Specs.Steps
{
    [Binding]
    public class CommonSteps
    {
 
        public const string Key_PayForWinnerExtor = "winnerExecutor";
        public const string Key_Dac = "mockColorGameDataAccess";

        MockRepository Mocks { get { return SpecEventDefinitions.Mocks; } }

        [Given(@"The ColorsGameService  has been created and initialized")]
       public void GivenTheColorsGameServiceHasBeenCreatedAndInitialized()
 
        {
            var dac = Mocks.DynamicMock<IColorsGameBackService>();

            ScenarioContext.Current[Key_Dac] = dac;
            ScenarioContext.Current[Key_PayForWinnerExtor] = new PayForColorsWinnerInfoExecutor(dac);
        }
    }
}
