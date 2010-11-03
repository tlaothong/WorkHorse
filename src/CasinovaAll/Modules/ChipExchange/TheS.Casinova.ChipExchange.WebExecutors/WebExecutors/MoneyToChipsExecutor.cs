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
    /// แลกชิพเป็นด้วยเงิน
    /// </summary>
    public class MoneyToChipsExecutor
    : SynchronousCommandExecutorBase<MoneyToChipsCommand>
    {
        private IMoneyToChips _iMoneyToChips;

        public MoneyToChipsExecutor(IChipsExchangeModuleBackService dac)
        {
            _iMoneyToChips = dac;
        }

        protected override void ExecuteCommand(MoneyToChipsCommand command)
        {
            //TODO: Credit card validation
            //TODO: Generate trackingID
            _iMoneyToChips.MoneyToChips(command);
        }
    }
}
