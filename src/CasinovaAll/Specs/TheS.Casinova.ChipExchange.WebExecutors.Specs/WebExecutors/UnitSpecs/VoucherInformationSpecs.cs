using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerfEx.Infrastructure;
using PerfEx.Infrastructure.Validation;
using TheS.Casinova.ChipExchange.DAL;
using TheS.Casinova.ChipExchange.Models;
using TheS.Casinova.ChipExchange.Commands;
using TheS.Casinova.ChipExchange.BackServices;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.ChipExchange.Validators;
using TheS.Casinova.Common.Services;

namespace TheS.Casinova.ChipExchange.WebExecutors.UnitSpecs
{
    [TestClass]
    public class VoucherInformationSpecs
    {
  
        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidateVoucherInformation_NameCanNotBeNull()
        {
            IDependencyContainer container;
            IChipsExchangeModuleBackService svc;
            IGenerateTrackingID commonSvc;

            setupValidators(out container, out svc, out commonSvc);

            var model = new VoucherInformation {
                UserName = null,
                Amount = 500,
            };
            var cmd = new PayVoucherCommand {
                VoucherInformation = model,
            };

            PayVoucherExecutor xcutor = new PayVoucherExecutor(
                svc, container, commonSvc);
            xcutor.Execute(cmd, (xcmd) => { });
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidateVoucherInformation_AmountMustBeGreaterThan0()
        {
            IDependencyContainer container;
            IChipsExchangeModuleBackService svc;
            IGenerateTrackingID commonSvc;

            setupValidators(out container, out svc, out commonSvc);

            var model = new VoucherInformation {
                UserName = "Ayaya",
                Amount = -50,
            };
            var cmd = new PayVoucherCommand {
                VoucherInformation = model,
            };

            PayVoucherExecutor xcutor = new PayVoucherExecutor(
                svc, container, commonSvc);
            xcutor.Execute(cmd, (xcmd) => { });
        }

        private static void setupValidators(out IDependencyContainer container, out IChipsExchangeModuleBackService svc, out IGenerateTrackingID commonSvc)
        {
            var fac = new PerfEx.Infrastructure.Containers.StructureMapAdapter.StructureMapAbstractFactory();
            var reg = fac.CreateRegistry();

            reg.Register<IValidator<VoucherInformation, NullCommand>
                , DataAnnotationValidator<VoucherInformation, NullCommand>>();

            reg.Register<IValidator<VoucherInformation, PayVoucherCommand>
               , VoucherInformation_PayVoucherValidators>();

            container = fac.CreateContainer(reg);
            commonSvc = null;
            svc = null;
        }
    }
}
