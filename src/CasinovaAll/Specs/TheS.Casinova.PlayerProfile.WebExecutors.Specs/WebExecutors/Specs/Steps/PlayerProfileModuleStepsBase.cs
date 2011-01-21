using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Rhino.Mocks;
using TheS.Casinova.PlayerProfile.BackServices;
using TheS.Casinova.PlayerProfile.DAL;
using SpecFlowAssist;
using TheS.Casinova.Common.Services;

namespace TheS.Casinova.PlayerProfile.WebExecutors.Specs.Steps
{
    [Binding]
    public class PlayerProfileModuleStepsBase
    {
        protected IRegisterUser Dac_RegisterUser
        {
            get
            {
                return ScenarioContext.Current.Get<IRegisterUser>();
            }
        }

        protected IListActionLog Dqr_ListActionLog
        {
            get
            {
                return ScenarioContext.Current.Get<IListActionLog>();
            }
        }

        protected IGetUserProfile Dqr_GetUserProfile
        {
            get
            {
                return ScenarioContext.Current.Get<IGetUserProfile>();
            }
        }


        protected IChangePassword Dac_ChangPassword
        {
            get
            {
                return ScenarioContext.Current.Get<IChangePassword>();
            }
        }

        protected IChangeEmail Dac_ChangeEmail
        {
            get
            {
                return ScenarioContext.Current.Get<IChangeEmail>();
            }
        }

        protected RegisterUserExecutor RegisterUser
        {
            get
            {
                return ScenarioContext.Current.Get<RegisterUserExecutor>();
            }
        }

        protected ListActionLogExecutor ListActionLog
        {
            get
            {
                return ScenarioContext.Current.Get<ListActionLogExecutor>();
            }
        }

        protected GetUserProfileExecutor GetUserProfile
        {
            get
            {
                return ScenarioContext.Current.Get<GetUserProfileExecutor>();
            }
        }

        protected ChangePasswordExecutor ChangePassword
        {
            get
            {
                return ScenarioContext.Current.Get<ChangePasswordExecutor>();
            }
        }

        protected ChangeEmailExecutor ChangeEmail
        {
            get
            {
                return ScenarioContext.Current.Get<ChangeEmailExecutor>();
            }
        }

        protected IGenerateTrackingID svc_GenerateTrackingID
        {
            get
            {
                return ScenarioContext.Current.Get<IGenerateTrackingID>();
            }
        }

        protected IMembershipServices svc_Membership
        {
            get
            {
                return ScenarioContext.Current.Get<IMembershipServices>();
            }
        }
    }
}
