using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.TwoWins.DAL;
using TheS.Casinova.TwoWins.Models;
using TheS.Casinova.TwoWins.Commands;
using PerfEx.Infrastructure.CommandPattern;

namespace TheS.Casinova.TwoWins.WebExecutors
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
             command.FromTime = DateTime.Now;           //เริ่มต้นที่เวลาปัจจุบัน      
             command.ActiveRounds = _iListActiveRound.List(command);    
         }
    }
}
