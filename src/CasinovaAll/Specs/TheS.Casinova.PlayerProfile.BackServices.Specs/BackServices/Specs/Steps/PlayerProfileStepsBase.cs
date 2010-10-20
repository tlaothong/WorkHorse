using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.PlayerProfile.DAL;
using TechTalk.SpecFlow;
using TheS.Casinova.PlayerProfile.BackServices.BackExecutors;

namespace TheS.Casinova.PlayerProfile.BackServices.Specs.Steps
{
    public class PlayerProfileStepsBase
    {
        protected IRegisterUser Dac_RegisterUser
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_Dac_RegisterUser] as IRegisterUser;
            }
        }

        protected IVeriflyUser Dac_VeriflyUser
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_Dac_VeriflyUser] as IVeriflyUser;
            }
        }

        protected IGetUserProfile Dqr_GetUserProfile
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_Dqr_GetUserProfile] as IGetUserProfile;
            }
        }

        protected IChangePassword Dqr_ChangePassword
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_Dac_ChangePassword] as IChangePassword;
            }
        }

        protected IChangeEmail Dqr_ChangeEmail
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_ChangeEmail] as IChangeEmail;
            }
        }

        protected RegisterUserExecutor RegisterUserExecutor
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_RegisterUser] as RegisterUserExecutor;
            }
        }

        protected VeriflyUserExecutor VeriflyUserExecutor
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_VeriflyUser] as VeriflyUserExecutor;
            }
        }

        protected ChangePasswordExecutor ChangePasswordExecutor
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_ChangePassword] as ChangePasswordExecutor;
            }
        }

        protected ChangeEmailExecutor ChangeEmailExecutor
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_ChangeEmail] as ChangeEmailExecutor;
            }
        }
    }
}
