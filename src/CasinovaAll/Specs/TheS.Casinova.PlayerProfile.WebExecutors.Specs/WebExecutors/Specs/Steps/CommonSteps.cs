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
using PerfEx.Infrastructure;
using TheS.Casinova.PlayerProfile.Models;
using PerfEx.Infrastructure.Validation;
using PerfEx.Infrastructure.Containers.StructureMapAdapter;
using SpecFlowAssist;
using TheS.Casinova.PlayerProfile.Command;

namespace TheS.Casinova.PlayerProfile.WebExecutors.Specs.Steps
{
    [Binding]
    public class CommonSteps
    {

        MockRepository Mocks { get { return SpecEventDefinitions.Mocks; } }

        //Register user information specs initialized
        [Given(@"The RegisterUserExecutor has been created and initialized")]
        public void GivenTheRegisterUserExecutorHasBeenCreatedAndInitialized()
        {
            var dac = Mocks.DynamicMock<IPlayerProfileBackService>();
            var dqr = Mocks.DynamicMock<IPlayerProfileDataQuery>();

            IDependencyContainer container;
            setupValidators(out container);
            ScenarioContext.Current.Set<IRegisterUser>(dac);
            ScenarioContext.Current.Set<ICheckUserName>(dqr);
            ScenarioContext.Current.Set<ICheckEmail>(dqr);
            ScenarioContext.Current.Set<ICheckUpline>(dqr);
            ScenarioContext.Current.Set<RegisterUserExecutor>(
                new RegisterUserExecutor(dac, container));
        }

        //List action log  specs initialized
        [Given(@"The ListActionLogExecutor has been created and initialized")]
        public void GivenTheListActionLogExecutorHasBeenCreatedAndInitialized()
        {
            var dqr = Mocks.DynamicMock<IPlayerProfileDataQuery>();

            IDependencyContainer container;
            setupValidators(out container);
            ScenarioContext.Current.Set<IListActionLog>(dqr);
            ScenarioContext.Current.Set<ListActionLogExecutor>(
                new ListActionLogExecutor(dqr, container));
        }

        //Get user profile specs initialized
        [Given(@"The GetUserProfileExecutor has been created and initialized")]
        public void GivenTheGetUserProfileExecutorHasBeenCreatedAndInitialized()
        {
            var dqr = Mocks.DynamicMock<IPlayerProfileDataQuery>();

            IDependencyContainer container;
            setupValidators(out container);
            ScenarioContext.Current.Set<IGetUserProfile>(dqr);
            ScenarioContext.Current.Set<GetUserProfileExecutor>(
                new GetUserProfileExecutor(dqr, container));
        }

        //Change password specs initialized
        [Given(@"The ChangePasswordExecutor has been created and initialized")]
        public void GivenTheChangePasswordExecutorHasBeenCreatedAndInitialized()
        {
            var dac = Mocks.DynamicMock<IPlayerProfileBackService>();
            var dqr = Mocks.DynamicMock<IPlayerProfileDataQuery>();

            IDependencyContainer container;
            setupValidators(out container);
            ScenarioContext.Current.Set<IGetPlayerPassword>(dqr);
            ScenarioContext.Current.Set<IChangePassword>(dac);
            ScenarioContext.Current.Set<ChangePasswordExecutor>(
                new ChangePasswordExecutor(dac, container));
        }

        //Change email specs initialized
        [Given(@"The ChangeEmailExecutor has been created and initialized")]
        public void GivenTheChangeEmailExecutorHasBeenCreatedAndInitializedr()
        {
            var dac = Mocks.DynamicMock<IPlayerProfileBackService>();
            var dqr = Mocks.DynamicMock<IPlayerProfileDataQuery>();

            IDependencyContainer container;
            setupValidators(out container);

            ScenarioContext.Current.Set<IChangeEmail>(dac);
            ScenarioContext.Current.Set<ICheckEmail>(dqr);
            ScenarioContext.Current.Set<IGetPlayerEmail>(dqr);
            ScenarioContext.Current.Set<ChangeEmailExecutor>(
                new ChangeEmailExecutor(dac, container));
        }

        private static void setupValidators(out IDependencyContainer container)
        {
            var fac = new StructureMapAbstractFactory();
            var reg = fac.CreateRegistry();

            reg.Register<IValidator<ActionLog, ListActionLogCommand>
                , DataAnnotationValidator<ActionLog, ListActionLogCommand>>();

            reg.Register<IValidator<UserProfile, GetUserProfileCommand>
               , DataAnnotationValidator<UserProfile, GetUserProfileCommand>>();

            reg.Register<IValidator<UserProfile, RegisterUserCommand>
              , DataAnnotationValidator<UserProfile, RegisterUserCommand>>();

            reg.Register<IValidator<UserProfile, CheckUserNameCommand>
             , DataAnnotationValidator<UserProfile, CheckUserNameCommand>>();

            reg.Register<IValidator<UserProfile, CheckEmailCommand>
             , DataAnnotationValidator<UserProfile, CheckEmailCommand>>();

            reg.Register<IValidator<UserProfile, CheckUplineCommand>
             , DataAnnotationValidator<UserProfile, CheckUplineCommand>>();

            reg.Register<IValidator<UserProfile, ChangeEmailCommand>
             , DataAnnotationValidator<UserProfile, ChangeEmailCommand>>();

            reg.Register<IValidator<UserProfile, GetPlayerEmailCommand>
            , DataAnnotationValidator<UserProfile, GetPlayerEmailCommand>>();

            reg.Register<IValidator<UserProfile, ChangePasswordCommand>
            , DataAnnotationValidator<UserProfile, ChangePasswordCommand>>();

            container = fac.CreateContainer(reg);
        }


    }
}
