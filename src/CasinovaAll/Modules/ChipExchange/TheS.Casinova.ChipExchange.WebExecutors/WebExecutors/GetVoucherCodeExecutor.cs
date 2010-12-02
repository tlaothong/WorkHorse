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
    /// ดึงหมายเลขคูปอง
    /// </summary>
    public class GetVoucherCodeExecutor
     : SynchronousCommandExecutorBase<GetVoucherCodeCommand>
    {
        private IGetVoucherCode _iGetVoucherCode;

        public GetVoucherCodeExecutor(IChipsExchangeModuleDataQuery dqr)
        {
            _iGetVoucherCode = dqr;
        }

        protected override void ExecuteCommand(GetVoucherCodeCommand command)
        {
            //TODO: Generate trackingID

           command.VoucherCode = _iGetVoucherCode.Get(command);
        }
    }
}
