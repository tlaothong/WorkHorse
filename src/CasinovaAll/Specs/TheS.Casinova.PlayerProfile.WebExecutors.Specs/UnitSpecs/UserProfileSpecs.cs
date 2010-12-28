using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerfEx.Infrastructure.Validation;
using PerfEx.Infrastructure;
using TheS.Casinova.PlayerProfile.DAL;
using TheS.Casinova.PlayerProfile.Models;
using TheS.Casinova.PlayerProfile.Commands;
using TheS.Casinova.PlayerProfile.BackServices;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.PlayerProfile.Validator;
using TheS.Casinova.PlayerProfile.Validators;
using TheS.Casinova.Common.Services;

namespace TheS.Casinova.PlayerProfile.WebExecutors.UnitSpecs
{
    [TestClass]
    public class UserProfileSpecs
    {
        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidateUserProfile_UserNameCanNotBeNull()
        {
            IDependencyContainer container;
            IPlayerProfileBackService svc;
            IGenerateTrackingID commonSvc;
            IMembershipServices membershipSvc;

            setupValidators(out container, out svc, out commonSvc, out membershipSvc);

            var model = new UserProfile {
                UserName = null,
                Password = "natayit5678",
                Email = "nayit@hotmail.com",
                CellPhone = "0892131356",
                Upline = "Nit"
            };
            var cmd = new RegisterUserCommand {
                RegisterUserInfo = model,
            };

            RegisterUserExecutor xcutor = new RegisterUserExecutor(
                svc, container, commonSvc, membershipSvc);
            xcutor.Execute(cmd, (xcmd) => { });
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidateUserProfile_PasswordCanNotBeNull()
        {
            IDependencyContainer container;
            IPlayerProfileBackService svc;
            IGenerateTrackingID commonSvc;
            IMembershipServices membershipSvc;

            setupValidators(out container, out svc, out commonSvc, out membershipSvc);

            var model = new UserProfile {
                UserName = "Sakanit",
                Password = null,
                Email = "nayit@hotmail.com",
                CellPhone = "0892131356",
                Upline = "Nit"
            };
            var cmd = new RegisterUserCommand {
                RegisterUserInfo = model,
            };

            RegisterUserExecutor xcutor = new RegisterUserExecutor(
                svc, container, commonSvc, membershipSvc);
            xcutor.Execute(cmd, (xcmd) => { });
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidateUserProfile_PasswordMustBeGreaterThan5()
        {
            IDependencyContainer container;
            IPlayerProfileBackService svc;
            IGenerateTrackingID commonSvc;
            IMembershipServices membershipSvc;

            setupValidators(out container, out svc,out commonSvc, out membershipSvc);

            var model = new UserProfile {
                UserName = "AimImaim",
                Password = "118",
                Email = "nayit@hotmail.com",
                CellPhone = "0892131356",
                Upline = "Nit"
            };
            var cmd = new RegisterUserCommand {
                RegisterUserInfo = model,
            };

            RegisterUserExecutor xcutor = new RegisterUserExecutor(
                svc, container, commonSvc, membershipSvc);
            xcutor.Execute(cmd, (xcmd) => { });
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidateUserProfile_PasswordMustBeLowerThan17()
        {
            IDependencyContainer container;
            IPlayerProfileBackService svc;
            IGenerateTrackingID commonSvc;
            IMembershipServices membershipSvc;

            setupValidators(out container, out svc, out commonSvc, out membershipSvc);

            var model = new UserProfile {
                UserName = "AimImaim",
                Password = "11854786321549536",
                Email = "nayit@hotmail.com",
                CellPhone = "0892131356",
                Upline = "Nit"
            };
            var cmd = new RegisterUserCommand {
                RegisterUserInfo = model,
            };

            RegisterUserExecutor xcutor = new RegisterUserExecutor(
                svc,container,commonSvc, membershipSvc);
            xcutor.Execute(cmd, (xcmd) => { });
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidateUserProfile_EmailCanNotBeNull()
        {
            IDependencyContainer container;
            IPlayerProfileBackService svc;
            IGenerateTrackingID commonSvc;
            IMembershipServices membershipSvc;
 
            setupValidators(out container, out svc, out commonSvc, out membershipSvc);

            var model = new UserProfile {
                UserName = "AimImAim",
                Password = "natayit5678",
                Email = null,
                CellPhone = "0892131356",
                Upline = "Nit"
            };
            var cmd = new RegisterUserCommand {
                RegisterUserInfo = model,
            };

            RegisterUserExecutor xcutor = new RegisterUserExecutor(
                svc, container,commonSvc, membershipSvc);
            xcutor.Execute(cmd, (xcmd) => { });
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidateUserProfile_EmailMustBeCorrectFormat()
        {
            IDependencyContainer container;
            IPlayerProfileBackService svc;
            IGenerateTrackingID commonSvc;
            IMembershipServices membershipSvc;

            setupValidators(out container, out svc, out commonSvc, out membershipSvc);

            var model = new UserProfile {
                UserName = "AimImAim",
                Password = "natayit5678",
                Email = "nittaya.com",
                CellPhone = "0892131356",
                Upline = "Nit"
            };
            var cmd = new RegisterUserCommand {
                RegisterUserInfo = model,
            };

            RegisterUserExecutor xcutor = new RegisterUserExecutor(
                svc, container,commonSvc, membershipSvc);
            xcutor.Execute(cmd, (xcmd) => { });
        }


        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidateUserProfile_CellPhoneCanNotBeNull()
        {
            IDependencyContainer container;
            IPlayerProfileBackService svc;
            IGenerateTrackingID commonSvc;
            IMembershipServices membershipSvc;
            setupValidators(out container, out svc, out commonSvc, out membershipSvc);

            var model = new UserProfile {
                UserName = "AimImAim",
                Password = "natayit5678",
                Email = "nayit@hotmail.com",
                CellPhone = null,
                Upline = "Nit"
            };
            var cmd = new RegisterUserCommand {
                RegisterUserInfo = model,
            };

            RegisterUserExecutor xcutor = new RegisterUserExecutor(
                svc, container, commonSvc, membershipSvc);
            xcutor.Execute(cmd, (xcmd) => { });
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidateUserProfile_NewEmailCanNotBeNull()
        {
            IDependencyContainer container;
            //IPlayerProfileBackService svc;
            IMembershipServices membershipSvc;
            setupValidators(out container,out membershipSvc);

            var model = new UserProfile {
               NewEmail = null
            };
            var cmd = new ChangeEmailCommand {
                UserProfile = model,
            };

            ChangeEmailExecutor xcutor = new ChangeEmailExecutor(
                 container,membershipSvc);
            xcutor.Execute(cmd, (xcmd) => { });
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidateUserProfile_NewEmailMustBeCorrectFormat()
        {
            IDependencyContainer container;
            //IPlayerProfileBackService svc;
            IMembershipServices membershipSvc;
            setupValidators(out container, out membershipSvc);

            var model = new UserProfile {
                NewEmail = "hotmail@nit"
            };
            var cmd = new ChangeEmailCommand {
                UserProfile = model,
            };

            ChangeEmailExecutor xcutor = new ChangeEmailExecutor(
                 container,membershipSvc);
            xcutor.Execute(cmd, (xcmd) => { });
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidateUserProfile_NewPasswordCanNotBeNull()
        {
            IDependencyContainer container;
            //IPlayerProfileBackService svc;
            IMembershipServices membershipSvc;
            setupValidators(out container, out membershipSvc);

            var model = new UserProfile {
                NewPassword = null
            };
            var cmd = new ChangePasswordCommand {
                UserProfile = model,
            };

            ChangePasswordExecutor xcutor = new ChangePasswordExecutor(
                container, membershipSvc);
            xcutor.Execute(cmd, (xcmd) => { });
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidateUserProfile_NewPasswordMustBeLowerThan17()
        {
            IDependencyContainer container;
            //IPlayerProfileBackService svc;
            IMembershipServices membershipSvc;
            setupValidators(out container, out membershipSvc);

            var model = new UserProfile {
                NewPassword = "123456bgfdsertwers"
            };
            var cmd = new ChangePasswordCommand {
                UserProfile = model,
            };

            ChangePasswordExecutor xcutor = new ChangePasswordExecutor(
                container,membershipSvc);
            xcutor.Execute(cmd, (xcmd) => { });
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidateUserProfile_NewPasswordMustBeGreaterThan5()
        {
            IDependencyContainer container;
            //IPlayerProfileBackService svc;
            IMembershipServices membershipSvc;
            setupValidators(out container, out membershipSvc);

            var model = new UserProfile {
                NewPassword = "123"
            };
            var cmd = new ChangePasswordCommand {
                UserProfile = model,
            };

            ChangePasswordExecutor xcutor = new ChangePasswordExecutor(
                container, membershipSvc);
            xcutor.Execute(cmd, (xcmd) => { });
        }


        private static void setupValidators(out IDependencyContainer container, out IMembershipServices membershipSvc)
        {
            var fac = new PerfEx.Infrastructure.Containers.StructureMapAdapter.StructureMapAbstractFactory();
            var reg = fac.CreateRegistry();

            reg.Register<IValidator<UserProfile, NullCommand>
                , DataAnnotationValidator<UserProfile, NullCommand>>();

            reg.Register<IValidator<UserProfile, RegisterUserCommand>
               , UserProfile_RegisterUserValidators>();

            reg.Register<IValidator<UserProfile, ChangeEmailCommand>
               , UserProfile_ChangeEmailValidators>();

            reg.Register<IValidator<UserProfile, ChangePasswordCommand>
              , UserProfile_ChangePasswordValidators>();

            container = fac.CreateContainer(reg);
            membershipSvc = null;
            //svc = null;
        }

        private static void setupValidators(out IDependencyContainer container, out  IPlayerProfileBackService svc, out IGenerateTrackingID commonSvc, out  IMembershipServices membershipSvc)
        {
            var fac = new PerfEx.Infrastructure.Containers.StructureMapAdapter.StructureMapAbstractFactory();
            var reg = fac.CreateRegistry();

            reg.Register<IValidator<UserProfile, NullCommand>
                , DataAnnotationValidator<UserProfile, NullCommand>>();

            reg.Register<IValidator<UserProfile, RegisterUserCommand>
               , UserProfile_RegisterUserValidators>();

            container = fac.CreateContainer(reg);
            commonSvc = null;
            membershipSvc = null;
            svc = null;
        }
    }
}
