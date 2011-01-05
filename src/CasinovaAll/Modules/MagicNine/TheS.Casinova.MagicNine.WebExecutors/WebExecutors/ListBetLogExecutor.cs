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
    /// ลิสต์ข้อมูลผลการลงเดิมพันของผู้เล่น
    /// </summary>
   public class ListBetLogExecutor
        : SynchronousCommandExecutorBase<ListBetLogCommand>
    {
       private IListBetLog _iListBetLog;
       private IDependencyContainer _container;

       public ListBetLogExecutor(IMagicNineGameDataQuery dqr, IDependencyContainer container) 
       {
           _iListBetLog = dqr;
           _container = container;
       }

       protected override void ExecuteCommand(ListBetLogCommand command)
       {
           //Validation
           var errors = ValidationHelper.Validate(_container, command.BetInfo, command);
           if (errors.Any()) {
               throw new ValidationErrorException(errors);
           }
          command.BetInformation = _iListBetLog.List(command);
       }
    }
}
