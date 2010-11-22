using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.MagicNine.Commands;
using TheS.Casinova.MagicNine.DAL;

namespace TheS.Casinova.MagicNine.WebExecutors
{
    /// <summary>
    /// ลิสต์ข้อมูลผลการลงเดิมพันของผู้เล่น
    /// </summary>
   public class ListBetLogExecutor
        : SynchronousCommandExecutorBase<ListBetLogCommand>
    {
       private IListBetLog _iListBetLog;

       public ListBetLogExecutor(IMagicNineGameDataQuery dqr) 
       {
           _iListBetLog = dqr;
       }

       protected override void ExecuteCommand(ListBetLogCommand command)
       {
           //TODO: Generate trackingID
          command.BetInformation = _iListBetLog.List(command);
       }
    }
}
