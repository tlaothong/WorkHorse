using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerfEx.Infrastructure.Validation;
using PerfEx.Infrastructure;
using TheS.Casinova.TwoWins.BackServices;
using TheS.Casinova.TwoWins.Models;
using TheS.Casinova.TwoWins.Commands;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.TwoWins.Validators;

namespace TheS.Casinova.TwoWins.WebExecutors.UnitSpecs
{
    [TestClass]
    public class RangeBetInformationSpecs
    {
        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidateRangeBetInformation_UserNameCanNotBeNull()
        {
            IDependencyContainer container;
            ITwoWinsGameBackService svc;
            setupValidators(out container, out svc);

            var model = new RangeBetInformation {
                UserName = null,
                RoundID = 1,
                FromAmount = 1,
                ThruAmount = 20             
            };
            var cmd = new RangeBetCommand {
               RangeBetInfo = model,
            };

           RangeBetExecutor xcutor = new RangeBetExecutor(
                svc, container);
            xcutor.Execute(cmd, (xcmd) => { });
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidateRangeBetInformation_RoundIDMustBeNotLowerThan0()
        {
            IDependencyContainer container;
            ITwoWinsGameBackService svc;
            setupValidators(out container, out svc);

            var model = new RangeBetInformation {
                UserName = "Nayit",
                RoundID = -1,
                FromAmount = 1,
                ThruAmount = 20
            };
            var cmd = new RangeBetCommand {
                RangeBetInfo = model,
            };

            RangeBetExecutor xcutor = new RangeBetExecutor(
                 svc, container);
            xcutor.Execute(cmd, (xcmd) => { });
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidateRangeBetInformation_FromAmountMustBeGreaterThan0()
        {
            IDependencyContainer container;
            ITwoWinsGameBackService svc;
            setupValidators(out container, out svc);

            var model = new RangeBetInformation {
                UserName = "Nayit",
                RoundID = 1,
                FromAmount = 0,
                ThruAmount = 20
            };
            var cmd = new RangeBetCommand {
                RangeBetInfo = model,
            };

            RangeBetExecutor xcutor = new RangeBetExecutor(
                 svc, container);
            xcutor.Execute(cmd, (xcmd) => { });
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidateRangeBetInformation_ThruAmountMustBeGreaterThan0()
        {
            IDependencyContainer container;
            ITwoWinsGameBackService svc;
            setupValidators(out container, out svc);

            var model = new RangeBetInformation {
                UserName = "Nayit",
                RoundID = 1,
                FromAmount = 1,
                ThruAmount = 0
            };
            var cmd = new RangeBetCommand {
                RangeBetInfo = model,
            };

            RangeBetExecutor xcutor = new RangeBetExecutor(
                 svc, container);
            xcutor.Execute(cmd, (xcmd) => { });
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidateRangeBetInformation_ThruAmountMustBeGreaterFromAmount()
        {
            IDependencyContainer container;
            ITwoWinsGameBackService svc;
            setupValidators(out container, out svc);

            var model = new RangeBetInformation {
                UserName = "Nayit",
                RoundID = 1,
                FromAmount = 45,
                ThruAmount = 34
            };
            var cmd = new RangeBetCommand {
                RangeBetInfo = model,
            };

            RangeBetExecutor xcutor = new RangeBetExecutor(
                 svc, container);
            xcutor.Execute(cmd, (xcmd) => { });
        }

        private static void setupValidators(out IDependencyContainer container, out ITwoWinsGameBackService svc)
        {
            var fac = new PerfEx.Infrastructure.Containers.StructureMapAdapter.StructureMapAbstractFactory();
            var reg = fac.CreateRegistry();

            reg.Register<IValidator<RangeBetInformation, NullCommand>
                , DataAnnotationValidator<RangeBetInformation, NullCommand>>();

            reg.Register<IValidator<RangeBetInformation, RangeBetCommand>
               , RangeBetInformation_RangeBetValidators>();

            container = fac.CreateContainer(reg);
            svc = null;
        }
    }
}
