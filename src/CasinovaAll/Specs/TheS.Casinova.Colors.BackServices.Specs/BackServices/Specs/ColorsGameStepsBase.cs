using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.Colors.DAL;
using TechTalk.SpecFlow;
using TheS.Casinova.Colors.BackServices.BackExecutors;

namespace TheS.Casinova.Colors.BackServices.Specs
{
    public class ColorsGameStepsBase
    {
        protected IColorsGameDataAccess Dac
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_Dac] as IColorsGameDataAccess;
            }
        }

        protected PayForColorsWinnerInfoExecutor PayForColorsWinnerInfoExecutor
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_PayForColorsWinnerInfoExecutor] as PayForColorsWinnerInfoExecutor;
            }
        }
    }
}
