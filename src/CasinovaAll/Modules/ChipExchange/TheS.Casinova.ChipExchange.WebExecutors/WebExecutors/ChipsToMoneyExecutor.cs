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
    /// เปลี่ยนชิพเป็นเป็นเงิน
    /// </summary>
    public class ChipsToMoneyExecutor
    : SynchronousCommandExecutorBase<ChipsToMoneyCommand>
    {
        private IChipsToMoney _iChipsToMoney;

        public ChipsToMoneyExecutor(IChipsExchangeModuleBackService dac)
        {
            _iChipsToMoney = dac;
        }

        protected override void ExecuteCommand(ChipsToMoneyCommand command)
        {
            //TODO: Generate trackingID
            _iChipsToMoney.ChipsToMoney(command);
        }
    }
}
