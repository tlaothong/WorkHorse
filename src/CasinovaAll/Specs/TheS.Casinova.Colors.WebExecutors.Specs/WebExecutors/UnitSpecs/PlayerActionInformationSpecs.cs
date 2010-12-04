using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerfEx.Infrastructure.Validation;
using PerfEx.Infrastructure;
using TheS.Casinova.Colors.BackServices;
using TheS.Casinova.Colors.Models;
using TheS.Casinova.Colors.Commands;
using TheS.Casinova.Colors.Validators;

namespace TheS.Casinova.Colors.WebExecutors.UnitSpecs
{
    [TestClass]
    public class PlayerActionInformationSpecs
    {
        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidatePlayerActionInformation_NameCanNotBeNull()
        {
            IDependencyContainer container;
            IColorsGameBackService svc;
            setupValidators(out container, out svc);

            var model = new PlayerActionInformation {
                UserName = null,
                RoundID = 1,
                ActionType = "Black",
                Amount = 500,
            };
            var cmd = new BetCommand {
                BetPlayerActionInfo = model,
            };

            BetColorsExecutor xcutor = new BetColorsExecutor(
                svc, container);
            xcutor.Execute(cmd, (xcmd) => { });
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidatePlayerActionInformation_RoundIDMustNotLessThan0()
        {
            IDependencyContainer container;
            IColorsGameBackService svc;
            setupValidators(out container, out svc);

            var model = new PlayerActionInformation {
                UserName = "Nittaya",
                RoundID = -1,
                ActionType = "Black",
                Amount = 500,
            };
            var cmd = new BetCommand {
                BetPlayerActionInfo = model,
            };

            BetColorsExecutor xcutor = new BetColorsExecutor(
                svc, container);
            xcutor.Execute(cmd, (xcmd) => { });
        }


        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidatePlayerActionInformation_AmountMustNotLessThan1()
        {
            IDependencyContainer container;
            IColorsGameBackService svc;
            setupValidators(out container, out svc);

            var model = new PlayerActionInformation {
                UserName = "Natayit",
                RoundID = 1,
                ActionType = "Black",
                Amount = -500,
            };
            var cmd = new BetCommand {
                BetPlayerActionInfo = model,
            };

            BetColorsExecutor xcutor = new BetColorsExecutor(
                svc, container);
            xcutor.Execute(cmd, (xcmd) => { });
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidatePlayerActionInformation_ActionTypeCanNotBeNull()
        {
            IDependencyContainer container;
            IColorsGameBackService svc;
            setupValidators(out container, out svc);

            var model = new PlayerActionInformation {
                UserName = "Natayit",
                RoundID = 1,
                ActionType = null,
                Amount = 500,
            };
            var cmd = new BetCommand {
                BetPlayerActionInfo = model,
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

            reg.Register<IValidator<PlayerActionInformation, PayForColorsWinnerInfoCommand>
              , DataAnnotationValidator<PlayerActionInformation, PayForColorsWinnerInfoCommand>>();

            reg.Register<IValidator<PlayerActionInformation, BetCommand>
               , PlayerActionInformation_BetValidators>();

            container = fac.CreateContainer(reg);
            svc = null;
        }
    }
}
