using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.Colors.Commands;
using TheS.Casinova.Colors.BackServices;
using TheS.Casinova.Colors.DAL;

namespace TheS.Casinova.Colors.WebExecutors
{
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
