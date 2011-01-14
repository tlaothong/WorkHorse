using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerfEx.Infrastructure.Validation;
using PerfEx.Infrastructure;
using TheS.Casinova.DevilSix.DAL;
using TheS.Casinova.DevilSix.Models;
using TheS.Casinova.DevilSix.Commands;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.DevilSix.Validators;

namespace TheS.Casinova.DevilSix.WebExecutors.UnitSpecs
{
    [TestClass]
    public class ListBetLogExecutorSpecs
    {
        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidateListBetLogExecutor_UserNameCanNotBeNull()
        {
            IDependencyContainer container;
            IDevilSixGameDataQuery svc;
            setupValidators(out container, out svc);

            var model = new BetInformation {
                UserName = null,
                RoundID = 1
            };
            var cmd = new ListBetLogCommand {
                BetInfo = model,
            };

            ListBetLogExecutor xcutor = new ListBetLogExecutor(
                svc, container);
            xcutor.Execute(cmd, (xcmd) => { });
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidateListBetLogExecutor_RoundIDMustBeGreaterThan0()
        {
            IDependencyContainer container;
            IDevilSixGameDataQuery svc;
            setupValidators(out container, out svc);

            var model = new BetInformation {
                UserName = "NiT",
                RoundID = 0
            };
            var cmd = new ListBetLogCommand {
                BetInfo = model,
            };

            ListBetLogExecutor xcutor = new ListBetLogExecutor(
                svc, container);
            xcutor.Execute(cmd, (xcmd) => { });
        }

        private static void setupValidators(out IDependencyContainer container, out IDevilSixGameDataQuery svc)
        {
            var fac = new PerfEx.Infrastructure.Containers.StructureMapAdapter.StructureMapAbstractFactory();
            var reg = fac.CreateRegistry();

            reg.Register<IValidator<BetInformation, ListBetLogCommand>
                , DataAnnotationValidator<BetInformation, ListBetLogCommand>>();

            reg.Register<IValidator<BetInformation, ListBetLogCommand>
                , BetInformation_ListBetLogValidators>();

            container = fac.CreateContainer(reg);
            svc = null;
        }
    }
}
