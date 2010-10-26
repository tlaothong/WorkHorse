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
    /// ทำการดึงข้อมูลการลงเดิมพันแบบอัตโนมัติของผู้เล่น
    /// </summary>
   public class ListGamePlayAutoBetInfoExecutor
        : SynchronousCommandExecutorBase<ListGamePlayAutoBetInfoCommand>
    {
       private IListGamePlayAutoBetInfo _iListGamePlayAutoBetInfo;

       public ListGamePlayAutoBetInfoExecutor(IMagicNineGameDataQuery dqr) 
       {
           _iListGamePlayAutoBetInfo = dqr;
       }

       protected override void ExecuteCommand(ListGamePlayAutoBetInfoCommand command)
       {
           command.GamePlayAutoBet = _iListGamePlayAutoBetInfo.List(command);
       }
    }
}
