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
        protected IUpdatePlayerInfo Dac_PayForColorsWinnerInfo
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_Dac_UpdatePlayerInfo] as IUpdatePlayerInfo;
            }
        }

        protected ICreatePlayerActionInfo Dac_CreatePlayerActionInfo
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_Dac_CreatePlayerActionInfo] as ICreatePlayerActionInfo;
            }
        }

        protected IUpdateOnGoingTrackingID Dac_UpdateOnGoingTrackingID
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_Dac_UpdateOnGoingTrackingID] as IUpdateOnGoingTrackingID;
            }
        }

        protected IUpdateRoundWinner Dac_UpdateRoundWinner
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_Dac_UpdateRoundWinner] as IUpdateRoundWinner;
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
