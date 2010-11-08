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
    /// แลกชิพตายด้วยชิพเป็น
    /// </summary>
    public class ChipsToBonusChipsExecutor
    : SynchronousCommandExecutorBase<ChipsToBonusChipsCommand>
    {
        private IChipsToBonusChips _iChipsToBonusChips;

        public ChipsToBonusChipsExecutor(IChipsExchangeModuleBackService dac)
        {
            _iChipsToBonusChips = dac;
        }

        protected override void ExecuteCommand(ChipsToBonusChipsCommand command)
        {
            //TODO: Check bonus point
            //TODO: Check Chips amount
            //TODO: Generate trackingID
            _iChipsToBonusChips.ChipsToBonusChips(command);
        }
    }
}
