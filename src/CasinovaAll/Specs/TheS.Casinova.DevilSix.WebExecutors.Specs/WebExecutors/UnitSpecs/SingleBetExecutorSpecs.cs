using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerfEx.Infrastructure.Validation;
using TheS.Casinova.DevilSix.Models;
using PerfEx.Infrastructure;
using TheS.Casinova.DevilSix.Commands;
using TheS.Casinova.Common.Services;
using TheS.Casinova.DevilSix.BackServices;
using TheS.Casinova.DevilSix.Validators;

namespace TheS.Casinova.DevilSix.WebExecutors.UnitSpecs
{
    [TestClass]
    public class SingleBetExecutorSpecs
    {
        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidateSingleBetExecutor_UserNameCanNotBeNull()
        {
            IDependencyContainer container;
            IDevilSixGameBackService svc;
            IGenerateTrackingID commonSvc;
            setupValidators(out svc, out container, out commonSvc);

            var model = new BetInformation {
                UserName = null,
                RoundID = 1,
                Amount = 1
            };
            var cmd = new SingleBetCommand {
                BetInfo = model,
            };

            SingleBetExecutor xcutor = new SingleBetExecutor(
                svc, container, commonSvc);
            xcutor.Execute(cmd, (xcmd) => { });
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidateSingleBetExecutor_RoundIDMustBeGreaterThan0()
        {
            IDependencyContainer container;
            IDevilSixGameBackService svc;
            IGenerateTrackingID commonSvc;
            setupValidators(out svc, out container, out commonSvc);

            var model = new BetInformation {
                UserName = "Nit",
                RoundID = 0,
                Amount = 1
            };
            var cmd = new SingleBetCommand {
                BetInfo = model,
            };

            SingleBetExecutor xcutor = new SingleBetExecutor(
                svc, container, commonSvc);
            xcutor.Execute(cmd, (xcmd) => { });
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidateSingleBetExecutor_RoundIDMustBeLowerThan5()
        {
            IDependencyContainer container;
            IDevilSixGameBackService svc;
            IGenerateTrackingID commonSvc;
            setupValidators(out svc, out container, out commonSvc);

            var model = new BetInformation {
                UserName = "Nit",
                RoundID = 6,
                Amount = 1
            };
            var cmd = new SingleBetCommand {
                BetInfo = model,
            };

            SingleBetExecutor xcutor = new SingleBetExecutor(
                svc, container, commonSvc);
            xcutor.Execute(cmd, (xcmd) => { });
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidateSingleBetExecutor_AmountMustBeGreaterThan0()
        {
            IDependencyContainer container;
            IDevilSixGameBackService svc;
            IGenerateTrackingID commonSvc;
            setupValidators(out svc, out container, out commonSvc);

            var model = new BetInformation {
                UserName = "Nit",
                RoundID = 1,
                Amount = -1
            };
            var cmd = new SingleBetCommand {
                BetInfo = model,
            };

            SingleBetExecutor xcutor = new SingleBetExecutor(
                svc, container, commonSvc);
            xcutor.Execute(cmd, (xcmd) => { });
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidateSingleBetExecutor_AmountMustBeCorrelationRoundID()
        {
            IDependencyContainer container;
            IDevilSixGameBackService svc;
            IGenerateTrackingID commonSvc;
            setupValidators(out svc, out container, out commonSvc);

            var model = new BetInformation {
                UserName = "Nit",
                RoundID = 2,
                Amount = 3
            };
            var cmd = new SingleBetCommand {
                BetInfo = model,
            };

            SingleBetExecutor xcutor = new SingleBetExecutor(
                svc, container, commonSvc);
            xcutor.Execute(cmd, (xcmd) => { });
        }

        private static void setupValidators(out IDevilSixGameBackService svc, out IDependencyContainer container, out IGenerateTrackingID commonSvc)
        {
            var fac = new PerfEx.Infrastructure.Containers.StructureMapAdapter.StructureMapAbstractFactory();
            var reg = fac.CreateRegistry();

            reg.Register<IValidator<BetInformation, SingleBetCommand>
                , DataAnnotationValidator<BetInformation, SingleBetCommand>>();

            reg.Register<IValidator<BetInformation, SingleBetCommand>
                , BetInformation_SingleBetValidators>();

            container = fac.CreateContainer(reg);
            commonSvc = null;
            svc = null;
        }
    }
}
