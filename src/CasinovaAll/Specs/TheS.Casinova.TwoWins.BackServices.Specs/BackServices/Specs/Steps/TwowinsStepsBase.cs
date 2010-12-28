using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.TwoWins.DAL;
using TechTalk.SpecFlow;
using SpecFlowAssist;
using TheS.Casinova.TwoWins.BackServices.BackExecutors;

namespace TheS.Casinova.TwoWins.BackServices.Specs.Steps
{
    public class TwowinsStepsBase
    {
        protected IGetUserProfile Dqr_GetUserProfile
        {
            get
            {
                return ScenarioContext.Current.Get<IGetUserProfile>();
            }
        }

        protected IGetRoundInfo Dqr_GetRoundInfo
        {
            get
            {
                return ScenarioContext.Current.Get<IGetRoundInfo>();
            }
        }

        protected IGetRoundWinnerInfo Dqr_GetRoundWinnerInfo
        {
            get
            {
                return ScenarioContext.Current.Get<IGetRoundWinnerInfo>();
            }
        }

        protected IGetBetInfo Dqr_GetBetInfo
        {
            get
            {
                return ScenarioContext.Current.Get<IGetBetInfo>();
            }
        }

        protected IListBetInfoByRoundID Dqr_ListBetInfoByRoundID
        {
            get
            {
                return ScenarioContext.Current.Get<IListBetInfoByRoundID>();
            }
        }

        protected IUpdateRoundInfo Dac_UpdateRoundInfo
        {
            get
            {
                return ScenarioContext.Current.Get<IUpdateRoundInfo>();
            }
        }

        protected IUpdateUserProfile Dac_UpdateUserProfile
        {
            get
            {
                return ScenarioContext.Current.Get<IUpdateUserProfile>();
            }
        }

        protected ICreateActionLogInfo Dac_CreateActionLogInfo
        {
            get
            {
                return ScenarioContext.Current.Get<ICreateActionLogInfo>();
            }
        }

        protected ICreateBetInfo Dac_CreateBetInfo
        {
            get
            {
                return ScenarioContext.Current.Get<ICreateBetInfo>();
            }
        }

        protected IChangeBetInfo Dac_ChangeBetInfo
        {
            get
            {
                return ScenarioContext.Current.Get<IChangeBetInfo>();
            }
        }

        protected IUpdateRoundWinnerInfo Dac_UpdateRoundWinnerInfo
        {
            get
            {
                return ScenarioContext.Current.Get<IUpdateRoundWinnerInfo>();
            }
        }

        protected SingleBetExecutor SingleBetExecutor
        {
            get
            {
                return ScenarioContext.Current.Get<SingleBetExecutor>();
            }
        }

        protected RangeBetExecutor RangeBetExecutor
        {
            get
            {
                return ScenarioContext.Current.Get<RangeBetExecutor>();
            }
        }

        protected ChangeBetExecutor ChangeBetExecutor
        {
            get
            {
                return ScenarioContext.Current.Get<ChangeBetExecutor>();
            }
        }

        protected CalculateGameRoundWinnerExecutor CalculateGameRoundWinnerExecutor
        {
            get
            {
                return ScenarioContext.Current.Get<CalculateGameRoundWinnerExecutor>();
            }
        }
    }
}
