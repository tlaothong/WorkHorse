using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.PlayerAccount.Commands;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.PlayerAccount.DAL;

namespace TheS.Casinova.PlayerAccount.BackServices.BackExecutors
{
    public class CancelPlayerAccountExecutor
        : SynchronousCommandExecutorBase<CancelPlayerAccountCommand>
    {
        private ICancelPlayerAccount _iCancelPlayerAccount;

        public CancelPlayerAccountExecutor(IPlayerAccountDataAccess dac)
        {
            _iCancelPlayerAccount = dac;
        }

        protected override void ExecuteCommand(CancelPlayerAccountCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
