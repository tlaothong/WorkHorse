using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TheS.Casinova.Colors.WebExecutors.UnitSpecs
{
    using TheS.Casinova.Colors.BackServices;
    using PerfEx.Infrastructure.Validation;
    using TheS.Casinova.Colors.Models;
    using PerfEx.Infrastructure.CommandPattern;
    using PerfEx.Infrastructure;
    using TheS.Casinova.Colors.Commands;

    [TestClass]
    public class BetExecutorSpecs
    {
        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidateBetExecutor_NameCanNotBeNull()
        {
            IDependencyContainer container;
            IColorsGameBackService svc;
            setupValidators(out container, out svc);

            var model = new PlayerActionInformation {
                UserName = null,
                Round = 1,
                ActionType = "Black",
                Amount = 500,
            };
            var cmd = new BetCommand {
                PlayerActionInfo = model,
            };

            BetColorsExecutor xcutor = new BetColorsExecutor(
                svc, container);
            xcutor.Execute(cmd, (xcmd) => { });
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidateBetExecutor_RoundIDMustNotLessThan0()
        {
            IDependencyContainer container;
            IColorsGameBackService svc;
            setupValidators(out container, out svc);

            var model = new PlayerActionInformation {
                UserName = "Natayit",
                Round = -1,
                ActionType = "Black",
                Amount = 500,
            };
            var cmd = new BetCommand {
                PlayerActionInfo = model,
            };

            BetColorsExecutor xcutor = new BetColorsExecutor(
                svc, container);
            xcutor.Execute(cmd, (xcmd) => { });
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidateBetExecutor_ActionTypeCanNotBeNull()
        {
            IDependencyContainer container;
            IColorsGameBackService svc;
            setupValidators(out container, out svc);

            var model = new PlayerActionInformation {
                UserName = "Natayit",
                Round = 2,
                ActionType = null,
                Amount = 500,
            };
            var cmd = new BetCommand {
                PlayerActionInfo = model,
            };

            BetColorsExecutor xcutor = new BetColorsExecutor(
                svc, container);
            xcutor.Execute(cmd, (xcmd) => { });
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidateBetExecutor_AmountMustNotLessThan0()
        {
            IDependencyContainer container;
            IColorsGameBackService svc;
            setupValidators(out container, out svc);

            var model = new PlayerActionInformation {
                UserName = "Natayit",
                Round = 1,
                ActionType = "Black",
                Amount = -500,
            };
            var cmd = new BetCommand {
                PlayerActionInfo = model,
            };

            BetColorsExecutor xcutor = new BetColorsExecutor(
                svc, container);
            xcutor.Execute(cmd, (xcmd) => { });
        }

        private static void setupValidators(out IDependencyContainer container, out IColorsGameBackService svc)
        {
            var fac = new PerfEx.Infrastructure.Containers.StructureMapAdapter.StructureMapAbstractFactory();
            var reg = fac.CreateRegistry();

            reg.Register<IValidator<PlayerActionInformation, BetCommand>
                , DataAnnotationValidator<PlayerActionInformation, BetCommand>>();

            container = fac.CreateContainer(reg);
            svc = null;
        }
    }
}
