using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TheS.Casinova.PlayerAccount.DAL;
using TheS.Casinova.PlayerAccount.BackServices.BackExecutors;


namespace TheS.Casinova.PlayerAccount.BackServices.Specs.Steps
{
    public class MagicNineStepsBase
    {
        protected ICancelPlayerAccount Dac_CancelPlayerAccount
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_Dac_CancelPlayerAccountInfo] as ICancelPlayerAccount;
            }
        }

        protected CancelPlayerAccountExecutor CancelPlayerAccountExecutor
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_CancelPlayerAccountInfo] as CancelPlayerAccountExecutor;
            }
        }
    }
}
