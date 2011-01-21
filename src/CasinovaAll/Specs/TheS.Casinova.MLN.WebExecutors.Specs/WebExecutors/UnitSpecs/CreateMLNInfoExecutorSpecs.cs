using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerfEx.Infrastructure.Validation;
using PerfEx.Infrastructure;
using TheS.Casinova.MLN.BackServices;
using TheS.Casinova.MLN.Models;
using TheS.Casinova.MLN.Commands;
using TheS.Casinova.MLN.Validators;

namespace TheS.Casinova.MLN.WebExecutors.UnitSpecs
{
    [TestClass]
    public class CreateMLNInfoExecutorSpecs
    {
        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidateCreateMLNInfoExecutor_NameCanNotBeNull()
        {
            IDependencyContainer container;
            IMLNModuleBackService svc;

            setupValidators(out container, out svc);

            var model = new MLNInformation {
                UserName = null,
                UplineLevel1 = "Krai"
            };
            var cmd = new CreateMLNInfoCommand {
                MLNInfo = model,
            };

            CreateMLNInfoExecutor xcutor = new CreateMLNInfoExecutor(
                svc, container);
            xcutor.Execute(cmd, (xcmd) => { });
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationErrorException))]
        public void ValidateCreateMLNInfoExecutor_UplineLevel1CanNotBeNull()
        {
            IDependencyContainer container;
            IMLNModuleBackService svc;

            setupValidators(out container, out svc);

            var model = new MLNInformation {
                UserName = "Nit",
                UplineLevel1 = null
            };
            var cmd = new CreateMLNInfoCommand {
                MLNInfo = model,
            };

            CreateMLNInfoExecutor xcutor = new CreateMLNInfoExecutor(
                svc, container);
            xcutor.Execute(cmd, (xcmd) => { });
        }

        private static void setupValidators(out IDependencyContainer container, out IMLNModuleBackService svc)
        {
            var fac = new PerfEx.Infrastructure.Containers.StructureMapAdapter.StructureMapAbstractFactory();
            var reg = fac.CreateRegistry();

            reg.Register<IValidator<MLNInformation, CreateMLNInfoCommand>
                , DataAnnotationValidator<MLNInformation, CreateMLNInfoCommand>>();

            reg.Register<IValidator<MLNInformation, CreateMLNInfoCommand>
               , MLNInformation_CreateMLNInfoValidators>();

            container = fac.CreateContainer(reg);
            svc = null;
        }
    }
}
