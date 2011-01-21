using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.DevilSix.DAL;
using PerfEx.Infrastructure;
using PerfEx.Infrastructure.Validation;
using TheS.Casinova.DevilSix.Commands;

namespace TheS.Casinova.DevilSix.WebExecutors
{
    public class ListSingleActionLogExecutor
        : SynchronousCommandExecutorBase<ListSingleActionLogCommand>
    {
        private IListSingleActionLog _iListSingleActionLog;
        private IDependencyContainer _container;

        public ListSingleActionLogExecutor(IDevilSixGameDataQuery dqr, IDependencyContainer containner ) 
        {
            _iListSingleActionLog = dqr;
            _container = containner;
        }

        protected override void ExecuteCommand(ListSingleActionLogCommand command)
        {
            //Validation
            var errors = ValidationHelper.Validate(_container, command.ActionLogInfo, command);
            if (errors.Any()) {
                throw new ValidationErrorException(errors);
            }

            //List single action log information
            command.ActionLogInformation = _iListSingleActionLog.List(command);
        }
    }
}
