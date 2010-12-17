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
    /// ดึงข้อมูลจำนวนเงินรวมแต่ละโต๊ะที่ผู้เล่นเคยเล่นไว้
    /// </summary>
    public class ListGamePlayInfoExecutor
        : SynchronousCommandExecutorBase<ListGamePlayInfoCommand>
    {
        private IListGamePlayInfo _iListGamePlayInfo;
        private IDependencyContainer _container;

        public ListGamePlayInfoExecutor(ITwoWinsGameDataQuery dqr, IDependencyContainer container)
        {
            _iListGamePlayInfo = dqr;
            _container = container;
        }

        protected override void ExecuteCommand(ListGamePlayInfoCommand command)
        {
            //Validation
            var errors = ValidationHelper.Validate(_container, command.TotalBetInfo, command);
            if (errors.Any()) {
                throw new ValidationErrorException(errors);
            }
 
            command.GamePlayInfo = _iListGamePlayInfo.List(command);
        }
    }
}
