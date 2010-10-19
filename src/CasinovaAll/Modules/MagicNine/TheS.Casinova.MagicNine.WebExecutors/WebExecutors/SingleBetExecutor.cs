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
    /// ลงเดิมพันแบบปกติ
    /// </summary>
    public  class SingleBetExecutor
         : SynchronousCommandExecutorBase<SingleBetCommand>
    {
        private ISingleBet _iSingleBet;

        public SingleBetExecutor(IMagicNineGameBackService dac)
        {
            _iSingleBet = dac;
        }

        protected override void ExecuteCommand(SingleBetCommand command) 
        {
            _iSingleBet.SingleBet(command);
        }
    }
}
