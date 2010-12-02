using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.PlayerAccount.Commands;
using TheS.Casinova.PlayerAccount.BackServices;
using PerfEx.Infrastructure;
using PerfEx.Infrastructure.Validation;

namespace TheS.Casinova.PlayerAccount.WebExecutors
{
    /// <summary>
    /// ยกเลิกบัญชีของผู้เล่น
    /// </summary>
     public class CancelPlayerAccountExecutor
    : SynchronousCommandExecutorBase<CancelPlayerAccountCommand>
    {
        private ICancelPlayerAccount _iCancelPlayerAccount;
        private IDependencyContainer _container;

        public CancelPlayerAccountExecutor(IPlayerAccountModuleBackService dac, IDependencyContainer container)
        {
            _iCancelPlayerAccount = dac;
            _container = container;
        }

        protected override void ExecuteCommand(CancelPlayerAccountCommand command)
        {
            //Validation
            var errors = ValidationHelper.Validate(_container, command.PlayerAccountInfo, command);
            if (errors.Any()) {
                throw new ValidationErrorException(errors);
            }

            _iCancelPlayerAccount.CancelPlayerAccount(command);
        }
    }
}
