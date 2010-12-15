using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TheS.Casinova.Colors.DAL;
using TheS.Casinova.Colors.BackServices;
using SpecFlowAssist;
using TheS.Casinova.Common.Services;

namespace TheS.Casinova.Colors.WebExecutors.Specs.Steps
{
    public class ColorsGameStepsBase
    {
        protected CreateGameRoundConfigExecutor CreateGameRound 
        {
            get 
            {
                return ScenarioContext.Current.Get<CreateGameRoundConfigExecutor>();
            }
        }

        protected BetColorsExecutor BetColorsGame
        {
            get
            {
                return ScenarioContext.Current.Get<BetColorsExecutor>();
            }
        }

        protected GetGameResultExecutor GetGameResult
        {
            get
            {
                return ScenarioContext.Current.Get<GetGameResultExecutor>();
            }
        }

        protected PayForColorsWinnerInfoExecutor PayForWinnerInfo
        {
            get
            {
                return ScenarioContext.Current.Get<PayForColorsWinnerInfoExecutor>();
            }
        }

        protected ListActiveGameRoundsExecutor ListActiveGameRounds
        {
            get
            {
                return ScenarioContext.Current.Get<ListActiveGameRoundsExecutor>();
            }
        }

        protected ListGamePlayInfoExecutor ListGamePlayInfo
        {
            get
            {
                return ScenarioContext.Current.Get<ListGamePlayInfoExecutor>();
            }
        }

        protected CheckActiveRoundToCreateExecutor CheckActiveRound
        {
            get
            {
                return ScenarioContext.Current.Get<CheckActiveRoundToCreateExecutor>();
            }
        }

        protected IBet Dac_BetColorsGame
        {
            get
            {
                return ScenarioContext.Current.Get<IBet>();
            }
        }

        protected IPayForWinner Dac_PayForColorsWinner
        {
            get
            {
                return ScenarioContext.Current.Get<IPayForWinner>();
            }
        }

        protected IListGamePlayInformation Dqr_ListGamePlayInformation
        {
            get
            {
                return ScenarioContext.Current.Get<IListGamePlayInformation>();
            }
        }

        protected IListActiveGameRounds Dqr_ListActiveGameRounds
        {
            get
            {
                return ScenarioContext.Current.Get<IListActiveGameRounds>();
            }
        }

        protected IGetGameResult Dqr_GetGameResult
        {
            get
            {
               
                return ScenarioContext.Current.Get<IGetGameResult>();
            }
        }

        protected ICreateGameTableConfigurations Dac_CreateGameRoundConfig
        {
            get
            {
                return ScenarioContext.Current.Get<ICreateGameTableConfigurations>();
            }
        }

        protected IGetGameRoundConfigurations Dqr_GetGameRoundConfig
        {
            get
            {
                return ScenarioContext.Current.Get<IGetGameRoundConfigurations>();
            }
        }

        protected ICheckActiveRoundToCreate  Dac_CheckActiveRound
        {
            get
            {
                return ScenarioContext.Current.Get<ICheckActiveRoundToCreate>();
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
