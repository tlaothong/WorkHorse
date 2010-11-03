using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.ChipExchange.Commands;
using TheS.Casinova.ChipExchange.DAL;

namespace TheS.Casinova.ChipExchange.WebExecutors
{
    /// <summary>
    /// ดึงข้อมูลชิพเป็น-ชิพตายของผู้เล่น
    /// </summary>
    public class GetPlayerBalanceExecutor
     : SynchronousCommandExecutorBase<GetPlayerBalanceCommand>
    {
        private IGetPlayerBalance _iGetPlayerBalance ;

        public GetPlayerBalanceExecutor(IChipsExchangeModuleDataQuery dqr)
        {
            _iGetPlayerBalance = dqr;
        }

        protected override void ExecuteCommand(GetPlayerBalanceCommand command)
        {
            _iGetPlayerBalance.Get(command);
        }
    }
}
