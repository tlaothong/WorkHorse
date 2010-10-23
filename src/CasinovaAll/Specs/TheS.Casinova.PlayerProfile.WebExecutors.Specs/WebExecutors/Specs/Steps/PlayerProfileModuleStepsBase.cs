using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Rhino.Mocks;
using TheS.Casinova.ColorsGame;
using TheS.Casinova.PlayerProfile.BackServices;
using TheS.Casinova.PlayerProfile.DAL;

namespace TheS.Casinova.PlayerProfile.WebExecutors.Specs.Steps
{
    [Binding]
    public class PlayerProfileModuleStepsBase
    {
        protected IRegisterUser Dac_RegisterUser
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_Dac_RegisterUser] as IRegisterUser;
            }
        }

        protected ICheckUserName Dqr_CheckUserName
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_Dqr_CheckUserName] as ICheckUserName;
            }
        }

        protected ICheckEmail Dqr_CheckEmail
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_Dqr_GetPlayerEmail] as ICheckEmail;
            }
        }

        protected ICheckUpline Dqr_CheckUpline
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_Dqr_CheckUpline] as ICheckUpline;
            }
        }

        protected IListActionLog Dqr_ListActioLog
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_Dqr_ListActionLog] as IListActionLog;
            }
        }

        protected IGetUserProfile Dqr_UserProfile
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_Dqr_GetUserProfile] as IGetUserProfile;
            }
        }


        protected IChangePassword Dac_ChangPassword
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_Dac_ChangePassword] as IChangePassword;
            }
        }

        protected IGetPlayerPassword Dqr_GetPlayerPassword
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_Dqr_GetPlayerPassword] as IGetPlayerPassword;
            }
        }

        protected IChangeEmail Dac_ChangeEmail
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_Dac_ChangeEmail] as IChangeEmail;
            }
        }

        protected IGetPlayerEmail Dqr_GetPlayerEmail
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_Dqr_GetPlayerEmail] as IGetPlayerEmail;
            }
        }


        protected RegisterUserExecutor RegisterUser
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_RegisterUser] as RegisterUserExecutor;
            }
        }

        protected ListActionLogExecutor ListActionLog
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_ListActionLog] as ListActionLogExecutor;
            }
        }

        protected GetUserProfileExecutor GetUserProfile
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_GetUserProfile] as GetUserProfileExecutor;
            }
        }

        protected ChangePasswordExecutor ChangePassword
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_ChangePassword] as ChangePasswordExecutor;
            }
        }

        protected ChangeEmailExecutor ChangeEmail
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_ChangeEmail] as ChangeEmailExecutor;
            }
        }
    }
}
