using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Rhino.Mocks;
using TheS.Casinova.MagicNine.BackServices;
using TheS.Casinova.PlayerProfile.DAL;
using TheS.Casinova.PlayerProfile.BackServices.BackExecutors;
using PerfEx.Infrastructure;
using PerfEx.Infrastructure.Containers.StructureMapAdapter;
using TheS.Casinova.PlayerProfile.Models;
using TheS.Casinova.PlayerProfile.Commands;
using PerfEx.Infrastructure.Validation;
using SpecFlowAssist;
using TheS.Casinova.PlayerProfile.BackServices.Validators;

namespace TheS.Casinova.PlayerProfile.BackServices.Specs.Steps
{
    [Binding]
    public class CommonSteps
    {
        public const string Key_Dac_RegisterUser = "mockDac_RegisterUser";
        public const string Key_Dac_VeriflyUser = "mockDac_VeriflyUser";
        public const string Key_Dac_ChangePassword = "mockDac_ChangePassword";
        public const string Key_Dac_ChangeEmail = "mockDac_ChangeEmail";

        public const string Key_Dqr_GetUserProfile = "mockDqr_GetUserProfile";
        public const string Key_Dqr_GetUserProfileByEmail = "mockDqr_GetUserProfileByEmail";

        public const string Key_RegisterUser = "RegisterUser";
        public const string Key_VeriflyUser = "VeriflyUser";
        public const string Key_ChangePassword = "ChangePassword";
        public const string Key_ChangeEmail = "ChangeEmail";

        MockRepository Mocks { get { return SpecEventDefinitions.Mocks; } }

        [Given(@"The RegisterUserExecutor has been created and initialized")]
        public void GivenTheRegisterUserExecutorHasBeenCreatedAndInitialized()
        {
            var dac = Mocks.DynamicMock<IPlayerProfileDataAccess>();
            var svc = Mocks.DynamicMock<IEmailSender>();
            var dqr = Mocks.DynamicMock<IPlayerProfileDataBackQuery>();
            var container = Mocks.DynamicMock<IDependencyContainer>();

            ScenarioContext.Current[Key_Dac_RegisterUser] = dac;
            ScenarioContext.Current[Key_Dqr_GetUserProfile] = dqr;

            setupValidators(out container);
            ScenarioContext.Current[Key_RegisterUser] = new RegisterUserExecutor(container, svc, dac);
        }

        [Given(@"The VeriflyUserExecutor has been created and initialized")]
        public void GivenTheVeriflyUserExecutorHasBeenCreatedAndInitialized()
        {
            var dac = Mocks.DynamicMock<IPlayerProfileDataAccess>();
            var dqr = Mocks.DynamicMock<IPlayerProfileDataBackQuery>();
            var container = Mocks.DynamicMock<IDependencyContainer>();

            ScenarioContext.Current[Key_Dac_VeriflyUser] = dac;
            ScenarioContext.Current[Key_Dqr_GetUserProfile] = dqr;

            setupValidators(out container);
            ScenarioContext.Current[Key_VeriflyUser] = new VerifyUserExecutor(container, dac);
        }

        [Given(@"The ChangePassword has been created and initialized")]
        public void GivenTheChangePasswordHasBeenCreatedAndInitialized()
        {
            var dac = Mocks.DynamicMock<IPlayerProfileDataAccess>();
            var dqr = Mocks.DynamicMock<IPlayerProfileDataBackQuery>();
            var container = Mocks.DynamicMock<IDependencyContainer>();

            ScenarioContext.Current[Key_Dac_ChangePassword] = dac;
            ScenarioContext.Current[Key_Dqr_GetUserProfile] = dqr;

            setupValidators(out container);
            ScenarioContext.Current[Key_ChangePassword] = new ChangePasswordExecutor(container, dac);
        }

        [Given(@"The ChangeEmail has been created and initialized")]
        public void GivenTheChangeEmailHasBeenCreatedAndInitialized()
        {
            var dac = Mocks.DynamicMock<IPlayerProfileDataAccess>();
            var dqr = Mocks.DynamicMock<IPlayerProfileDataBackQuery>();
            var container = Mocks.DynamicMock<IDependencyContainer>();

            ScenarioContext.Current[Key_Dac_ChangeEmail] = dac;
            ScenarioContext.Current[Key_Dqr_GetUserProfile] = dqr;
            ScenarioContext.Current[Key_Dqr_GetUserProfileByEmail] = dqr;

            setupValidators(out container);
            ScenarioContext.Current[Key_ChangeEmail] = new ChangeEmailExecutor(container, dac, dqr);
        }

        private static void setupValidators(out IDependencyContainer container)
        {
            var fac = new StructureMapAbstractFactory();
            var reg = fac.CreateRegistry();

            reg.Register<IValidator<UserProfile, RegisterUserCommand>
                , UserProfile_RegisterUserValidators>();
            reg.Register<IValidator<UserProfile, VerifyUserCommand>
                , UserProfile_VerifyUserValidators>();
            reg.Register<IValidator<UserProfile, ChangeEmailCommand>
                , UserProfile_ChangeEmailValidators>();
            reg.Register<IValidator<UserProfile, ChangePasswordCommand>
                , UserProfile_ChangePasswordValidators>();

            reg.RegisterInstance<IPlayerProfileDataBackQuery>
                (ScenarioContext.Current.Get<IPlayerProfileDataBackQuery>(Key_Dqr_GetUserProfile));
            reg.Register<IServiceObjectProvider<IPlayerProfileDataBackQuery>,
                DependencyInjectionServiceObjectProviderAdapter<IPlayerProfileDataBackQuery, IPlayerProfileDataBackQuery>>();

            container = fac.CreateContainer(reg);
        }
    }
}
