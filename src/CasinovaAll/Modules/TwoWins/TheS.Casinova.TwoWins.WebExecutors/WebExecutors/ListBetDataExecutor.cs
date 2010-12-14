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
    /// ดึงข้อมูลสถิติการลงเดิมพันในเกมทีละหลายโต๊ะแบบละเอียด
    /// </summary>
    public class ListBetDataExecutor
        : SynchronousCommandExecutorBase<ListBetDataCommand>
    {
        private IListBetData _iListBetData;
        private IDependencyContainer _container;

        public ListBetDataExecutor(ITwoWinsGameDataQuery dqr, IDependencyContainer container)
        {
            _iListBetData = dqr;
            _container = container;
        }

        protected override void ExecuteCommand(ListBetDataCommand command)
        {
            //Validation
            var errors = ValidationHelper.Validate(_container, command.ActionLogInfo,command);
            if (errors.Any()) {
                throw new ValidationErrorException(errors);
            }

            command.ActionLogInformation = _iListBetData.List(command);
        }
    }
}
