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

namespace TheS.Casinova.TwoWins.WebExecutors.UnitSpecs
{
     [TestClass]
     public class ActionLogInformationSpecs
    {
        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidateActionLogInformation_RoundIDMustbBeNotLowerThan0()
        {
            IDependencyContainer container;
            ITwoWinsGameDataQuery svc;
            setupValidators(out container, out svc);

            var model = new ActionLogInformation {
                RoundID = -1
            };
            var cmd = new ListSingleActionLogCommand {
                ActionLogInfo = model,
            };

            ListSingleActionLogExecutor xcutor = new ListSingleActionLogExecutor(
                svc, container);
            xcutor.Execute(cmd, (xcmd) => { });
        }

        public void ValidateActionLogInformation_FromRoundIDMustbBeNotLowerThan0()
        {
            IDependencyContainer container;
            ITwoWinsGameDataQuery svc;
            setupValidators(out container, out svc);

            var model = new ActionLogInformation {
                FromRoundID = -1,
                ThruRoundID = 0
            };
            var cmd = new ListBetDataCommand {
                ActionLogInfo = model,
            };

            ListBetDataExecutor xcutor = new ListBetDataExecutor(
                svc, container);
            xcutor.Execute(cmd, (xcmd) => { });
        }

        public void ValidateActionLogInformation_ThruRoundIDMustbBeNotLowerThan0()
        {
            IDependencyContainer container;
            ITwoWinsGameDataQuery svc;
            setupValidators(out container, out svc);

            var model = new ActionLogInformation {
                FromRoundID = 5,
                ThruRoundID = -2
            };
            var cmd = new ListBetDataCommand {
                ActionLogInfo = model,
            };

            ListBetDataExecutor xcutor = new ListBetDataExecutor(
                svc, container);
            xcutor.Execute(cmd, (xcmd) => { });
        }

        private static void setupValidators(out IDependencyContainer container, out ITwoWinsGameDataQuery svc)
        {
            var fac = new PerfEx.Infrastructure.Containers.StructureMapAdapter.StructureMapAbstractFactory();
            var reg = fac.CreateRegistry();

            reg.Register<IValidator<ActionLogInformation, NullCommand>
                , DataAnnotationValidator<ActionLogInformation, NullCommand>>();
            //reg.Register<IValidator<GamePlayInformation, ListGamePlayInfoCommand>
            //    , GamePlayInformation_ListGamePlayInfoValidator>();

            container = fac.CreateContainer(reg);
            svc = null;
        }
    }
}
