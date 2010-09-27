using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TheS.Casinova.ColorsGame.DAL;

namespace TheS.Casinova.ColorsGame.WebExecutors.Specs.Steps
{
    public class GetGameRoundWinnerStepsBase
    {
        protected GetGameRoundWinnerExecutor GetGameRoundWinner
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_GameRoundWinner] as GetGameRoundWinnerExecutor;
            }
        }

        protected IColorsGameDataQuery Dac
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_DacRoundWinner] as IColorsGameDataQuery;
            }
        }

    }
}
