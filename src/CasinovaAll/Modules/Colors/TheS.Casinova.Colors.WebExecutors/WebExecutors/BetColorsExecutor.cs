using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.TwoWins.Commands;
using TheS.Casinova.TwoWins.BackServices;
using TheS.Casinova.TwoWins.DAL;

namespace TheS.Casinova.TwoWins.WebExecutors
{
    /// <summary>
    /// ลงเดิมพัน
    /// </summary>
    public class BetColorsExecutor
        : SynchronousCommandExecutorBase<BetCommand>
    {
        private IBet _iBet;
        public BetColorsExecutor(IColorsGameBackService dac) 
        {
            _iBet = dac;
        }

        protected override void ExecuteCommand(BetCommand command) 
        {
            _iBet.PlayerBet(command);
        }
    }
}
