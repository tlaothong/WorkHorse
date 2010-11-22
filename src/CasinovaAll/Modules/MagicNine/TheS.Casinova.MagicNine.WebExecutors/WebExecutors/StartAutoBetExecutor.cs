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
    /// เริ่มลงเดิมพันแบบอัตโนมัติ 
    /// </summary>
    public class StartAutoBetExecutor
        : SynchronousCommandExecutorBase<StartAutoBetCommand>
    {
        private IStartAutoBet _iStartAutoBet;

        public StartAutoBetExecutor(IMagicNineGameBackService dac) 
       {
           _iStartAutoBet = dac;
       }

        protected override void ExecuteCommand(StartAutoBetCommand command)
       {
            //TODO: Generate BetTrackingID
           _iStartAutoBet.StartAutoBet(command);
       }
    }
}
