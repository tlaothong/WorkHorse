using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TheS.Casinova.MagicNine.DAL;
using TheS.Casinova.MagicNine.BackServices;

namespace TheS.Casinova.MagicNine.WebExecutors.Specs.Steps
{
    [Binding]
    public class MagicNineGameStepsBase
    {

        protected IStopAutoBet Dac_StopAutoBet
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_Dac_StopAutoBet] as IStopAutoBet;
            }
        }


        protected IStartAutoBet Dac_StartAutoBet
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_Dac_StartAutoBet] as IStartAutoBet;
            }
        }

        protected IListGamePlayAutoBetInfo Dqr_ListGamePlayAutoBetInfo
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_Dqr_ListGamePlayAutoBetInfo] as IListGamePlayAutoBetInfo;
            }
        }

        protected IListActiveGameRoundInfo Dqr_ListActiveGameRound
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_Dqr_ListActiveGameRound] as IListActiveGameRoundInfo;
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

        protected ISingleBet Dac_SingleBet
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_Dac_Singlebet] as ISingleBet;
            }
        }

        protected ListGamePlayAutoBetInfoExecutor ListGamePlayAutoBetInfo
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_ListGamePlayAutoBetInfo] as ListGamePlayAutoBetInfoExecutor;
            }
        }

        protected StopAutoBetExecutor StopAutoBet
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_StopAutoBet] as StopAutoBetExecutor;
            }
        }

        protected StartAutoBetExecutor StartAutoBet
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_StartAutoBet] as StartAutoBetExecutor;
            }
        }

        protected ListActiveGameRoundInfoExecutor ListActiveGameRound
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_ListActiveGameRound] as ListActiveGameRoundInfoExecutor;
            }
        }

        protected ListBetLogExecutor ListBetLog
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_ListBetLog] as ListBetLogExecutor;
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
    }
}
