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

        protected IColorsGameDataBackQuery Dqr
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_Dqr] as IColorsGameDataBackQuery;
            }
        }

        protected IGetPlayerInfoQuery Dqr_GetPlayerInfo
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_Dqr_GetPlayerInfo] as IGetPlayerInfoQuery;
            }
        }

        protected IListPlayerActionInfoQuery Dqr_ListPlayerActionInfo
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_Dqr_ListPlayerActionInfo] as IListPlayerActionInfoQuery;
            }
        }

        protected IGetGameRoundInfoQuery Dqr_GetGameRoundWinner
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_Dqr_GetGameRoundWinner] as IGetGameRoundInfoQuery;
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
