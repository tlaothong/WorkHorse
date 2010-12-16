using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerfEx.Infrastructure.Validation;
using PerfEx.Infrastructure;
using TheS.Casinova.MagicNine.BackServices;
using TheS.Casinova.MagicNine.Models;
using TheS.Casinova.MagicNine.Commands;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.MagicNine.Validators;
using TheS.Casinova.Common.Services;

namespace TheS.Casinova.MagicNine.WebExecutors.UnitSpecs
{
    [TestClass]
    public class GamePlayAutoBetInformationSpecs
    {
        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidateGamePlayAutoBetInformation_NameCanNotBeNull()
        {
            IDependencyContainer container;
            IMagicNineGameBackService svc;
            IGenerateTrackingID commonSvc;
            setupValidators(out container, out svc, out commonSvc);

            var model = new GamePlayAutoBetInformation {
                UserName = null,
                RoundID = 1,
                Amount = 100,
                Interval = 2
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
        public void ValidateGamePlayAutoBetInformation_RoundIDMustNotLowerThan0()
        {
            IDependencyContainer container;
            IMagicNineGameBackService svc;
            IGenerateTrackingID commonSvc;
            setupValidators(out container, out svc, out commonSvc);

            var model = new GamePlayAutoBetInformation {
                UserName = "Natayit",
                RoundID = -1,
                Amount = 100,
                Interval = 2
            };
            var cmd = new StartAutoBetCommand {
                GamePlayAutoBetInfo = model,
            };

            StartAutoBetExecutor xcutor = new StartAutoBetExecutor(
                svc, container,commonSvc);
            xcutor.Execute(cmd, (xcmd) => { });
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidateGamePlayAutoBetInformation_AmountMustNotLowerThan0()
        {
            IDependencyContainer container;
            IMagicNineGameBackService svc;
            IGenerateTrackingID commonSvc;
            setupValidators(out container, out svc, out commonSvc);

            var model = new GamePlayAutoBetInformation {
                UserName = "Natayit",
                RoundID = 1,
                Amount = -100,
                Interval = 2
            };
            var cmd = new StartAutoBetCommand {
                GamePlayAutoBetInfo = model,
            };

            StartAutoBetExecutor xcutor = new StartAutoBetExecutor(
                svc, container,commonSvc);
            xcutor.Execute(cmd, (xcmd) => { });
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidateGamePlayAutoBetInformation_IntervalMustNotLowerThan0()
        {
            IDependencyContainer container;
            IMagicNineGameBackService svc;
            IGenerateTrackingID commonSvc;
            setupValidators(out container, out svc, out commonSvc);

            var model = new GamePlayAutoBetInformation {
                UserName = "Natayit",
                RoundID = 1,
                Amount = 100,
                Interval = -1
            };
            var cmd = new StartAutoBetCommand {
                GamePlayAutoBetInfo = model,
            };

            StartAutoBetExecutor xcutor = new StartAutoBetExecutor(
                svc, container, commonSvc);
            xcutor.Execute(cmd, (xcmd) => { });
        }

        private static void setupValidators(out IDependencyContainer container, out IMagicNineGameBackService svc, out IGenerateTrackingID commonSvc)
        {
            var fac = new PerfEx.Infrastructure.Containers.StructureMapAdapter.StructureMapAbstractFactory();
            var reg = fac.CreateRegistry();

            reg.Register<IValidator<GamePlayAutoBetInformation, StartAutoBetCommand>
                , DataAnnotationValidator<GamePlayAutoBetInformation, StartAutoBetCommand>>();

            reg.Register<IValidator<GamePlayAutoBetInformation, StartAutoBetCommand>
                , GamePlayAutoBetInformation_StartAutoBetValidators>();

            reg.Register<IValidator<GamePlayAutoBetInformation, StopAutoBetCommand>
               , DataAnnotationValidator<GamePlayAutoBetInformation, StopAutoBetCommand>>();

            reg.Register<IValidator<GamePlayAutoBetInformation, StopAutoBetCommand>
                , GamePlayAutoBetInformation_StopAutoBetValidators>();

            container = fac.CreateContainer(reg);
            svc = null;
            commonSvc = null;
        }
    }
}
