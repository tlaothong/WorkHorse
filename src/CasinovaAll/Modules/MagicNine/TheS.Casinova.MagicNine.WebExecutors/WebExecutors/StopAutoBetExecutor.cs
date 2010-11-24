using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.MagicNine.Commands;
using TheS.Casinova.MagicNine.BackServices;


namespace TheS.Casinova.MagicNine.WebExecutors
{
    /// <summary>
    /// หยุดการลงเดิมพันแบบอัตโนมัติ
    /// </summary>
   public class StopAutoBetExecutor
   : SynchronousCommandExecutorBase<StopAutoBetCommand>
    {
       private IStopAutoBet _iStopAutoBet;

       public StopAutoBetExecutor(IMagicNineGameBackService dac) 
       {
           _iStopAutoBet = dac;
       }

       protected override void ExecuteCommand(StopAutoBetCommand command)
       {
          //TODO : Generate BetTrackingID
          _iStopAutoBet.StopAutoBet(command);
       }
    }
}
