using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.ColorsGame.BackServices.BackExecutors;
using TechTalk.SpecFlow;
using TheS.Casinova.ColorsGame.DAL;

namespace TheS.Casinova.ColorsGame.BackServices.Specs
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

        protected IColorsGameDataBackQuery Dqr
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_Dqr] as IColorsGameDataBackQuery;
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

        protected SaveTableConfigurationExecutor SaveTableConfigurationExecutor
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_SaveTableConfigurationExecutor] as SaveTableConfigurationExecutor;
            }
        }

        protected CreateGameRoundExecutor CreateGameRoundExecutor
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_CreateGameRoundExecutor] as CreateGameRoundExecutor;
            }
        }
    }
}
