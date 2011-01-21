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
using TheS.Casinova.DevilSix.Validators;

namespace TheS.Casinova.DevilSix.WebExecutors.UnitSpecs
{
    [TestClass]
    public class ListSingleActionLogExecutorSpecs
    {
        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidateListSingleActionLogExecutor_RoundIDMustBeGretaerThan0()
        {
            IDependencyContainer container;
            IDevilSixGameDataQuery svc;
            setupValidators(out container, out svc);

            var model = new BetInformation {
                RoundID = 0,
                BetDateTime = DateTime.Parse("1/13/2011")

            };
            var cmd = new ListSingleActionLogCommand {
                ActionLogInfo = model
            };

            ListSingleActionLogExecutor xcutor = new ListSingleActionLogExecutor(
                svc, container);
            xcutor.Execute(cmd, (xcmd) => { });
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidateListSingleActionLogExecutor_RoundIDMustBeLowerThan5()
        {
            IDependencyContainer container;
            IDevilSixGameDataQuery svc;
            setupValidators(out container, out svc);

            var model = new BetInformation {
                RoundID = 6,
                BetDateTime = DateTime.Parse("1/13/2011")

            };
            var cmd = new ListSingleActionLogCommand {
                ActionLogInfo = model
            };

            ListSingleActionLogExecutor xcutor = new ListSingleActionLogExecutor(
                svc, container);
            xcutor.Execute(cmd, (xcmd) => { });
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidateListSingleActionLogExecutor_DateTimeMustBeNotToday()
        {
            IDependencyContainer container;
            IDevilSixGameDataQuery svc;
            setupValidators(out container, out svc);

            var model = new BetInformation {
                RoundID = 3,
                BetDateTime = DateTime.Today

            };
            var cmd = new ListSingleActionLogCommand {
                ActionLogInfo = model
            };

            ListSingleActionLogExecutor xcutor = new ListSingleActionLogExecutor(
                svc, container);
            xcutor.Execute(cmd, (xcmd) => { });
        }


        private static void setupValidators(out IDependencyContainer container, out IDevilSixGameDataQuery svc)
        {
            var fac = new PerfEx.Infrastructure.Containers.StructureMapAdapter.StructureMapAbstractFactory();
            var reg = fac.CreateRegistry();

            reg.Register<IValidator<BetInformation, ListSingleActionLogCommand>
                , DataAnnotationValidator<BetInformation, ListSingleActionLogCommand>>();

            reg.Register<IValidator<BetInformation, ListSingleActionLogCommand>
                , BetInformation_ListSingleActionLogValidators>();

            container = fac.CreateContainer(reg);
            svc = null;
        }
    }
}
