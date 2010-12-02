using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Rhino.Mocks;
using TheS.Casinova.ColorsGame;
using TheS.Casinova.PlayerProfile.BackServices;
using TheS.Casinova.PlayerProfile.DAL;
using TheS.Casinova.PlayerProfile.Commands;

namespace TheS.Casinova.PlayerProfile.WebExecutors.Specs.Steps
{
    [Binding]
    public class CommonSteps
    {
        public const string Key_RegisterUser = "RegisterUser";
        public const string Key_Dac_RegisterUser = "mockDac_RegisterUser";
        public const string Key_Dqr_CheckUserName = "mockDqr_CheckUserName";
        public const string Key_Dqr_CheckEmail = "mockDqr_CheckEmail";
        public const string Key_Dqr_CheckUpline = "mockDqr_CheckUpline";
        public const string Key_ListActionLog = "ListActionLog";
        public const string Key_Dqr_ListActionLog = "mockDqr_ListActionLog";
        public const string Key_GetUserProfile = "GetUserProfile";
        public const string Key_Dqr_GetUserProfile = "mockDqr_GetUserProfile";
        public const string Key_ChangePassword = "ChangePassword";
        public const string Key_Dac_ChangePassword = "mockDac_ChangePassword";
        public const string Key_Dqr_GetPlayerPassword = "mockDqr_GetPlayerPassword";
        public const string Key_ChangeEmail = "ChangeEmail";
        public const string Key_Dac_ChangeEmail = "mockDac_ChangeEmail";
        public const string Key_Dqr_GetPlayerEmail = "mockDqr_GetPlayerEmail";


        MockRepository Mocks { get { return SpecEventDefinitions.Mocks; } }

        //Register user information specs initialized
        [Given(@"The RegisterUserExecutor has been created and initialized")]
        public void GivenTheRegisterUserExecutorHasBeenCreatedAndInitialized()
        {
            var dac = Mocks.DynamicMock<IPlayerProfileBackService>();
            var dqr = Mocks.DynamicMock<IPlayerProfileDataQuery>();

            ScenarioContext.Current[Key_Dac_RegisterUser] = dac;
            ScenarioContext.Current[Key_Dqr_CheckUserName] = dqr;
            ScenarioContext.Current[Key_Dqr_CheckEmail] = dqr;
            ScenarioContext.Current[Key_Dqr_CheckUpline] = dqr;
            ScenarioContext.Current[Key_RegisterUser] = new RegisterUserCommand();
        }

        //List action log  specs initialized
        [Given(@"The ListActionLogExecutor has been created and initialized")]
        public void GivenTheListActionLogExecutorHasBeenCreatedAndInitialized()
        {
            var dqr = Mocks.DynamicMock<IPlayerProfileDataQuery>();

            ScenarioContext.Current[Key_Dqr_ListActionLog] = dqr;
            ScenarioContext.Current[Key_ListActionLog] = new ListActionLogCommand();
        }

        //Get user profile specs initialized
        [Given(@"The GetUserProfileExecutor has been created and initialized")]
        public void GivenTheGetUserProfileExecutorHasBeenCreatedAndInitialized()
        {
            var dqr = Mocks.DynamicMock<IPlayerProfileDataQuery>();

            ScenarioContext.Current[Key_Dqr_GetUserProfile] = dqr;
            ScenarioContext.Current[Key_GetUserProfile] = new GetUserProfileCommand();
        }

        //Change password specs initialized
        [Given(@"The ChangePasswordExecutor has been created and initializedr")]
        public void GivenTheChangePasswordExecutorHasBeenCreatedAndInitializedr()
        {
            var dac = Mocks.DynamicMock<IPlayerProfileBackService>();
            var dqr = Mocks.DynamicMock<IPlayerProfileDataQuery>();

            ScenarioContext.Current[Key_Dac_ChangePassword] = dac;
            ScenarioContext.Current[Key_Dqr_GetPlayerPassword] = dqr;
            ScenarioContext.Current[Key_ChangePassword] = new ChangePasswordCommand();
        }

        //Change email specs initialized
        [Given(@"The ChangeEmailExecutor has been created and initializedr")]
        public void GivenTheChangeEmailExecutorHasBeenCreatedAndInitializedr()
        {
            var dac = Mocks.DynamicMock<IPlayerProfileBackService>();
            var dqr = Mocks.DynamicMock<IPlayerProfileDataQuery>();

            ScenarioContext.Current[Key_Dac_ChangeEmail] = dac;
            ScenarioContext.Current[Key_Dqr_CheckEmail] = dqr;
            ScenarioContext.Current[Key_Dqr_GetPlayerEmail] = dqr;
            ScenarioContext.Current[Key_ChangePassword] = new ChangeEmailCommand();
        }
    
    }
}
