using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.ChipExchange.Commands;
using TheS.Casinova.ChipExchange.BackServices;

namespace TheS.Casinova.ChipExchange.WebExecutors
{
    /// <summary>
    /// ซื้อคูปอง
    /// </summary>
   public class PayVoucherExecutor
   : SynchronousCommandExecutorBase<PayVoucherCommand>
    {
        private IPayVoucher _iPayVoucher;

        public PayVoucherExecutor(IChipsExchangeModuleBackService dac)
        {
            _iPayVoucher = dac;
        }

        protected override void ExecuteCommand(PayVoucherCommand command)
        {
            //TODO: Generate trackingID
            _iPayVoucher.PayVoucher(command);
        }
    }
}
