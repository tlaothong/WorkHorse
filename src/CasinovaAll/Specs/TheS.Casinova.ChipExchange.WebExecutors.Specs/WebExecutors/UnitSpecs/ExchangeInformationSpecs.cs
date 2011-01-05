using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerfEx.Infrastructure.Validation;
using PerfEx.Infrastructure;
using TheS.Casinova.ChipExchange.BackServices;
using TheS.Casinova.ChipExchange.Models;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.ChipExchange.Commands;
using TheS.Casinova.ChipExchange.Validators;
using TheS.Casinova.ChipExchange.DAL;

namespace TheS.Casinova.ChipExchange.WebExecutors.UnitSpecs
{
    [TestClass]
    public class ExchangeInformationSpecs
    {
        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidateExchangeInformation_NameCanNotBeNull()
        {
            IDependencyContainer container;
            IChipsExchangeModuleBackService svc;
            IChipsExchangeModuleDataQuery dqr;

            setupValidators(out container,out svc);

            var model = new ExchangeInformation {
                UserName = null,
                AccountType = "Primary",
                Amount = 500,
            };
            var cmd = new MoneyToChipsCommand {
                ExchangeInformation = model,
            };

            MoneyToChipsExecutor xcutor = new MoneyToChipsExecutor(
                svc, container);
            xcutor.Execute(cmd, (xcmd) => { });
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidateExchangeInformation_AmountMustBeGreaterThan0()
        {
            IDependencyContainer container;
            IChipsExchangeModuleBackService svc;
            IChipsExchangeModuleDataQuery dqr;

            setupValidators(out container, out svc);

            var model = new ExchangeInformation {
                UserName = "Nit",
                AccountType = "Primary",
                Amount = 0,
            };
            var cmd = new MoneyToChipsCommand {
                ExchangeInformation = model,
            };

            MoneyToChipsExecutor xcutor = new MoneyToChipsExecutor(
                svc, container);
            xcutor.Execute(cmd, (xcmd) => { });
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidateExchangeInformation_AccountTypeCanNotBeNull()
        {
            IDependencyContainer container;
            IChipsExchangeModuleBackService svc;
            IChipsExchangeModuleDataQuery dqr;

            setupValidators(out container, out svc);

            var model = new ExchangeInformation {
                UserName = "Nit",
                AccountType = null,
                Amount = 500,
            };
            var cmd = new MoneyToChipsCommand {
                ExchangeInformation = model,
            };

            MoneyToChipsExecutor xcutor = new MoneyToChipsExecutor(
                svc, container);
            xcutor.Execute(cmd, (xcmd) => { });
        }

        private static void setupValidators(out IDependencyContainer container, out IChipsExchangeModuleBackService svc)
        {
            var fac = new PerfEx.Infrastructure.Containers.StructureMapAdapter.StructureMapAbstractFactory();
            var reg = fac.CreateRegistry();

            reg.Register<IValidator<ExchangeInformation, NullCommand>
                , DataAnnotationValidator<ExchangeInformation, NullCommand>>();

            reg.Register<IValidator<ExchangeInformation, MoneyToChipsCommand>
               , ExchangeInformation_MoneyToChipsValidators>();

            container = fac.CreateContainer(reg);
            svc = null;
            //dqr = null;
           
        }
    }
}
