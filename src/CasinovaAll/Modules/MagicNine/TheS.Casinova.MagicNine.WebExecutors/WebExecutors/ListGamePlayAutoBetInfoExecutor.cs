using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.MagicNine.Commands;
using TheS.Casinova.MagicNine.DAL;
using PerfEx.Infrastructure.Validation;
using PerfEx.Infrastructure;

namespace TheS.Casinova.MagicNine.WebExecutors
{
    /// <summary>
    /// ทำการดึงข้อมูลการลงเดิมพันแบบอัตโนมัติของผู้เล่น
    /// </summary>
   public class ListGamePlayAutoBetInfoExecutor
        : SynchronousCommandExecutorBase<ListGamePlayAutoBetInfoCommand>
    {
        private IListGamePlayAutoBetInfo _iListGamePlayAutoBetInfo;
        private IDependencyContainer _container;

        public ListGamePlayAutoBetInfoExecutor(IMagicNineGameDataQuery dqr, IDependencyContainer container)
        {
            _iListGamePlayAutoBetInfo = dqr;
            _container = container;
        }

        protected override void ExecuteCommand(ListGamePlayAutoBetInfoCommand command)
        {
            //Validation
            var errors = ValidationHelper.Validate(_container, command.GamePlayAutoBetInfo, command);
            if (errors.Any()) {
                throw new ValidationErrorException(errors);
            }

            //List game play auto bet information
            command.GamePlayAutoBetInformation = _iListGamePlayAutoBetInfo.List(command);
        }
    }
}
