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
    public class RoundInformationSpecs
    {
        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidateRoundInformation_RoundIDMustbBeNotLowerThan0()
        {
            IDependencyContainer container;
            ITwoWinsGameDataQuery svc;
            setupValidators(out container, out svc);

            var model = new RoundInformation {
                RoundID = -1
            };
            var cmd = new GetGameStatusCommand {
                RoundInfo = model,
            };

            GetGameStatusExecutor xcutor = new GetGameStatusExecutor(
                svc, container);
            xcutor.Execute(cmd, (xcmd) => { });
        }

        private static void setupValidators(out IDependencyContainer container, out ITwoWinsGameDataQuery svc)
        {
            var fac = new PerfEx.Infrastructure.Containers.StructureMapAdapter.StructureMapAbstractFactory();
            var reg = fac.CreateRegistry();

            reg.Register<IValidator<RoundInformation, NullCommand>
                , DataAnnotationValidator<RoundInformation, NullCommand>>();
            //reg.Register<IValidator<GamePlayInformation, ListGamePlayInfoCommand>
            //    , GamePlayInformation_ListGamePlayInfoValidator>();

            container = fac.CreateContainer(reg);
            svc = null;
        }
    }
}
