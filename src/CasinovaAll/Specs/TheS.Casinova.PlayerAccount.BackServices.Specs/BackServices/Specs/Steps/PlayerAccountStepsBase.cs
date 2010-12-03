using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TheS.Casinova.PlayerAccount.DAL;
using TheS.Casinova.PlayerAccount.BackServices.BackExecutors;
using SpecFlowAssist;

namespace TheS.Casinova.PlayerAccount.BackServices.Specs.Steps
{
    public class PlayerAccountStepsBase
    {
        protected DAL.ICreatePlayerAccount Dac_CreatePlayerAccount
        {
            get
            {
                return ScenarioContext.Current.Get<DAL.ICreatePlayerAccount>();
            }
        }

        protected DAL.IEditPlayerAccount Dac_EditPlayerAccount
        {
            get
            {
                return ScenarioContext.Current.Get<DAL.IEditPlayerAccount>();
            }
        }

        protected DAL.ICancelPlayerAccount Dac_CancelPlayerAccount 
        {
            get
            {
                return ScenarioContext.Current.Get<DAL.ICancelPlayerAccount>();
            }
        }

        protected DAL.IActivatePlayerAccount Dac_ActivatePlayerAccount
        {
            get
            {
                return ScenarioContext.Current.Get<DAL.IActivatePlayerAccount>();
            }
        }

        protected IGetPlayerAccountInfo Dqr_GetPlayerAccountInfo
        {
            get
            {
                return ScenarioContext.Current.Get<DAL.IGetPlayerAccountInfo>();
            }
        }

        protected IGetUserProfile Dqr_GetUserProfile
        {
            get
            {
                return ScenarioContext.Current.Get<IGetUserProfile>();
            }
        }

        protected IGetPlayerAccountInfoByAccountType Dqr_GetPlayerAccountInfoByAccountType
        {
            get
            {
                return ScenarioContext.Current.Get<IGetPlayerAccountInfoByAccountType>();
            }
        }
        
        protected CreatePlayerAccountExecutor CreatePlayerAccountExecutor
        {
            get
            {
                return ScenarioContext.Current.Get<CreatePlayerAccountExecutor>();
            }
        }

        protected EditPlayerAccountExecutor EditPlayerAccountExecutor
        {
            get
            {
                return ScenarioContext.Current.Get<EditPlayerAccountExecutor>();
            }
        }

        protected CancelPlayerAccountExecutor CancelPlayerAccountExecutor
        {
            get
            {
                return ScenarioContext.Current.Get<CancelPlayerAccountExecutor>();
            }
        }

        protected ActivatePlayerAccountExecutor ActivatePlayerAccountExecutor
        {
            get
            {
                return ScenarioContext.Current.Get<ActivatePlayerAccountExecutor>();
            }
        }
    }
}
