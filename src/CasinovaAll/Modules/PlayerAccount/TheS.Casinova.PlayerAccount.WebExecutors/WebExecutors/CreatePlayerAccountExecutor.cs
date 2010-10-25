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
    /// สร้างบัญชีของผู้เล่น
    /// </summary>
    public class CreatePlayerAccountExecutor
    : SynchronousCommandExecutorBase<CreatePlayerAccountCommand>
    {
        private ICreatePlayerAccount _iCreatePlayerAccount;

        public CreatePlayerAccountExecutor(IPlayerAccountModuleBackService dac)
        {
            _iCreatePlayerAccount = dac;
        }

        protected override void ExecuteCommand(CreatePlayerAccountCommand command)
        {
            _iCreatePlayerAccount.CreatePlayerAccount(command);
        }
    }
}
