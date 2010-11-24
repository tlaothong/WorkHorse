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
    /// ลิสต์ข้อมูลบัญชีของผู้เล่น
    /// </summary>
    public class ListPlayerAccountExecutor 
     : SynchronousCommandExecutorBase<ListPlayerAccountCommand>       
    {
        private IListPlayerAccount _iListPlayerAccount;

        public ListPlayerAccountExecutor(IPlayerAccountModuleDataQuery dqr) 
        {
            _iListPlayerAccount = dqr;
        }

        protected override void ExecuteCommand(ListPlayerAccountCommand command)
        {
            command.PlayerAccountInfo = _iListPlayerAccount.List(command);
        }
    }
}
