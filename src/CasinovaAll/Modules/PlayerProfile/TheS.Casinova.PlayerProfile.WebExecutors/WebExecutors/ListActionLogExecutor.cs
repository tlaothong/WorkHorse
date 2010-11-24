using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.PlayerProfile.Commands;
using TheS.Casinova.PlayerProfile.DAL;


namespace TheS.Casinova.PlayerProfile.WebExecutors
{
    /// <summary>
    /// ดึงข้อมูล action log ของผู้เล่น
    /// </summary>
    public class ListActionLogExecutor
     : SynchronousCommandExecutorBase<ListActionLogCommand>       
    {
        private IListActionLog _iListActionLog;

        public ListActionLogExecutor(IPlayerProfileDataQuery dqr) 
       {
           _iListActionLog = dqr;
       }

        protected override void ExecuteCommand(ListActionLogCommand command)
       {
           command.UserActionLog = _iListActionLog.List(command);
       }
    }
}
