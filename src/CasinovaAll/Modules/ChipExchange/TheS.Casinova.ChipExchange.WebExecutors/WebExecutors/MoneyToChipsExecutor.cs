using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.ChipExchange.Commands;
using TheS.Casinova.ChipExchange.BackServices;
using TheS.Casinova.ChipExchange.DAL;
using TheS.Casinova.PlayerAccount.Models;
using TheS.Casinova.ChipExchange.Command;
using TheS.Casinova.ChipExchange.Models;
using PerfEx.Infrastructure;
using PerfEx.Infrastructure.Validation;

namespace TheS.Casinova.ChipExchange.WebExecutors
{
    /// <summary>
    /// แลกชิพเป็นด้วยเงิน
    /// </summary>
    public class MoneyToChipsExecutor
    : SynchronousCommandExecutorBase<MoneyToChipsCommand>
    {
        private IMoneyToChips _iMoneyToChips;
        private IDependencyContainer _container;

        public MoneyToChipsExecutor(IChipsExchangeModuleBackService dac, IDependencyContainer container )
        {
            _iMoneyToChips = dac;
            _container = container;
        }

        protected override void ExecuteCommand(MoneyToChipsCommand command)
        {
            //Validation
            var errors = ValidationHelper.Validate(_container, command.ExchangeInformation, command);
            if (errors.Any()) {
                throw new ValidationErrorException(errors);
            }

            _iMoneyToChips.MoneyToChips(command);
        }
    }
}
