using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerfEx.Infrastructure.Validation;
using TheS.Casinova.TwoWins.DAL;
using PerfEx.Infrastructure;
using TheS.Casinova.TwoWins.Models;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.TwoWins.Commands;

namespace TheS.Casinova.TwoWins.WebExecutors.UnitSpecs
{
    [TestClass]
    public class TotalBetInformationSpecs
    {
        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidateTotalBetInformation_UserNameCanNotBeNull()
        {
            IDependencyContainer container;
            ITwoWinsGameDataQuery svc;
            setupValidators(out container, out svc);

            var model = new TotalBetInformation {
                UserName = null 
            };
            var cmd = new ListGamePlayInfoCommand {
                TotalBetInfo = model,
            };

            ListGamePlayInfoExecutor xcutor = new ListGamePlayInfoExecutor(
                svc, container);
            xcutor.Execute(cmd, (xcmd) => { });
 
        }

        private static void setupValidators(out IDependencyContainer container, out ITwoWinsGameDataQuery svc)
        {
            var fac = new PerfEx.Infrastructure.Containers.StructureMapAdapter.StructureMapAbstractFactory();
            var reg = fac.CreateRegistry();

            reg.Register<IValidator<TotalBetInformation, NullCommand>
                , DataAnnotationValidator<TotalBetInformation, NullCommand>>();
            //reg.Register<IValidator<GamePlayInformation, ListGamePlayInfoCommand>
            //    , GamePlayInformation_ListGamePlayInfoValidator>();

            container = fac.CreateContainer(reg);
            svc = null;
        }
    }
}
