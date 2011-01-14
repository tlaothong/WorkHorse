using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerfEx.Infrastructure.Validation;
using PerfEx.Infrastructure;
using TheS.Casinova.DevilSix.BackServices;
using TheS.Casinova.Common.Services;
using TheS.Casinova.DevilSix.Models;
using TheS.Casinova.DevilSix.Commands;
using TheS.Casinova.DevilSix.Validators;

namespace TheS.Casinova.DevilSix.WebExecutors.UnitSpecs
{
    [TestClass]
    public class StartAutoBetExecutorSpecs
    {
        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidateStartAutoBetExecutor_UserNameCanNotBeNull()
        {
            IDependencyContainer container;
            IDevilSixGameBackService svc;
            IGenerateTrackingID commonSvc;
            setupValidators(out svc, out container, out commonSvc);

            var model = new GamePlayAutoBetInformation {
                UserName = null,
                RoundID = 1,
                Amount = 1,
                TotalAmount = 10,
                Interval = 3
            };
            var cmd = new StartAutoBetCommand {
                GamePlayAutoBetInfo = model,
            };

            StartAutoBetExecutor xcutor = new StartAutoBetExecutor(
                svc, container, commonSvc);
            xcutor.Execute(cmd, (xcmd) => { });
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidateStartAutoBetExecutor_RoundIDMustBeGreaterThan0()
        {
            IDependencyContainer container;
            IDevilSixGameBackService svc;
            IGenerateTrackingID commonSvc;
            setupValidators(out svc, out container, out commonSvc);

            var model = new GamePlayAutoBetInformation {
                UserName = "Nit",
                RoundID = -1,
                Amount = 1,
                TotalAmount = 10,
                Interval = 3
            };
            var cmd = new StartAutoBetCommand {
                GamePlayAutoBetInfo = model,
            };

            StartAutoBetExecutor xcutor = new StartAutoBetExecutor(
                svc, container, commonSvc);
            xcutor.Execute(cmd, (xcmd) => { });
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidateStartAutoBetExecutor_RoundIDMustBeLowerThan5()
        {
            IDependencyContainer container;
            IDevilSixGameBackService svc;
            IGenerateTrackingID commonSvc;
            setupValidators(out svc, out container, out commonSvc);

            var model = new GamePlayAutoBetInformation {
                UserName = "Nit",
                RoundID = 6,
                Amount = 1,
                TotalAmount = 10,
                Interval = 3
            };
            var cmd = new StartAutoBetCommand {
                GamePlayAutoBetInfo = model,
            };

            StartAutoBetExecutor xcutor = new StartAutoBetExecutor(
                svc, container, commonSvc);
            xcutor.Execute(cmd, (xcmd) => { });
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidateStartAutoBetExecutor_AmountMustBeGreaterThan0()
        {
            IDependencyContainer container;
            IDevilSixGameBackService svc;
            IGenerateTrackingID commonSvc;
            setupValidators(out svc, out container, out commonSvc);

            var model = new GamePlayAutoBetInformation {
                UserName = "Nit",
                RoundID = 1,
                Amount = -5,
                TotalAmount = 10,
                Interval = 3
            };
            var cmd = new StartAutoBetCommand {
                GamePlayAutoBetInfo = model,
            };

            StartAutoBetExecutor xcutor = new StartAutoBetExecutor(
                svc, container, commonSvc);
            xcutor.Execute(cmd, (xcmd) => { });
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidateStartAutoBetExecutor_AmountMustBeCorrelationRoundID()
        {
            IDependencyContainer container;
            IDevilSixGameBackService svc;
            IGenerateTrackingID commonSvc;
            setupValidators(out svc, out container, out commonSvc);

            var model = new GamePlayAutoBetInformation {
                UserName = "Nit",
                RoundID = 1,
                Amount = 5,
                TotalAmount = 10,
                Interval = 3
            };
            var cmd = new StartAutoBetCommand {
                GamePlayAutoBetInfo = model,
            };

            StartAutoBetExecutor xcutor = new StartAutoBetExecutor(
                svc, container, commonSvc);
            xcutor.Execute(cmd, (xcmd) => { });
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidateStartAutoBetExecutor_TotalAmountMustBeGreaterThan0()
        {
            IDependencyContainer container;
            IDevilSixGameBackService svc;
            IGenerateTrackingID commonSvc;
            setupValidators(out svc, out container, out commonSvc);

            var model = new GamePlayAutoBetInformation {
                UserName = "Nit",
                RoundID = 1,
                Amount = 2,
                TotalAmount = -10,
                Interval = 3
            };
            var cmd = new StartAutoBetCommand {
                GamePlayAutoBetInfo = model,
            };

            StartAutoBetExecutor xcutor = new StartAutoBetExecutor(
                svc, container, commonSvc);
            xcutor.Execute(cmd, (xcmd) => { });
        }


        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidateStartAutoBetExecutor_TotalAmountMustBeGreaterThanAmount()
        {
            IDependencyContainer container;
            IDevilSixGameBackService svc;
            IGenerateTrackingID commonSvc;
            setupValidators(out svc, out container, out commonSvc);

            var model = new GamePlayAutoBetInformation {
                UserName = "Nit",
                RoundID = 4,
                Amount = 100,
                TotalAmount = 50,
                Interval = 3
            };
            var cmd = new StartAutoBetCommand {
                GamePlayAutoBetInfo = model,
            };

            StartAutoBetExecutor xcutor = new StartAutoBetExecutor(
                svc, container, commonSvc);
            xcutor.Execute(cmd, (xcmd) => { });
        }

        private static void setupValidators(out IDevilSixGameBackService svc, out IDependencyContainer container, out IGenerateTrackingID commonSvc)
        {
            var fac = new PerfEx.Infrastructure.Containers.StructureMapAdapter.StructureMapAbstractFactory();
            var reg = fac.CreateRegistry();

            reg.Register<IValidator<GamePlayAutoBetInformation, StartAutoBetCommand>
                , DataAnnotationValidator<GamePlayAutoBetInformation, StartAutoBetCommand>>();

            reg.Register<IValidator<GamePlayAutoBetInformation, StartAutoBetCommand>
                , GamePlayAutoBetInformation_StartAutoBetValidators>();

            container = fac.CreateContainer(reg);
            commonSvc = null;
            svc = null;
        }
    }
}
