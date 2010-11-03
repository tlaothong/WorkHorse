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
    /// แลกชิพตายด้วยเงิน
    /// </summary>
    public class MoneyToBonusChipsExecutor
    : SynchronousCommandExecutorBase<MoneyToBonusChipsCommand>
    {
        private IMoneyToBonusChips _iMoneyToBonusChips;

        public MoneyToBonusChipsExecutor(IChipsExchangeModuleBackService dac)
        {
            _iMoneyToBonusChips = dac;
        }

        protected override void ExecuteCommand(MoneyToBonusChipsCommand command)
        {
            //TODO: Credit card validation
            //TODO: Generate trackingID
            _iMoneyToBonusChips.MoneyToBonusChips(command);
        }
    }
}
