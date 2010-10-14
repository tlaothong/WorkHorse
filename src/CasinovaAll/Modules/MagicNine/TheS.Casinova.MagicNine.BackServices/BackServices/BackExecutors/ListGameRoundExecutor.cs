using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.MagicNine.Commands;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.MagicNine.DAL;

namespace TheS.Casinova.MagicNine.BackServices.BackExecutors
{
    public class ListGameRoundExecutor
        : SynchronousCommandExecutorBase<ListGameRoundCommand>
    {
        private IListGameRoundInfo _iListGameRoundInfo;

        public ListGameRoundExecutor(IMagicNineGameDataBackQuery dqr)
        {
            _iListGameRoundInfo = dqr;
        }

        protected override void ExecuteCommand(ListGameRoundCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
