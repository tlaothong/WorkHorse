using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerfEx.Infrastructure.Validation;
using PerfEx.Infrastructure;
using TheS.Casinova.PlayerAccount.BackServices;
using TheS.Casinova.PlayerAccount.Models;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.PlayerAccount.Validator;
using TheS.Casinova.PlayerAccount.Commands;

namespace TheS.Casinova.PlayerAccount.WebExecutors.UnitSpecs
{
    [TestClass]
    public class PlayerAccountInformationSpecs
    {
        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidatePlayerAccountInformation_UserNameCanNotBeNull()
        {
            IDependencyContainer container;
            IPlayerAccountModuleBackService svc;
            setupValidators(out container, out svc);

            var model = new PlayerAccountInformation{
                UserName = null,
                CardType = "Visa",
                AccountNo = "1232212342122",
                CVV = "1234",
                ExpireDate = DateTime.Parse("12/7/2011")
            };
            var cmd = new CreatePlayerAccountCommand {
                PlayerAccountInfo = model,
            };

            CreatePlayerAccountExecutor xcutor = new CreatePlayerAccountExecutor(
                svc, container);
            xcutor.Execute(cmd, (xcmd) => { });
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidatePlayerAccountInformation_CardTypeCanNotBeNull()
        {
            IDependencyContainer container;
            IPlayerAccountModuleBackService svc;
            setupValidators(out container, out svc);

            var model = new PlayerAccountInformation {
                UserName = "Nittaya",
                CardType = null,
                AccountNo = "1232212342122",
                CVV = "1234",
                ExpireDate = DateTime.Parse("12/7/2011")
            };
            var cmd = new CreatePlayerAccountCommand {
                PlayerAccountInfo = model,
            };

            CreatePlayerAccountExecutor xcutor = new CreatePlayerAccountExecutor(
                svc, container);
            xcutor.Execute(cmd, (xcmd) => { });
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidatePlayerAccountInformation_AccountNoCanNotBeNull()
        {
            IDependencyContainer container;
            IPlayerAccountModuleBackService svc;
            setupValidators(out container, out svc);

            var model = new PlayerAccountInformation {
                UserName = "Nittaya",
                CardType = "Visa",
                AccountNo = null,
                CVV = "1234",
                ExpireDate = DateTime.Parse("12/7/2011")
            };
            var cmd = new CreatePlayerAccountCommand {
                PlayerAccountInfo = model,
            };

            CreatePlayerAccountExecutor xcutor = new CreatePlayerAccountExecutor(
                svc, container);
            xcutor.Execute(cmd, (xcmd) => { });
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidatePlayerAccountInformation_AccountNoAmountMustbeEqual13Or16()
        {
            IDependencyContainer container;
            IPlayerAccountModuleBackService svc;
            setupValidators(out container, out svc);

            var model = new PlayerAccountInformation {
                UserName = "Nittaya",
                CardType = "Visa",
                AccountNo = "1234",
                CVV = "1234",
                ExpireDate = DateTime.Parse("12/7/2011")
            };
            var cmd = new CreatePlayerAccountCommand {
                PlayerAccountInfo = model,
            };

            CreatePlayerAccountExecutor xcutor = new CreatePlayerAccountExecutor(
                svc, container);
            xcutor.Execute(cmd, (xcmd) => { });
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidatePlayerAccountInformation_CVVCanNotBeNull()
        {
            IDependencyContainer container;
            IPlayerAccountModuleBackService svc;
            setupValidators(out container, out svc);

            var model = new PlayerAccountInformation {
                UserName = "Nittaya",
                CardType = "Visa",
                AccountNo = "1234567890234",
                CVV = null,
                ExpireDate = DateTime.Parse("12/7/2011")
            };
            var cmd = new CreatePlayerAccountCommand {
                PlayerAccountInfo = model,
            };

            CreatePlayerAccountExecutor xcutor = new CreatePlayerAccountExecutor(
                svc, container);
            xcutor.Execute(cmd, (xcmd) => { });
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidatePlayerAccountInformation_CVVAmountMustbeEqual4()
        {
            IDependencyContainer container;
            IPlayerAccountModuleBackService svc;
            setupValidators(out container, out svc);

            var model = new PlayerAccountInformation {
                UserName = "Nittaya",
                CardType = "Visa",
                AccountNo = "1234567890234",
                CVV = "123",
                ExpireDate = DateTime.Parse("12/7/2011")
            };
            var cmd = new CreatePlayerAccountCommand {
                PlayerAccountInfo = model,
            };

            CreatePlayerAccountExecutor xcutor = new CreatePlayerAccountExecutor(
                svc, container);
            xcutor.Execute(cmd, (xcmd) => { });
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidatePlayerAccountInformation_AccountTypeCannotBeNull()
        {
            IDependencyContainer container;
            IPlayerAccountModuleBackService svc;
            setupValidators(out container, out svc);

            var model = new PlayerAccountInformation {
                UserName = "Nittaya",
                AccountType = null
            };
            var cmd = new CancelPlayerAccountCommand
           {
                PlayerAccountInfo = model,
            };

            CancelPlayerAccountExecutor xcutor = new CancelPlayerAccountExecutor(
                svc, container);
            xcutor.Execute(cmd, (xcmd) => { });
        }

        private static void setupValidators(out IDependencyContainer container, out IPlayerAccountModuleBackService svc)
        {
            var fac = new PerfEx.Infrastructure.Containers.StructureMapAdapter.StructureMapAbstractFactory();
            var reg = fac.CreateRegistry();

            reg.Register<IValidator<PlayerAccountInformation, NullCommand>
                , DataAnnotationValidator<PlayerAccountInformation, NullCommand>>();

            reg.Register<IValidator<PlayerAccountInformation, CreatePlayerAccountCommand>
              , PlayerAccountInformation_CreatePlayerAccountValidators>();

            reg.Register<IValidator<PlayerAccountInformation, CancelPlayerAccountCommand>
             , PlayerAccountInformation_CancelPlayerAccountValidators>();

            container = fac.CreateContainer(reg);
            svc = null;
        }
    }
}
