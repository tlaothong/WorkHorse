using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheS.Casinova.Colors.WebExecutors.UnitSpecs
{
    using TheS.Casinova.Colors.Validators;
    using PerfEx.Infrastructure;
    using TheS.Casinova.Colors.BackServices;
    using TheS.Casinova.Colors.Models;
    using TheS.Casinova.Colors.Commands;
    using PerfEx.Infrastructure.Validation;
    using PerfEx.Infrastructure.CommandPattern;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TheS.Casinova.Colors.DAL;

    [TestClass]
    public class GameRoundInformationSpecs
    {
        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidateGameRoundInformation_RoundIDMustDoNotLessThan0()
        {
            IDependencyContainer container;
            IColorsGameDataQuery svc;
            setupValidators(out container, out svc);

            var model = new GameRoundInformation {
               RoundID = -5,
            };
            var cmd = new GetGameResultCommand{
                GameResultGameRoundInfo = model,
            };

            GetGameResultExecutor xcutor = new GetGameResultExecutor(
                svc, container);
            xcutor.Execute(cmd, (xcmd) => { });
        }
        private static void setupValidators(out IDependencyContainer container, out IColorsGameDataQuery svc)
        {
            var fac = new PerfEx.Infrastructure.Containers.StructureMapAdapter.StructureMapAbstractFactory();
            var reg = fac.CreateRegistry();

            reg.Register<IValidator<GameRoundInformation, GetGameResultCommand>
                , DataAnnotationValidator<GameRoundInformation, GetGameResultCommand>>();
            //reg.Register<IValidator<GameRoundInformation, GetGameResultCommand>
            //    , GameRoundInformation_GetGameResultValidator>();

            container = fac.CreateContainer(reg);
            svc = null;
        }
    }
}
