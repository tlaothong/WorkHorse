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
    /// แลกคูปองเป็นชิพตาย
    /// </summary>
    public class VoucherToBonusChipsExecutor
    : SynchronousCommandExecutorBase<VoucherToBonusChipsCommand>
    {
        private IVoucherToBonusChips _iVoucherToBonusChips;

        public VoucherToBonusChipsExecutor(IChipsExchangeModuleBackService dac)
        {
            _iVoucherToBonusChips = dac;
        }

        protected override void ExecuteCommand(VoucherToBonusChipsCommand command)
        {
            //TODO: Credit card validation
            //TODO: Generate trackingID
            _iVoucherToBonusChips.VoucherToBonusChips(command);
        }
    }
}
