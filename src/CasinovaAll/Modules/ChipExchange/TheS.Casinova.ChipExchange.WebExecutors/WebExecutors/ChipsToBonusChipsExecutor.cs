using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.ChipExchange.Commands;
using TheS.Casinova.ChipExchange.BackServices;
using PerfEx.Infrastructure.Validation;
using PerfEx.Infrastructure;

namespace TheS.Casinova.ChipExchange.WebExecutors
{
    /// <summary>
    /// แลกชิพตายด้วยชิพเป็น
    /// </summary>
    public class ChipsToBonusChipsExecutor
    : SynchronousCommandExecutorBase<ChipsToBonusChipsCommand>
    {
        private IChipsToBonusChips _iChipsToBonusChips;
        private IDependencyContainer _container;

        public ChipsToBonusChipsExecutor(IChipsExchangeModuleBackService dac, IDependencyContainer container)
        {
            _iChipsToBonusChips = dac;
            _container = container;
        }

        protected override void ExecuteCommand(ChipsToBonusChipsCommand command)
        {
            //TODO: Check bonus point
            //TODO: Check Chips amount
            //Validation
            var errors = ValidationHelper.Validate(_container, command.ExchangeInfo, command);
            if (errors.Any()) {
                throw new ValidationErrorException(errors);
            }
            _iChipsToBonusChips.ChipsToBonusChips(command);
        }
    }
}
