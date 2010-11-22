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


namespace TheS.Casinova.MagicNine.WebExecutors.UnitSpecs
{
    [TestClass]
    public class SingleBetExecutorSpecs
    {
        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidateSingleBetExecutor_NameCanNotBeNull()
        {
            IDependencyContainer container;
            IMagicNineGameBackService svc;
            setupValidators(out container, out svc);

            var model = new BetInformation{
                UserName = null,
                Round = 1,
            };
            var cmd = new SingleBetCommand {
                BetInfo = model,
            };

            SingleBetExecutor xcutor = new SingleBetExecutor(
                svc, container);
            xcutor.Execute(cmd, (xcmd) => { });
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidateSingleBetExecutor_RoundIDMustNotLessThan0()
        {
            IDependencyContainer container;
            IMagicNineGameBackService svc;
            setupValidators(out container, out svc);

            var model = new BetInformation {
                UserName = "Natayit",
                Round = -2,
            };
            var cmd = new SingleBetCommand {
                BetInfo = model,
            };

            SingleBetExecutor xcutor = new SingleBetExecutor(
                svc, container);
            xcutor.Execute(cmd, (xcmd) => { });
        }

        private static void setupValidators(out IDependencyContainer container, out IMagicNineGameBackService svc)
        {
            var fac = new PerfEx.Infrastructure.Containers.StructureMapAdapter.StructureMapAbstractFactory();
            var reg = fac.CreateRegistry();

            reg.Register<IValidator<BetInformation, SingleBetCommand>
                , DataAnnotationValidator<BetInformation, SingleBetCommand>>();

            container = fac.CreateContainer(reg);
            svc = null;
        }
    }
}
