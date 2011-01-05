using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.ChipExchange.Commands;
using TheS.Casinova.ChipExchange.BackServices;
using TheS.Casinova.ChipExchange.DAL;
using TheS.Casinova.ChipExchange.Command;
using TheS.Casinova.PlayerAccount.Models;
using PerfEx.Infrastructure;
using PerfEx.Infrastructure.Validation;

namespace TheS.Casinova.ChipExchange.WebExecutors
{
    /// <summary>
    /// แลกชิพตายด้วยเงิน
    /// </summary>
    public class MoneyToBonusChipsExecutor
    : SynchronousCommandExecutorBase<MoneyToBonusChipsCommand>
    {
        private IMoneyToBonusChips _iMoneyToBonusChips;
        private IDependencyContainer _container;

        public MoneyToBonusChipsExecutor(IChipsExchangeModuleBackService dac, IDependencyContainer container)
        {
            _iMoneyToBonusChips = dac;
            _container = container;
        }

        protected override void ExecuteCommand(MoneyToBonusChipsCommand command)
        {
            //Validation
            var errors = ValidationHelper.Validate(_container, command.ExchangeInformation, command);
            if (errors.Any()) {
                throw new ValidationErrorException(errors);
            }
            _iMoneyToBonusChips.MoneyToBonusChips(command);
        }
    }
}
