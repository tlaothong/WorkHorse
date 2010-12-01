using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TheS.Casinova.PlayerAccount.BackServices;
using TheS.Casinova.PlayerAccount.WebExecutors;
using TheS.Casinova.PlayerAccount.DAL;
using SpecFlowAssist;

namespace TheS.Casinova.PlayerAccount.WebExecutors.Specs.Steps
{
    [Binding]
    public class PlayerAccountModuleStepsBase
    {
        protected ICreatePlayerAccount Dac_CreatePlayerAccount
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_Dac_CreatePlayerAccount] as ICreatePlayerAccount;
            }
        }

        protected IGetPlayerAccount Dqr_GetPlayerAccount
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_Dqr_GetPlayerAccount] as IGetPlayerAccount;
            }
        }


        protected ICancelPlayerAccount Dac_CancelPlayerAccount
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_Dac_CancelPlayerAccount] as ICancelPlayerAccount;
            }
        }

        protected IListPlayerAccount Dqr_ListPlayerAccount
        {
            get
            {
                return ScenarioContext.Current.Get<IListPlayerAccount>();
            }
        }

        protected CreatePlayerAccountExecutor CreatePlayerAccount
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_CreatePlayerAccount] as CreatePlayerAccountExecutor;
            }
        }

        protected GetPlayerAccountExecutor GetPlayerAccount
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_GetPlayerAccount] as GetPlayerAccountExecutor;
            }
        }

        protected CancelPlayerAccountExecutor CancelPlayerAccount
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_CancelPlayerAccount] as CancelPlayerAccountExecutor;
            }
        }

        protected ListPlayerAccountExecutor ListPlayerAccount
        {
            get
            {
                return ScenarioContext.Current.Get<ListPlayerAccountExecutor>();
            }
        }
    }
}
