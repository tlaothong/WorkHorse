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
using Rhino.Mocks;
using TheS.Casinova.PlayerProfile.Models;

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
        public void ValidateVoucherInformation_TotalChipsMustBeGreaterThanAmount()
        {
            IDependencyContainer container;
            IChipsExchangeModuleBackService svc;
            IGenerateTrackingID commonSvc;

            setupValidators(out container, out svc, out commonSvc);

            var model = new VoucherInformation {
                UserName = "nit",
                Amount = 3000,
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

        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidateVoucherInformation_ChecksumCanNotBeNull()
        {
            IDependencyContainer container;
            IChipsExchangeModuleBackService svc;
            IGenerateTrackingID commonSvc;

            setupValidators(out container, out svc, out commonSvc);

            var model = new VoucherInformation {
                UserName = "Ayaya",
                VoucherCode = null
            };
            var cmd = new VoucherToBonusChipsCommand {
                VoucherInformation = model,
            };

            VoucherToBonusChipsExecutor xcutor = new VoucherToBonusChipsExecutor(
                svc, container, commonSvc);
            xcutor.Execute(cmd, (xcmd) => { });
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidateVoucherInformation_ChecksumMustBeCorrected()
        {
            IDependencyContainer container;
            IChipsExchangeModuleBackService svc;
            IGenerateTrackingID commonSvc;

            setupValidators(out container, out svc, out commonSvc);

            var model = new VoucherInformation {
                UserName = "Ayaya",
                VoucherCode = "448021228C7A10D4"
            };
            var cmd = new VoucherToBonusChipsCommand {
                VoucherInformation = model,
            };

            VoucherToBonusChipsExecutor xcutor = new VoucherToBonusChipsExecutor(
                svc, container, commonSvc);
            xcutor.Execute(cmd, (xcmd) => { });
        }

        private static void setupValidators(out IDependencyContainer container, out IChipsExchangeModuleBackService svc, out IGenerateTrackingID commonSvc)
        {
            var fac = new PerfEx.Infrastructure.Containers.StructureMapAdapter.StructureMapAbstractFactory();
            var reg = fac.CreateRegistry();

            MockRepository mocks = new MockRepository();
            IChipsExchangeModuleDataQuery dqr = mocks.DynamicMock<IChipsExchangeModuleDataQuery>();
            IGetPlayerBalance playerBalance = dqr;

            UserProfile Balance = new UserProfile {
                UserName = Convert.ToString("Nit"),
                Refundable = Convert.ToDouble(1000),
                NonRefundable = Convert.ToDouble(200)
            };

            SetupResult.For(playerBalance.Get(new GetPlayerBalanceCommand()))
                .IgnoreArguments()
                .Return(Balance);

            reg.Register<IValidator<VoucherInformation, NullCommand>
                , DataAnnotationValidator<VoucherInformation, NullCommand>>();

            reg.Register<IValidator<VoucherInformation, PayVoucherCommand>
               , VoucherInformation_PayVoucherValidators>();

            reg.Register<IValidator<VoucherInformation, VoucherToBonusChipsCommand>
              , VoucherInformation_VoucherToBonusChipsValidators>();

            reg.RegisterInstance<IChipsExchangeModuleDataQuery>
                (dqr);
            reg.Register<IServiceObjectProvider<IChipsExchangeModuleDataQuery>,
                DependencyInjectionServiceObjectProviderAdapter<IChipsExchangeModuleDataQuery, IChipsExchangeModuleDataQuery>>();

            mocks.ReplayAll();
            container = fac.CreateContainer(reg);
            svc = mocks.DynamicMock<IChipsExchangeModuleBackService>();
            commonSvc = null;
        }
    }
}
