using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TheS.Casinova.TwoWins.DAL;
using TheS.Casinova.TwoWins.BackServices;

namespace TheS.Casinova.TwoWins.WebExecutors.Specs.Steps
{
    [Binding]
    public class ColorsGameStepsBase
    {
        protected CreateGameRoundConfigExecutor CreateGameRound 
        {
            get 
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_CreateGameRoundConfig] as CreateGameRoundConfigExecutor;
            }
        }

        protected BetColorsExecutor BetColorsGame
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_BetColorsGame] as BetColorsExecutor;
            }
        }

        protected GetGameResultExecutor GetGameResult
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_GetGameResult] as GetGameResultExecutor;
            }
        }

        protected PayForColorsWinnerInfoExecutor PayForWinnerInfo
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_PayForWinnerInfo] as PayForColorsWinnerInfoExecutor;
            }
        }

        protected ListActiveGameRoundsExecutor ListActiveGameRounds
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_ListActiveGameRounds] as ListActiveGameRoundsExecutor;
            }
        }

        protected ListGamePlayInfoExecutor ListGamePlayInfo
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_ListGamePlayInfo] as ListGamePlayInfoExecutor;
            }
        }

        protected IBet Dac_BetColorsGame
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_Dac_BetColorsGame] as IBet;
            }
        }

        protected IPayForWinner Dac_PayForColorsWinner
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_Dac_PayForWinnerInfo] as IPayForWinner;
            }
        }

        protected IListGamePlayInformation Dqr_ListGamePlayInformation
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_Dqr_ListGamePlayInfo] as IListGamePlayInformation;
            }
        }

        protected IListActiveGameRounds Dqr_ListActiveGameRounds
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_Dqr_ListActiveGameRounds] as IListActiveGameRounds;
            }
        }

        protected IGetGameResult Dqr_GetGameResult
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_Dqr_GetGameResult] as IGetGameResult;
            }
        }
    }
}
