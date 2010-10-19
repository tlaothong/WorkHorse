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
    /// ดึงข้อมูลโต๊ะเกมที่ active
    /// </summary>
    public class ListActiveGameRoundExecutor
        : SynchronousCommandExecutorBase<ListActiveGameRoundCommand>
    {
       private IListActiveGameRound _iListActiveGameRound;

       public ListActiveGameRoundExecutor(IMagicNineGameDataQuery dqr) 
       {
           _iListActiveGameRound = dqr;
       }

       protected override void ExecuteCommand(ListActiveGameRoundCommand command)
       {
           command.Active = true;
           command.GameRoundInfos = _iListActiveGameRound.List(command);
       }
    }
}
