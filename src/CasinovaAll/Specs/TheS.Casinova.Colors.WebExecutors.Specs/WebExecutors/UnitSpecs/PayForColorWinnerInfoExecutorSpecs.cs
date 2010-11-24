using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheS.Casinova.Colors.WebExecutors.UnitSpecs
{
    using TheS.Casinova.Colors.BackServices;
    using PerfEx.Infrastructure.Validation;
    using TheS.Casinova.Colors.Models;
    using PerfEx.Infrastructure.CommandPattern;
    using PerfEx.Infrastructure;
    using TheS.Casinova.Colors.Commands;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PayForColorWinnerInfoExecutorSpecs
    {
        public void ValidatePayForColorWinnerInfoExecutor_NameCanNotBeNull()
        {
            IDependencyContainer container;
            IColorsGameBackService svc;
            setupValidators(out container, out svc);

            var model = new PlayerActionInformation {
                UserName = null,
                RoundID = 1
            };
            var cmd = new PayForColorsWinnerInfoCommand {
                PlayerActionInfo = model,
            };

            PayForColorsWinnerInfoExecutor xcutor = new PayForColorsWinnerInfoExecutor(
                svc, container);
            xcutor.Execute(cmd, (xcmd) => { });
        }

        public void ValidatePayForColorWinnerInfoExecutor_RoundIDMustNotLessThan0()
        {
            IDependencyContainer container;
            IColorsGameBackService svc;
            setupValidators(out container, out svc);

            var model = new PlayerActionInformation {
                UserName = "Yaya",
                RoundID = -2
            };
            var cmd = new PayForColorsWinnerInfoCommand {
                PlayerActionInfo = model,
            };

            PayForColorsWinnerInfoExecutor xcutor = new PayForColorsWinnerInfoExecutor(
                svc, container);
            xcutor.Execute(cmd, (xcmd) => { });
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidatePayForColorWinnerExecutor_ActionTypeCanNotBeNull()
        {
            IDependencyContainer container;
            IColorsGameBackService svc;
            setupValidators(out container, out svc);

            var model = new PlayerActionInformation {
                UserName = "Natayit",
                RoundID = 2,
                ActionType = null,
            };
            var cmd = new PayForColorsWinnerInfoCommand {
                PlayerActionInfo = model,
            };

            PayForColorsWinnerInfoExecutor xcutor = new PayForColorsWinnerInfoExecutor(
                svc, container);
            xcutor.Execute(cmd, (xcmd) => { });
        }

        private static void setupValidators(out IDependencyContainer container, out IColorsGameBackService svc)
        {
            var fac = new PerfEx.Infrastructure.Containers.StructureMapAdapter.StructureMapAbstractFactory();
            var reg = fac.CreateRegistry();

            reg.Register<IValidator<PlayerActionInformation, PayForColorsWinnerInfoCommand>
                , DataAnnotationValidator<PlayerActionInformation, PayForColorsWinnerInfoCommand>>();

            container = fac.CreateContainer(reg);
            svc = null;
        }
    }
}
