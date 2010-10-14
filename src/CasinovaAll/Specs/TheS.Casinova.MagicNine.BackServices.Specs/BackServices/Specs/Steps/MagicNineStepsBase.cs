using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.MagicNine.DAL;
using TechTalk.SpecFlow;

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
        
        protected IListBetLog Dqr_ListBetLog
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_Dqr_ListBetLog] as IListBetLog;
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

        protected IListGameRoundInfo Dqr_ListGameRoundInfo
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_Dqr_ListGameRoundInfo] as IListGameRoundInfo;
            }
        }
    }
}
