using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerfEx.Infrastructure;
using TheS.Casinova.DevilSix.DAL;
using TheS.Casinova.DevilSix.Commands;
using TheS.Casinova.DevilSix.Models;
using PerfEx.Infrastructure.Validation;
using TheS.Casinova.DevilSix.Validators;

namespace TheS.Casinova.DevilSix.WebExecutors.UnitSpecs
{
    [TestClass]
    public class ListRangeActionLogExecutorSpecs
    {
        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidateListRangeActionLogExecutor_RoundIDMustBeGretaerThan0()
        {
            IDependencyContainer container;
            IDevilSixGameDataQuery svc;
            setupValidators(out container, out svc);

            var FromDateTimeModel = new BetInformation {
                RoundID = 0,
                BetDateTime = DateTime.Parse("1/13/2011")

            };

            var ThruDateTimeModel = new BetInformation {
                BetDateTime = DateTime.Parse("1/15/2011")

            };

            var cmd = new ListRangeActionLogCommand {
                FromBetDateTime = FromDateTimeModel,
                ThruBetDateTime = ThruDateTimeModel
            };

            ListRangeActionLogExecutor xcutor = new ListRangeActionLogExecutor(
                svc, container);
            xcutor.Execute(cmd, (xcmd) => { });
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidateListRangeActionLogExecutor_RoundIDMustBeLowerThan5()
        {
            IDependencyContainer container;
            IDevilSixGameDataQuery svc;
            setupValidators(out container, out svc);

            var FromDateTimeModel = new BetInformation {
                RoundID = 6,
                BetDateTime = DateTime.Parse("1/13/2011")

            };

            var ThruDateTimeModel = new BetInformation {
                BetDateTime = DateTime.Parse("1/15/2011")

            };

            var cmd = new ListRangeActionLogCommand {
                FromBetDateTime = FromDateTimeModel,
                ThruBetDateTime = ThruDateTimeModel
            };

            ListRangeActionLogExecutor xcutor = new ListRangeActionLogExecutor(
                svc, container);
            xcutor.Execute(cmd, (xcmd) => { });
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidateListRangeActionLogExecutor_FromDateTimeMustBeNotToday()
        {
            IDependencyContainer container;
            IDevilSixGameDataQuery svc;
            setupValidators(out container, out svc);

            var FromDateTimeModel = new BetInformation {
                RoundID = 2,
                BetDateTime = DateTime.Today

            };

            var ThruDateTimeModel = new BetInformation {
                BetDateTime = DateTime.Parse("1/15/2011")

            };

            var cmd = new ListRangeActionLogCommand {
                FromBetDateTime = FromDateTimeModel,
                ThruBetDateTime = ThruDateTimeModel
            };

            ListRangeActionLogExecutor xcutor = new ListRangeActionLogExecutor(
                svc, container);
            xcutor.Execute(cmd, (xcmd) => { });
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidateListRangeActionLogExecutor_ThrueDateTimeMustBeNotToday()
        {
            IDependencyContainer container;
            IDevilSixGameDataQuery svc;
            setupValidators(out container, out svc);

            var FromDateTimeModel = new BetInformation {
                RoundID = 2,
                BetDateTime = DateTime.Parse("1/15/2011")

            };

            var ThruDateTimeModel = new BetInformation {
                BetDateTime = DateTime.Today

            };

            var cmd = new ListRangeActionLogCommand {
                FromBetDateTime = FromDateTimeModel,
                ThruBetDateTime = ThruDateTimeModel
            };

            ListRangeActionLogExecutor xcutor = new ListRangeActionLogExecutor(
                svc, container);
            xcutor.Execute(cmd, (xcmd) => { });
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidateListRangeActionLogExecutor_ThrueDateTimeMustBeGreaterThanFromDateTime()
        {
            IDependencyContainer container;
            IDevilSixGameDataQuery svc;
            setupValidators(out container, out svc);

            var FromDateTimeModel = new BetInformation {
                RoundID = 2,
                BetDateTime = DateTime.Parse("1/15/2011")

            };

            var ThruDateTimeModel = new BetInformation {
                BetDateTime = DateTime.Parse("1/14/2011")

            };

            var cmd = new ListRangeActionLogCommand {
                FromBetDateTime = FromDateTimeModel,
                ThruBetDateTime = ThruDateTimeModel
            };

            ListRangeActionLogExecutor xcutor = new ListRangeActionLogExecutor(
                svc, container);
            xcutor.Execute(cmd, (xcmd) => { });
        }

        private static void setupValidators(out IDependencyContainer container, out IDevilSixGameDataQuery svc)
        {
            var fac = new PerfEx.Infrastructure.Containers.StructureMapAdapter.StructureMapAbstractFactory();
            var reg = fac.CreateRegistry();

            reg.Register<IValidator<BetInformation, ListRangeActionLogCommand>
                , DataAnnotationValidator<BetInformation, ListRangeActionLogCommand>>();

            reg.Register<IValidator<BetInformation, ListRangeActionLogCommand>
                , BetInformation_ListRangeActionLogValidators>();

            container = fac.CreateContainer(reg);
            svc = null;
        }
    }
}
