using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerfEx.Infrastructure;
using TheS.Casinova.MLN.DAL;
using TheS.Casinova.MLN.Models;
using TheS.Casinova.MLN.Commands;
using PerfEx.Infrastructure.Validation;
using TheS.Casinova.MLN.Validators;

namespace TheS.Casinova.MLN.WebExecutors.UnitSpecs
{
    [TestClass]
    public class ListMLNInfoExecutorSpecs
    {
        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidateListMLNInfoExecutor_NameCanNotBeNull()
        {
            IDependencyContainer container;
            IMLNModuleDataQuery svc;

            setupValidators(out container, out svc);

            var model = new MLNInformation {
                UserName = null,
            };
            var cmd = new ListMLNInfoCommand {
                MLNInfo = model,
            };

            ListMLNInfoExecutor xcutor = new ListMLNInfoExecutor(
                svc, container);
            xcutor.Execute(cmd, (xcmd) => { });
        }

        private static void setupValidators(out IDependencyContainer container, out IMLNModuleDataQuery svc)
        {
            var fac = new PerfEx.Infrastructure.Containers.StructureMapAdapter.StructureMapAbstractFactory();
            var reg = fac.CreateRegistry();

            reg.Register<IValidator<MLNInformation, ListMLNInfoCommand>
                , DataAnnotationValidator<MLNInformation, ListMLNInfoCommand>>();

            reg.Register<IValidator<MLNInformation, ListMLNInfoCommand>
               , MLNInformation_ListMLNInfoValidators>();

            container = fac.CreateContainer(reg);
            svc = null;
        }
    }
}
