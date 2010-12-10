using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.TwoWins.Commands;
using TheS.Casinova.TwoWins.DAL;
using PerfEx.Infrastructure;
using PerfEx.Infrastructure.Validation;
using TheS.Casinova.TwoWins.Models;

namespace TheS.Casinova.TwoWins.WebExecutors
{
    /// <summary>
    /// ดึงข้อมูลสถิติของเกมแบบเป็นช่วง โดยจะแสดงข้อมูลผลผู้ชนะ
    /// </summary>
    public class ListRangeActionLogExecutor
    : SynchronousCommandExecutorBase<ListRangeActionLogCommand>
    {
        private IListRangeActionLog _iListRangeActionLog;
        private IGetRoundWinnerAmount _iGetRoundWinnerAmount;
        private IDependencyContainer _container;

        public ListRangeActionLogExecutor(ITwoWinsGameDataQuery dqr, IDependencyContainer container)
        {
            _iListRangeActionLog = dqr;
            _iGetRoundWinnerAmount = dqr;
            _container = container;
        }

        protected override void ExecuteCommand(ListRangeActionLogCommand command)
        {
            //Validation
            var errors = ValidationHelper.Validate(_container, command.RoundWinnerInfo, command);
            if (errors.Any()) {
                throw new ValidationErrorException(errors);
            }

            //IEnumerable<RoundWinnerInformation> listAmount;

            //foreach (var i in command.RoundWinnerInfo) {
            //    listAmount = _iGetRoundWinnerAmount.Get(i);
            //}

            command.RangeActionLog = _iListRangeActionLog.List(command);
        }
    }
}
