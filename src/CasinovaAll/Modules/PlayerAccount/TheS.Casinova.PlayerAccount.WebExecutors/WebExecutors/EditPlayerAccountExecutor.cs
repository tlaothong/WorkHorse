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
    /// แก้ไขข้อมูลบัญชีของผู้เล่น
    /// </summary>
    public class EditPlayerAccountExecutor
         : SynchronousCommandExecutorBase<EditPlayerAccountCommand>
    {
        private IEditPlayerAccount _iEditPlayerAccount;

        public EditPlayerAccountExecutor(IPlayerAccountModuleBackService dac)
        {
            _iEditPlayerAccount = dac;
        }

        protected override void ExecuteCommand(EditPlayerAccountCommand command)
        {
            _iEditPlayerAccount.EditPlayerAccount(command);
        }
    }
}
