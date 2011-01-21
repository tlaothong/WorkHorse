using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.MLN.Commands;
using TheS.Casinova.MLN.BackServices;
using PerfEx.Infrastructure;
using PerfEx.Infrastructure.Validation;

namespace TheS.Casinova.MLN.WebExecutors
{
    /// <summary>
    /// สร้างข้อมูลระบบเครือข่าย
    /// </summary>
    public class CreateMLNInfoExecutor
        :SynchronousCommandExecutorBase<CreateMLNInfoCommand>
    {
        private ICreateMLNInfo _iCreateMLNInfo;
        private IDependencyContainer _container;

        public CreateMLNInfoExecutor(IMLNModuleBackService dac, IDependencyContainer container)
        {
            _iCreateMLNInfo = dac;
            _container = container;
        }

        protected override void ExecuteCommand(CreateMLNInfoCommand command)
        {
            //Validation
            var errors = ValidationHelper.Validate(_container, command.MLNInfo, command);
            if (errors.Any()) {
                throw new ValidationErrorException(errors);
            }

            _iCreateMLNInfo.CreateMLNInfo(command);
        }
    }
}
