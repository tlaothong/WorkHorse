using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.DevilSix.Commands;
using TheS.Casinova.DevilSix.DAL;
using PerfEx.Infrastructure;
using PerfEx.Infrastructure.Validation;

namespace TheS.Casinova.DevilSix.WebExecutors
{
    public class ListRangeActionLogExecutor
         : SynchronousCommandExecutorBase<ListRangeActionLogCommand>
    {
        private IListRangeActionLog _iListRangeActionlog;
        private IDependencyContainer _container;

        public ListRangeActionLogExecutor(IDevilSixGameDataQuery dqr, IDependencyContainer container) 
        {
            _iListRangeActionlog = dqr;
            _container = container;
        }
        protected override void ExecuteCommand(ListRangeActionLogCommand command)
        {
            //Validation FromDateTime
            var FromDateTimeErrors = ValidationHelper.Validate(_container, command.FromBetDateTime, command);
            if (FromDateTimeErrors.Any()) {
                throw new ValidationErrorException(FromDateTimeErrors);
            }

            //Validation ThruDateTime
            var ThruDateTimeErrors = ValidationHelper.Validate(_container, command.ThruBetDateTime, command);
            if (ThruDateTimeErrors.Any()) {
                throw new ValidationErrorException(ThruDateTimeErrors);
            }

            //List single action log information
            command.ActionLogInformation = _iListRangeActionlog.List(command);
        }
    }
}
