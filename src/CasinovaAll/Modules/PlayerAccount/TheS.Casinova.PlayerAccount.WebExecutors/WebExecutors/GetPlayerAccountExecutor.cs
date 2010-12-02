using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.PlayerAccount.Commands;
using TheS.Casinova.PlayerAccount.DAL;

namespace TheS.Casinova.PlayerAccount.WebExecutors
{
    /// <summary>
    /// ดึงข้อมูลบัญชีผู้เล่น
    /// </summary>
    public class GetPlayerAccountExecutor
        : SynchronousCommandExecutorBase<GetPlayerAccountCommand>
    {
        private IGetPlayerAccount _iGetPlayerAccount;

        public GetPlayerAccountExecutor(IPlayerAccountModuleDataQuery dqr) 
        {
            _iGetPlayerAccount = dqr;
        }

        protected override void ExecuteCommand(GetPlayerAccountCommand command)
        {
            command.PlayerAccountInfo = _iGetPlayerAccount.Get(command);
        }
    }
}
