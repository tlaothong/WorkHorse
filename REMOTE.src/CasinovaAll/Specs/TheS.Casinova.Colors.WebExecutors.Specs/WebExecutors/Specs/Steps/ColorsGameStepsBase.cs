using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TheS.Casinova.Colors.DAL;
using TheS.Casinova.Colors.BackServices;
using SpecFlowAssist;

namespace TheS.Casinova.Colors.WebExecutors.Specs.Steps
{
    public class ColorsGameStepsBase
    {
        protected CreateGameRoundConfigExecutor CreateGameRound 
        {
            get 
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_Dac_CreateGameRoundConfig] as CreateGameRoundConfigExecutor;
            }
        }

        protected BetColorsExecutor BetColor
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_Dac_BetColor] as BetColorsExecutor;
            }
        }

        protected GetGameResultExecutor GetGameResult
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_Dqr_GetGameResult] as GetGameResultExecutor;
            }
        }

        protected PayForColorsWinnerInfoExecutor PayForWinnerInfo
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_Dac_PayForWinnerInfo] as PayForColorsWinnerInfoExecutor;
            }
        }

        protected ListActiveGameRoundsExecutor ActiveGameRoundsExecutor
        {
            get
            {
                //return ScenarioContext.Current[
                //    CommonSteps.Key_Dqr_ListActiveGameRoundsExecutor] as ListActiveGameRoundsExecutor;
                return ScenarioContext.Current.Get<ListActiveGameRoundsExecutor>();
            }
        }

        protected ListGamePlayInfoExecutor GamePlayInfoExecutor
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_Dqr_ListGamePlayInfo] as ListGamePlayInfoExecutor;
            }
        }

        protected IColorsGameDataQuery Dac
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_Dac] as IColorsGameDataQuery;
            }
        }

        protected IColorsGameBackService BackDac
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_Dac] as IColorsGameBackService;
            }
        }

        protected IGameTableBackService BackDac_GameTable
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_Dac] as IGameTableBackService;
            }
        }
    }
}
