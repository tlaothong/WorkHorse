using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerfEx.Infrastructure.Validation;
using PerfEx.Infrastructure;
using TheS.Casinova.DevilSix.BackServices;
using TheS.Casinova.DevilSix.Models;
using TheS.Casinova.DevilSix.Commands;
using TheS.Casinova.Common.Services;
using TheS.Casinova.DevilSix.Validators;

namespace TheS.Casinova.DevilSix.WebExecutors.UnitSpecs
{
    [TestClass]
    public class StopAutoBetExecutorSpecs
    {
        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidateStopAutoBetExecutor_UserNameCanNotBeNull()
        {
            IDependencyContainer container;
            IDevilSixGameBackService svc;
            IGenerateTrackingID commonSvc;
            setupValidators(out container, out svc, out commonSvc);

            var model = new GamePlayAutoBetInformation {
                UserName = null,
                RoundID = 1
            };
            var cmd = new StopAutoBetCommand {
                GamePlayAutoBetInfo = model,
            };

            StopAutoBetExecutor xcutor = new StopAutoBetExecutor(
                svc, container, commonSvc);
            xcutor.Execute(cmd, (xcmd) => { });
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidateStopAutoBetExecutor_RoundIDMustBeGreaterThan0()
        {
            IDependencyContainer container;
            IDevilSixGameBackService svc;
            IGenerateTrackingID commonSvc;
            setupValidators(out container, out svc, out commonSvc);

            var model = new GamePlayAutoBetInformation {
                UserName = "Nit",
                RoundID = 0
            };
            var cmd = new StopAutoBetCommand {
                GamePlayAutoBetInfo = model,
            };

            StopAutoBetExecutor xcutor = new StopAutoBetExecutor(
                svc, container, commonSvc);
            xcutor.Execute(cmd, (xcmd) => { });
        }

        private static void setupValidators(out IDependencyContainer container, out IDevilSixGameBackService svc, out IGenerateTrackingID commonSvc)
        {
            var fac = new PerfEx.Infrastructure.Containers.StructureMapAdapter.StructureMapAbstractFactory();
            var reg = fac.CreateRegistry();

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
