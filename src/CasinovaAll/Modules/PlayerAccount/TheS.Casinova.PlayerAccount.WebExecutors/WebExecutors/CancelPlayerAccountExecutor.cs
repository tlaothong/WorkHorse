using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.PlayerAccount.Commands;
using TheS.Casinova.PlayerAccount.BackServices;

namespace TheS.Casinova.PlayerAccount.WebExecutors
{
    /// <summary>
    /// ยกเลิกบัญชีของผู้เล่น
    /// </summary>
     public class CancelPlayerAccountExecutor
    : SynchronousCommandExecutorBase<CancelPlayerAccountCommand>
    {
        private ICancelPlayerAccount _iCancelPlayerAccount;

        public CancelPlayerAccountExecutor(IPlayerAccountModuleBackService dac)
        {
            _iCancelPlayerAccount = dac;
        }

        protected override void ExecuteCommand(CancelPlayerAccountCommand command)
        {
            _iCancelPlayerAccount.CancelPlayerAccount(command);
        }
    }
}
