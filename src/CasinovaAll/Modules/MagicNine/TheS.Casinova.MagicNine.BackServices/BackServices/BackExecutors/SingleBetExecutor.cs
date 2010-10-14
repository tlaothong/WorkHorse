using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.MagicNine.Commands;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.MagicNine.DAL;

namespace TheS.Casinova.MagicNine.BackServices.BackExecutors
{
    public class SingleBetExecutor
        : SynchronousCommandExecutorBase<SingleBetCommand>
    {
        private ISingleBet _iSingleBet;

        public SingleBetExecutor(IMagicNineGameDataAccess dac)
        {
            _iSingleBet = dac;
        }

        protected override void ExecuteCommand(SingleBetCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
