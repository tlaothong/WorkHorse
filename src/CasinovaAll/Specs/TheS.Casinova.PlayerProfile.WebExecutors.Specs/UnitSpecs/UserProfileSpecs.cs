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

namespace TheS.Casinova.PlayerProfile.WebExecutors.UnitSpecs
{
    [TestClass]
    public class UserProfileSpecs
    {
        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidateRegisterUserExecutor_UserNameCanNotBeNull()
        {
            IDependencyContainer container;
            IPlayerProfileBackService svc;

            setupValidators(out container, out svc);

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
                svc, container);
            xcutor.Execute(cmd, (xcmd) => { });
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidateRegisterUserExecutor_PasswordMustBeGreaterThan5()
        {
            IDependencyContainer container;
            IPlayerProfileBackService svc;

            setupValidators(out container, out svc);

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
                svc, container);
            xcutor.Execute(cmd, (xcmd) => { });
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidateRegisterUserExecutor_PasswordMustBeLowerThan17()
        {
            IDependencyContainer container;
            IPlayerProfileBackService svc;

            setupValidators(out container, out svc);

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
                svc,container);
            xcutor.Execute(cmd, (xcmd) => { });
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidateRegisterUserExecutor_EmailCanNotBeNull()
        {
            IDependencyContainer container;
            IPlayerProfileBackService svc;
 
            setupValidators(out container, out svc);

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
                svc, container);
            xcutor.Execute(cmd, (xcmd) => { });
        }


        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidateRegisterUserExecutor_CellPhoneCanNotBeNull()
        {
            IDependencyContainer container;
            IPlayerProfileBackService svc;
            setupValidators(out container, out svc);

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
                svc, container);
            xcutor.Execute(cmd, (xcmd) => { });
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidateRegisterUserExecutor()
        {
            IDependencyContainer container;
            IPlayerProfileBackService svc;
            setupValidators(out container, out svc);

            var model = new UserProfile {
                UserName = "AimImAim",
                Password = "natayit5678",
                Email = " ",
                CellPhone = "0892131356",
                Upline = "Nit"
            };
            var cmd = new RegisterUserCommand {
                RegisterUserInfo = model,
            };

            RegisterUserExecutor xcutor = new RegisterUserExecutor(
                svc, container);
            xcutor.Execute(cmd, (xcmd) => { });
        }
        private static void setupValidators(out IDependencyContainer container, out  IPlayerProfileBackService svc)
        {
            var fac = new PerfEx.Infrastructure.Containers.StructureMapAdapter.StructureMapAbstractFactory();
            var reg = fac.CreateRegistry();

            reg.Register<IValidator<UserProfile, RegisterUserCommand>
                , DataAnnotationValidator<UserProfile, RegisterUserCommand>>();

            //reg.Register<IValidator<UserProfile, RegisterUserCommand>
            //   , UserProfile_RegisterUserValidators>();

            container = fac.CreateContainer(reg);
            svc = null;
        }
    }
}
