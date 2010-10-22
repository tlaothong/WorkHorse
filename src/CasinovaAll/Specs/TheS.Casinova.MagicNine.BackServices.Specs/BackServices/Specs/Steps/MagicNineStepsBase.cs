using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.MagicNine.DAL;
using TechTalk.SpecFlow;
using TheS.Casinova.MagicNine.BackServices.BackExecutors;


namespace TheS.Casinova.MagicNine.BackServices.Specs.Steps
{
    public class MagicNineStepsBase
    {
        protected ISingleBet Dac_SingleBet
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_Dac_SingleBet] as ISingleBet;
            }
        }

        protected IUpdatePlayerInfoBalance Dac_UpdatePlayerInfoBalance
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_Dac_UpdatePlayerInfoBalance] as IUpdatePlayerInfoBalance;
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

        protected IGetGameRoundPot Dqr_GetGameRoundPot
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_Dqr_GetGameRoundPot] as IGetGameRoundPot;
            }
        }

        protected IUpdateGameRoundPot Dac_UpdateGameRoundPot
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_Dac_UpdateGameRoundPot] as IUpdateGameRoundPot;
            }
        }

        protected IAutoBetEngine Svc_AutoBetEngine
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_AutoBetEngine] as IAutoBetEngine;
            }
        }

        protected SingleBetExecutor SingleBetExecutor
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_SingleBet] as SingleBetExecutor;
            }
        }

        protected StartAutoBetExecutor StartAutoBetExecutor
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_StartAutoBet] as StartAutoBetExecutor;
            }
        }

        protected StopAutoBetExecutor StopAutoBetExecutor
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_StopAutoBet] as StopAutoBetExecutor;
            }
        }
    }
}
