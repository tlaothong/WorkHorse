using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.Colors.DAL;
using TheS.Casinova.Colors.Models;
using TheS.Casinova.Colors.Commands;
using PerfEx.Infrastructure.CommandPattern;

namespace TheS.Casinova.Colors.WebExecutors
{
    /// <summary>
    /// list ข้อมูลโต๊ะเกมที่ active
    /// </summary>
    public class ListActiveGameRoundsExecutor
        : SynchronousCommandExecutorBase<ListActiveGameRoundCommand>
    {
         private IListActiveGameRounds _iListActiveRound;

         public ListActiveGameRoundsExecutor(IColorsGameDataQuery dqr)
        {
            _iListActiveRound = dqr;
        }

         protected override void ExecuteCommand(ListActiveGameRoundCommand command)
         {
             command.FromTime = DateTime.Now;
             command.ActiveRounds = _iListActiveRound.List(command);
         }
    }
}
