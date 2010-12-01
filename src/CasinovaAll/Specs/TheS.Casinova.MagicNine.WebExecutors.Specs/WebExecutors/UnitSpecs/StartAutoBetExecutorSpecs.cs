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

namespace TheS.Casinova.MagicNine.WebExecutors.UnitSpecs
{
    [TestClass]
    public class StartAutoBetExecutorSpecs
    {
        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidateStartAutoBetExecutor_NameCanNotBeNull()
        {
            IDependencyContainer container;
            IMagicNineGameBackService svc;
            setupValidators(out container, out svc);

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
                svc, container);
            xcutor.Execute(cmd, (xcmd) => { });
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidateStartAutoBetExecutor_RoundIDMustNotLowerThan0()
        {
            IDependencyContainer container;
            IMagicNineGameBackService svc;
            setupValidators(out container, out svc);

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
                svc, container);
            xcutor.Execute(cmd, (xcmd) => { });
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidateStartAutoBetExecutor_AmountMustNotLowerThan0()
        {
            IDependencyContainer container;
            IMagicNineGameBackService svc;
            setupValidators(out container, out svc);

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
                svc, container);
            xcutor.Execute(cmd, (xcmd) => { });
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidateStartAutoBetExecutor_IntervalMustNotLowerThan0()
        {
            IDependencyContainer container;
            IMagicNineGameBackService svc;
            setupValidators(out container, out svc);

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
                svc, container);
            xcutor.Execute(cmd, (xcmd) => { });
        }

        private static void setupValidators(out IDependencyContainer container, out IMagicNineGameBackService svc)
        {
            var fac = new PerfEx.Infrastructure.Containers.StructureMapAdapter.StructureMapAbstractFactory();
            var reg = fac.CreateRegistry();

            reg.Register<IValidator<GamePlayAutoBetInformation, StartAutoBetCommand>
                , DataAnnotationValidator<GamePlayAutoBetInformation, StartAutoBetCommand>>();

            container = fac.CreateContainer(reg);
            svc = null;
        }
    }
}
