using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.TwoWins.Commands;
using TheS.Casinova.TwoWins.DAL;
using PerfEx.Infrastructure;
using PerfEx.Infrastructure.Validation;

namespace TheS.Casinova.TwoWins.WebExecutors
{
    /// <summary>
    ///  ดึงข้อมูลสถิติการลงเดิมพันแบบทีละโต๊ะโดยละเอียด
    /// </summary>
    public class ListSingleActionLogExecutor
        : SynchronousCommandExecutorBase<ListSingleActionLogCommand>
    {
        private IListSingleActionLog _iListSingleActionLog;
        private IDependencyContainer _container;

        public ListSingleActionLogExecutor(ITwoWinsGameDataQuery dqr, IDependencyContainer container)
        {
            _iListSingleActionLog = dqr;
            _container = container;
        }

        protected override void ExecuteCommand(ListSingleActionLogCommand command)
        {
            //Validation
            var errors = ValidationHelper.Validate(_container, command.ActionLogInfo, command);
            if (errors.Any()) {
                throw new ValidationErrorException(errors);
            }

            command.ActionLogInformation = _iListSingleActionLog.List(command);
        }
    }
}
