using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using SpecFlowAssist;
using TheS.Casinova.Common.Services;
using TheS.Casinova.DevilSix.BackServices;
using TheS.Casinova.DevilSix.DAL;
using TheS.Casinova.DevilSix.WebExecutors;

namespace TheS.Casinova.DevilSix.WebExecutors.Specs.Steps
{
    [Binding]
    public class DevilSixGameStepsBase
    {

        protected IListSingleActionLog Dqr_ListSingleActionLog
        {
            get
            {
                return ScenarioContext.Current.Get<IListSingleActionLog>();
            }
        }


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

        protected ListSingleActionLogExecutor ListSingleActionLog
        {
            get
            {
                return ScenarioContext.Current.Get<ListSingleActionLogExecutor>();
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

        protected IGenerateTrackingID svc_GenerateTrackingID
        {
            get
            {
                return ScenarioContext.Current.Get<IGenerateTrackingID>();
            }
        }
    }
}
