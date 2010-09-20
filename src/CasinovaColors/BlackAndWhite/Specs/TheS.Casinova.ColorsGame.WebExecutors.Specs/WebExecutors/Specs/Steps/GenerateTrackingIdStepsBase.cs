using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TheS.Casinova.ColorsGame.BackServices;
using ColorsGame.Web;

namespace TheS.Casinova.ColorsGame.WebExecutors.Specs.Steps
{
    [Binding]
    public class GenerateTrackingIdStepsBase
    {
        protected PayForColorsWinnerInfoExecutor ColorWinnerExecutor
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_PayForWinnerExecutor] as PayForColorsWinnerInfoExecutor;
            }
        }

        protected IColorsGameBackService Dac
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_Dac] as IColorsGameBackService;
            }
        }
    }
}
