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
                return ScenarioContext.Current.Get<ICreatePlayerAccount>();
            }
        }

        protected IGetPlayerAccount Dqr_GetPlayerAccount
        {
            get
            {
                return ScenarioContext.Current.Get<IGetPlayerAccount>();
            }
        }


        protected ICancelPlayerAccount Dac_CancelPlayerAccount
        {
            get
            {
                return ScenarioContext.Current.Get<ICancelPlayerAccount>();
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
                return ScenarioContext.Current.Get<CreatePlayerAccountExecutor>();
            }
        }

        protected GetPlayerAccountExecutor GetPlayerAccount
        {
            get
            {
                return ScenarioContext.Current.Get<GetPlayerAccountExecutor>();
            }
        }

        protected CancelPlayerAccountExecutor CancelPlayerAccount
        {
            get
            {
                return ScenarioContext.Current.Get<CancelPlayerAccountExecutor>();
            }
        }

        protected ListPlayerAccountExecutor ListPlayerAccount
        {
            get
            {
                return ScenarioContext.Current.Get<ListPlayerAccountExecutor>();
            }
        }

        protected EditPlayerAccountExecutor EditPlayerAccount
        {
            get
            {
                return ScenarioContext.Current.Get<EditPlayerAccountExecutor>();
            }
        }
    }
}
