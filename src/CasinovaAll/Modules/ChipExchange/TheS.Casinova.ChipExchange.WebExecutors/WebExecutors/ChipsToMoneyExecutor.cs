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
    /// เปลี่ยนชิพเป็นเป็นเงิน
    /// </summary>
    public class ChipsToMoneyExecutor
    : SynchronousCommandExecutorBase<ChipsToMoneyCommand>
    {
        private IChipsToMoney _iChipsToMoney;
        private IDependencyContainer _container; 

        public ChipsToMoneyExecutor( IChipsExchangeModuleBackService dac, IDependencyContainer container)
        {
            _iChipsToMoney = dac;
            _container = container;
        }

        protected override void ExecuteCommand(ChipsToMoneyCommand command)
        {
            //Validation
            var errors = ValidationHelper.Validate(_container, command.ChequeInfo, command);
            if (errors.Any()) {
                throw new ValidationErrorException(errors);
            }
            _iChipsToMoney.ChipsToMoney(command);
        }
    }
}
