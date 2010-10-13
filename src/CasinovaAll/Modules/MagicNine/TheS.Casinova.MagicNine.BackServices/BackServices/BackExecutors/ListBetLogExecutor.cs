using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.MagicNine.Commands;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.MagicNine.DAL;

namespace TheS.Casinova.MagicNine.BackServices.BackExecutors
{
    public class ListBetLogExecutor
        : SynchronousCommandExecutorBase<ListBetLogCommand>
    {
        private IListBetLog _iListBetLog;

        public ListBetLogExecutor(IMagicNineGameDataBackQuery dqr)
        {
            _iListBetLog = dqr;
        }

        protected override void ExecuteCommand(ListBetLogCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
