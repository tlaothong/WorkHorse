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
    public class GamePlayInformationSpecs
    {
        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidateGamePlayInformation_UserNameCanNotBeNull()
        {
            IDependencyContainer container;
            IColorsGameDataQuery svc;
            setupValidators(out container, out svc);

            var model = new GamePlayInformation {
               UserName = null
            };
            var cmd = new ListGamePlayInfoCommand {
                GamePlayInfo = model,
            };

            ListGamePlayInfoExecutor xcutor = new ListGamePlayInfoExecutor(
                svc, container);
            xcutor.Execute(cmd, (xcmd) => { });
        }

        private static void setupValidators(out IDependencyContainer container, out IColorsGameDataQuery svc)
        {
            var fac = new PerfEx.Infrastructure.Containers.StructureMapAdapter.StructureMapAbstractFactory();
            var reg = fac.CreateRegistry();

            reg.Register<IValidator<GamePlayInformation, NullCommand>
                , DataAnnotationValidator<GamePlayInformation, NullCommand>>();
            //reg.Register<IValidator<GamePlayInformation, ListGamePlayInfoCommand>
            //    , GamePlayInformation_ListGamePlayInfoValidator>();

            container = fac.CreateContainer(reg);
            svc = null;
        }
    }
}
