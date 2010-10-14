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

        protected ListBetLogExecutor ListBetLogExecutor
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_ListBetLogExecutor] as ListBetLogExecutor;
            }
        }

        protected SingleBetExecutor SingleBetExecutor
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_SingleBetExecutor] as SingleBetExecutor;
            }
        }
    }
}
