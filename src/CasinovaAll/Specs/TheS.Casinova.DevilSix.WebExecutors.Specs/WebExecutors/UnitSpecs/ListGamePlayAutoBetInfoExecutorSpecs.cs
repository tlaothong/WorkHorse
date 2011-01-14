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

namespace TheS.Casinova.DevilSix.WebExecutors.UnitSpecs
{
    [TestClass]
    public class ListGamePlayAutoBetInfoExecutorSpecs
    {
        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidateListGamePlayAutoBetInfoExecutor_UserNameCanNotBeNull()
        {
            IDependencyContainer container;
            IDevilSixGameDataQuery svc;
            setupValidators(out container, out svc);

            var model = new GamePlayAutoBetInformation {
                UserName = null
            };
            var cmd = new ListGamePlayAutoBetInfoCommand{
                GamePlayAutoBetInfo = model,
            };

            ListGamePlayAutoBetInfoExecutor xcutor = new ListGamePlayAutoBetInfoExecutor(
                svc, container);
            xcutor.Execute(cmd, (xcmd) => { });
        }

        private static void setupValidators(out IDependencyContainer container, out IDevilSixGameDataQuery svc)
        {
            var fac = new PerfEx.Infrastructure.Containers.StructureMapAdapter.StructureMapAbstractFactory();
            var reg = fac.CreateRegistry();

            reg.Register<IValidator<GamePlayAutoBetInformation, ListGamePlayAutoBetInfoCommand>
                , DataAnnotationValidator<GamePlayAutoBetInformation, ListGamePlayAutoBetInfoCommand>>();

            container = fac.CreateContainer(reg);
            svc = null;
        }
    }
}
