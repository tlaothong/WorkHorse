using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.PlayerProfile.Commands;
using TheS.Casinova.PlayerProfile.DAL;
using PerfEx.Infrastructure;
using PerfEx.Infrastructure.Validation;


namespace TheS.Casinova.PlayerProfile.WebExecutors
{
    /// <summary>
    /// ดึงข้อมูล action log ของผู้เล่น
    /// </summary>
    public class ListActionLogExecutor
     : SynchronousCommandExecutorBase<ListActionLogCommand>
    {
        private IListActionLog _iListActionLog;
        private IDependencyContainer _container;

        public ListActionLogExecutor(IPlayerProfileDataQuery dqr, IDependencyContainer container)
        {
            _iListActionLog = dqr;
            _container = container;
        }

        protected override void ExecuteCommand(ListActionLogCommand command)
        {
            //Validation
            var errors = ValidationHelper.Validate(_container, command.ListActionLogInfo, command);
            if (errors.Any()) {
                throw new ValidationErrorException(errors);
            }

            command.UserActionLog = _iListActionLog.List(command);
        }
    }
}
