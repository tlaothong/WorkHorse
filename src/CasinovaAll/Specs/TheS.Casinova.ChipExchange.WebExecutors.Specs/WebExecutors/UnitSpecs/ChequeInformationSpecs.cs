using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerfEx.Infrastructure.Validation;
using PerfEx.Infrastructure;
using TheS.Casinova.ChipExchange.BackServices;
using TheS.Casinova.ChipExchange.Models;
using TheS.Casinova.ChipExchange.Commands;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.ChipExchange.Validators;

namespace TheS.Casinova.ChipExchange.WebExecutors.UnitSpecs
{
    [TestClass]
    public class ChequeInformationSpecs
    {
        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidateChequeInformation_NameCanNotBeNull()
        {
            IDependencyContainer container;
            IChipsExchangeModuleBackService svc;

            setupValidators(out container, out svc);

            var model = new ChequeInformation {
                UserName = null,
                Address = "มหาวิทยาลัยขอนแข่น จ.ขอนแก่น",
                Amount = 500,
            };
            var cmd = new ChipsToMoneyCommand {
                ChequeInfo = model,
            };

            ChipsToMoneyExecutor xcutor = new ChipsToMoneyExecutor(
                svc, container);
            xcutor.Execute(cmd, (xcmd) => { });
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidateChequeInformation_AddressCanNotBeNull()
        {
            IDependencyContainer container;
            IChipsExchangeModuleBackService svc;

            setupValidators(out container, out svc);

            var model = new ChequeInformation {
                UserName = "Nit",
                Address = null,
                Amount = 500,
            };
            var cmd = new ChipsToMoneyCommand {
                ChequeInfo = model,
            };

            ChipsToMoneyExecutor xcutor = new ChipsToMoneyExecutor(
                svc, container);
            xcutor.Execute(cmd, (xcmd) => { });
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidateChequeInformation_AmountMustBeGreaterThan0()
        {
            IDependencyContainer container;
            IChipsExchangeModuleBackService svc;

            setupValidators(out container, out svc);

            var model = new ChequeInformation {
                UserName = "Nit",
                Address = "มหาวิทยาลัยขอนแข่น จ.ขอนแก่น",
                Amount = 0,
            };
            var cmd = new ChipsToMoneyCommand {
                ChequeInfo = model,
            };

            ChipsToMoneyExecutor xcutor = new ChipsToMoneyExecutor(
                svc, container);
            xcutor.Execute(cmd, (xcmd) => { });
        }

        private static void setupValidators(out IDependencyContainer container, out IChipsExchangeModuleBackService svc)
        {
            var fac = new PerfEx.Infrastructure.Containers.StructureMapAdapter.StructureMapAbstractFactory();
            var reg = fac.CreateRegistry();

            reg.Register<IValidator<ChequeInformation, NullCommand>
                , DataAnnotationValidator<ChequeInformation, NullCommand>>();

            reg.Register<IValidator<ChequeInformation, ChipsToMoneyCommand>
               , ChequeInformation_ChipsToMoneyValidators>();

            container = fac.CreateContainer(reg);
            svc = null;
            //dqr = null;

        }
    }
}
