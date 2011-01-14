using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.DevilSix.Commands;
using TheS.Casinova.DevilSix.DAL;

namespace TheS.Casinova.DevilSix.WebExecutors
{
    /// <summary>
    /// ดึงข้อมูลโต๊ะเกมที่ active
    /// </summary>
    public class ListActiveGameRoundInfoExecutor
        : SynchronousCommandExecutorBase<ListActiveGameRoundInfoCommand>
    {
       private IListActiveGameRoundInfo _iListActiveGameRound;

       public ListActiveGameRoundInfoExecutor(IDevilSixGameDataQuery dqr) 
       {
           _iListActiveGameRound = dqr;
       }

       protected override void ExecuteCommand(ListActiveGameRoundInfoCommand command)
       {
           command.Active = true;
           command.ActiveGameRoundInfo = _iListActiveGameRound.List(command);
       }
    }
}
