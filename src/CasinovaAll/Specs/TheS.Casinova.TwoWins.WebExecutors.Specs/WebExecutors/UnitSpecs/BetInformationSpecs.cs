using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerfEx.Infrastructure.Validation;
using PerfEx.Infrastructure;
using TheS.Casinova.TwoWins.DAL;
using TheS.Casinova.TwoWins.Models;
using TheS.Casinova.TwoWins.Commands;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.TwoWins.BackServices;
using TheS.Casinova.TwoWins.Validators;

namespace TheS.Casinova.TwoWins.WebExecutors.UnitSpecs
{
    [TestClass]
    public class BetInformationSpecs
    {
        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidateBetInformation_UserNameCanNotBeNull()
        {
            IDependencyContainer container;
            ITwoWinsGameDataQuery svc;
            setupValidators(out container, out svc);

            var model = new BetInformation {
                UserName = null,
                RoundID = 1
            };
            var cmd = new ListBetLogInfoCommand {
                BetInfo = model,
            };

            ListBetLogInfoExecutor xcutor = new ListBetLogInfoExecutor(
                svc, container);
            xcutor.Execute(cmd, (xcmd) => { });
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidateBetInformation_RoundIDMustBeNotLowerThan0()
        {
            IDependencyContainer container;
            ITwoWinsGameDataQuery svc;
            setupValidators(out container, out svc);

            var model = new BetInformation {
                UserName = "Nayit",
                RoundID = -1
            };
            var cmd = new ListBetLogInfoCommand {
                BetInfo = model,
            };

            ListBetLogInfoExecutor xcutor = new ListBetLogInfoExecutor(
                svc, container);
            xcutor.Execute(cmd, (xcmd) => { });
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidateBetInformation_AmountMustBeNotLowerThan1()
        {
            IDependencyContainer container;
            ITwoWinsGameBackService svc;
            setupValidators(out container, out svc);

            var model = new BetInformation {
                UserName = "Nayit",
                RoundID = 1,
                Amount = 0
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
        public void ValidateBetInformation_HandIDMustBeLowerThan0()
        {
            IDependencyContainer container;
            ITwoWinsGameBackService svc;
            setupValidators(out container, out svc);

            var model = new BetInformation {
                UserName = "Nayit",
                RoundID = 1,
                Amount = 5,
                HandID = -2
            };
            var cmd = new ChangeBetInfoCommand {
                BetInfo = model,
            };

           ChangeBetExecutor xcutor = new ChangeBetExecutor(
                svc, container);
            xcutor.Execute(cmd, (xcmd) => { });
        }

        private static void setupValidators(out IDependencyContainer container, out ITwoWinsGameDataQuery svc)
        {
            var fac = new PerfEx.Infrastructure.Containers.StructureMapAdapter.StructureMapAbstractFactory();
            var reg = fac.CreateRegistry();

            reg.Register<IValidator<BetInformation, NullCommand>
                , DataAnnotationValidator<BetInformation, NullCommand>>();
            //reg.Register<IValidator<GamePlayInformation, ListGamePlayInfoCommand>
            //    , GamePlayInformation_ListGamePlayInfoValidator>();

            container = fac.CreateContainer(reg);
            svc = null;
        }

        private static void setupValidators(out IDependencyContainer container, out ITwoWinsGameBackService svc)
        {
            var fac = new PerfEx.Infrastructure.Containers.StructureMapAdapter.StructureMapAbstractFactory();
            var reg = fac.CreateRegistry();

            reg.Register<IValidator<BetInformation, NullCommand>
                , DataAnnotationValidator<BetInformation, NullCommand>>();
            reg.Register<IValidator<BetInformation, SingleBetCommand>
                , BetInformation_SingleBetValidators>();
            reg.Register<IValidator<BetInformation, ChangeBetInfoCommand>
               , BetInformation_ChangeBetInfoValidators>();

            container = fac.CreateContainer(reg);
            svc = null;
        }
    }
}
