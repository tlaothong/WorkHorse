using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TheS.Casinova.Colors.DAL;

namespace TheS.Casinova.Colors.WebExecutors.Specs.Steps
{
    [Binding]
    public class ListActiveGameRoundsStepsBase
    {
        protected ListActiveGameRoundsExecutor ActiveGameRoundsExecutor
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_ListActiveGameRoundsExecutor] as ListActiveGameRoundsExecutor;
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
    }
}
