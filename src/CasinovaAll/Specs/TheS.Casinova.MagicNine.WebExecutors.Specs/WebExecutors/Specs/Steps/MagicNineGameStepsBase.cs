using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TheS.Casinova.MagicNine.DAL;
using TheS.Casinova.MagicNine.BackServices;
using SpecFlowAssist;

namespace TheS.Casinova.MagicNine.WebExecutors.Specs.Steps
{
    [Binding]
    public class MagicNineGameStepsBase
    {

        protected IStopAutoBet Dac_StopAutoBet
        {
            get
            {
                return ScenarioContext.Current.Get<IStopAutoBet>();
            }
        }


        protected IStartAutoBet Dac_StartAutoBet
        {
            get
            {
                return ScenarioContext.Current.Get<IStartAutoBet>();
            }
        }

        protected IListGamePlayAutoBetInfo Dqr_ListGamePlayAutoBetInfo
        {
            get
            {
                return ScenarioContext.Current.Get<IListGamePlayAutoBetInfo>();
            }
        }

        protected IListActiveGameRoundInfo Dqr_ListActiveGameRound
        {
            get
            {
                return ScenarioContext.Current.Get<IListActiveGameRoundInfo>();
            }
        }

        protected IListBetLog Dqr_ListBetLog
        {
            get
            {
                return ScenarioContext.Current.Get<IListBetLog>();
            }
        }

        protected ISingleBet Dac_SingleBet
        {
            get
            {
                return ScenarioContext.Current.Get<ISingleBet>();
            }
        }

        protected ListGamePlayAutoBetInfoExecutor ListGamePlayAutoBetInfo
        {
            get
            {
                return ScenarioContext.Current.Get<ListGamePlayAutoBetInfoExecutor>();
            }
        }

        protected StopAutoBetExecutor StopAutoBet
        {
            get
            {
                return ScenarioContext.Current.Get<StopAutoBetExecutor>();
            }
        }

        protected StartAutoBetExecutor StartAutoBet
        {
            get
            {
                return ScenarioContext.Current.Get<StartAutoBetExecutor>();
            }
        }

        protected ListActiveGameRoundInfoExecutor ListActiveGameRound
        {
            get
            {
                return ScenarioContext.Current.Get<ListActiveGameRoundInfoExecutor>();
            }
        }

        protected ListBetLogExecutor ListBetLog
        {
            get
            {
                return ScenarioContext.Current.Get<ListBetLogExecutor>();
            }
        }

        protected SingleBetExecutor SingleBet
        {
            get
            {
                return ScenarioContext.Current.Get<SingleBetExecutor>();
            }
        }
    }
}
