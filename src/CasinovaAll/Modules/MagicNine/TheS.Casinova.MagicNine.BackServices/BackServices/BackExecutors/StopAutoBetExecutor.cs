using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.MagicNine.Commands;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.MagicNine.DAL;

namespace TheS.Casinova.MagicNine.BackServices.BackExecutors
{
    public class StopAutoBetExecutor
        : SynchronousCommandExecutorBase<StopAutoBetCommand>
    {
        private IAutoBetEngine _iAutoBetEngine;

        public StopAutoBetExecutor(IAutoBetEngine svc)
        {
            _iAutoBetEngine = svc;
        }

        protected override void ExecuteCommand(StopAutoBetCommand command)
        {
            _iAutoBetEngine.StopAutoBet(command);
        }
    }
}
