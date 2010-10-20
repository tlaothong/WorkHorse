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
    public class ListActiveGameRoundInfoExecutor
        : SynchronousCommandExecutorBase<ListActiveGameRoundInfoCommand>
    {
       private IListActiveGameRoundInfo _iListActiveGameRound;

       public ListActiveGameRoundInfoExecutor(IMagicNineGameDataQuery dqr) 
       {
           _iListActiveGameRound = dqr;
       }

       protected override void ExecuteCommand(ListActiveGameRoundInfoCommand command)
       {
           command.Active = true;
           command.GameRoundInfos = _iListActiveGameRound.List(command);
       }
    }
}
