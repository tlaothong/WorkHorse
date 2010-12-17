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
    /// ดึงข้อมูลการลงเดิมพันของผู้เล่นที่เคยเล่นไว้ในโต๊ะเกม
    /// </summary>
    public class ListBetLogInfoExecutor
        : SynchronousCommandExecutorBase<ListBetLogInfoCommand>
    {
        private IListBetLogInfo _iListBetLogInfo;
        private IDependencyContainer _container;

        public ListBetLogInfoExecutor(ITwoWinsGameDataQuery dqr, IDependencyContainer container)
        {
            _iListBetLogInfo = dqr;
            _container = container;
        }

        protected override void ExecuteCommand(ListBetLogInfoCommand command)
        {
            //Validation
            var errors = ValidationHelper.Validate(_container, command.BetInfo, command);
            if (errors.Any()) {
                throw new ValidationErrorException(errors);
            }

            command.BetInformation = _iListBetLogInfo.List(command);
        }
    }
}
