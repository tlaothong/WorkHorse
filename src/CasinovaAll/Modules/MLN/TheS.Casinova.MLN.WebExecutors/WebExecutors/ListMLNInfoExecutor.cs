using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.MLN.Commands;
using TheS.Casinova.MLN.DAL;
using PerfEx.Infrastructure;
using PerfEx.Infrastructure.Validation;

namespace TheS.Casinova.MLN.WebExecutors
{
    /// <summary>
    /// ดึงข้อมูลจำนวน downline และจำนวนโบนัสที่มี
    /// </summary>
    public class ListMLNInfoExecutor
        : SynchronousCommandExecutorBase<ListMLNInfoCommand>
    {
        private IListMLNInfo _iListMLNInfo;
        private IDependencyContainer _container;

        public ListMLNInfoExecutor(IMLNModuleDataQuery dqr, IDependencyContainer container)
        {
            _iListMLNInfo = dqr;
            _container = container;
        }

        protected override void ExecuteCommand(ListMLNInfoCommand command)
        {
            //Validation
            var errors = ValidationHelper.Validate(_container, command.MLNInfo, command);
            if (errors.Any()) {
                throw new ValidationErrorException(errors);
            }

            //List MLN information
            command.MLNInformation = _iListMLNInfo.Get(command);
        }
    }
}
