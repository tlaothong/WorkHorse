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
        protected IUpdatePlayerInfoBalance Dac_UpdatePlayerInfoBalance
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_Dac_UpdatePlayerInfoBalance] as IUpdatePlayerInfoBalance;
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

        protected IGetPlayerInfo Dqr_GetPlayerInfo
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_Dqr_GetPlayerInfo] as IGetPlayerInfo;
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

        protected IGetRoundInfo Dqr_GetRoundInfo
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_Dqr_GetRoundInfo] as IGetRoundInfo;
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

        protected BetColorExecutor BetColorExecutor
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_BetColorExecutor] as BetColorExecutor;
            }
        }

    }
}
