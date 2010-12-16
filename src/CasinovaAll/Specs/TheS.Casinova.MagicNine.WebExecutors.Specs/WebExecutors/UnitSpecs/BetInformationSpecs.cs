﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerfEx.Infrastructure.Validation;
using PerfEx.Infrastructure;
using TheS.Casinova.MagicNine.BackServices;
using TheS.Casinova.MagicNine.Models;
using TheS.Casinova.MagicNine.Commands;
using TheS.Casinova.Common.Services;


namespace TheS.Casinova.MagicNine.WebExecutors.UnitSpecs
{
    [TestClass]
    public class BetInformationSpecs
    {
        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidateBetInformation_NameCanNotBeNull()
        {
            IDependencyContainer container;
            IMagicNineGameBackService svc;
            IGenerateTrackingID commonSvc;
            setupValidators(out container, out svc,out commonSvc);

            var model = new BetInformation{
                UserName = null,
                RoundID = 1,
            };
            var cmd = new SingleBetCommand {
                BetInfo = model,
            };

            SingleBetExecutor xcutor = new SingleBetExecutor(
                svc, container, commonSvc);
            xcutor.Execute(cmd, (xcmd) => { });
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidateBetInformation_RoundIDMustNotLessThan0()
        {
            IDependencyContainer container;
            IMagicNineGameBackService svc;
            IGenerateTrackingID commonSvc;
            setupValidators(out container, out svc, out commonSvc);

            var model = new BetInformation {
                UserName = "Natayit",
                RoundID = -2,
            };
            var cmd = new SingleBetCommand {
                BetInfo = model,
            };

            SingleBetExecutor xcutor = new SingleBetExecutor(
                svc, container, commonSvc);
            xcutor.Execute(cmd, (xcmd) => { });
        }

        private static void setupValidators(out IDependencyContainer container, out IMagicNineGameBackService svc, out IGenerateTrackingID commonSvc)
        {
            var fac = new PerfEx.Infrastructure.Containers.StructureMapAdapter.StructureMapAbstractFactory();
            var reg = fac.CreateRegistry();

            reg.Register<IValidator<BetInformation, SingleBetCommand>
                , DataAnnotationValidator<BetInformation, SingleBetCommand>>();

            container = fac.CreateContainer(reg);
            svc = null;
            commonSvc = null;
        }
    }
}
