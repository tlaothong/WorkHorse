using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using SpecFlowAssist;
using TheS.Casinova.TwoWins.DAL;
using TheS.Casinova.TwoWins.BackServices;

namespace TheS.Casinova.TwoWins.WebExecutors.Specs.Steps
{
    [Binding]
    public class TwoWinGameStepsBase
    {
        protected ListGameRoundInfoExecutor ListGameRoundInfo
        {
            get
            {
                return ScenarioContext.Current.Get<ListGameRoundInfoExecutor>();
            }
        }

        protected GetGameStatusExecutor GetGameStatus
        {
            get 
            {
                return ScenarioContext.Current.Get<GetGameStatusExecutor>();
            }
        }

        protected ListSingleActionLogExecutor ListSingleActionLog
        {
            get
            {
                return ScenarioContext.Current.Get<ListSingleActionLogExecutor>();
            }
        }

        protected ListGamePlayInfoExecutor ListGamePlayInfo
        {
            get
            {
                return ScenarioContext.Current.Get<ListGamePlayInfoExecutor>();
            }
        }

        protected ListBetDataExecutor ListBetData
        {
            get
            {
                return ScenarioContext.Current.Get<ListBetDataExecutor>();
            }
        }

        protected ListRangeActionLogExecutor ListRangeActionLog
        {
            get
            {
                return ScenarioContext.Current.Get<ListRangeActionLogExecutor>();
            }
        }

        protected ListBetLogInfoExecutor ListBetLogInfo
        {
            get
            {
                return ScenarioContext.Current.Get<ListBetLogInfoExecutor>();
            }
        }

        protected SingleBetExecutor SingleBet
        {
            get
            {
                return ScenarioContext.Current.Get<SingleBetExecutor>();
            }
        }

        protected RangeBetExecutor RangeBet
        {
            get
            {
                return ScenarioContext.Current.Get<RangeBetExecutor>();
            }
        }

        protected ChangeBetExecutor ChangeBet
        {
            get
            {
                return ScenarioContext.Current.Get<ChangeBetExecutor>();
            }
        }


        protected IListGameRoundInfo Dqr_ListGameRoundInfo
        {
            get
            {
                return ScenarioContext.Current.Get<IListGameRoundInfo>();
            }
        }

        protected IGetGameStatus Dqr_GetGameStatus
        {
            get
            {
                return ScenarioContext.Current.Get<IGetGameStatus>();
            }
        }

        protected IListSingleActionLog Dqr_ListSingleActionLog
        {
            get
            {
                return ScenarioContext.Current.Get<IListSingleActionLog>();
            }
        }

        protected IListGamePlayInfo Dqr_ListGamePlayInfo
        {
            get
            {
                return ScenarioContext.Current.Get<IListGamePlayInfo>();
            }
        }

        protected IListBetData Dqr_ListBetData
        {
            get
            {
                return ScenarioContext.Current.Get<IListBetData>();
            }
        }

        protected IListRangeActionLog Dqr_ListRangeActionLog
        {
            get
            {
                return ScenarioContext.Current.Get<IListRangeActionLog>();
            }
        }

        protected IListBetLogInfo Dqr_ListBetLogInfo 
        {
            get
            {
                return ScenarioContext.Current.Get<IListBetLogInfo>();
            }
        }

        protected ISingleBet Dac_SingleBet
        {
            get
            {
                return ScenarioContext.Current.Get<ISingleBet>();
            }
        }

        protected IRangeBet Dac_RangeBet
        {
            get
            {
                return ScenarioContext.Current.Get<IRangeBet>();
            }
        }

        protected IChangeBetInfo Dac_ChangeBet
        {
            get
            {
                return ScenarioContext.Current.Get<IChangeBetInfo>();
            }
        }
    }
}
