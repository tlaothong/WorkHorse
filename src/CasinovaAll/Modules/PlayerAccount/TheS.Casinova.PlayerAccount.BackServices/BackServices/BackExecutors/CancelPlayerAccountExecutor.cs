using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.PlayerAccount.Commands;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.PlayerAccount.DAL;
using TheS.Casinova.PlayerAccount.Models;
using PerfEx.Infrastructure;
using PerfEx.Infrastructure.Validation;

namespace TheS.Casinova.PlayerAccount.BackServices.BackExecutors
{
    public class CancelPlayerAccountExecutor
        : SynchronousCommandExecutorBase<CancelPlayerAccountCommand>
    {
        private ICancelPlayerAccount _iCancelPlayerAccount;
        private IDependencyContainer _container;

        public CancelPlayerAccountExecutor(IDependencyContainer container, IPlayerAccountDataAccess dac)
        {
            _iCancelPlayerAccount = dac;
            _container = container;
        }

        protected override void ExecuteCommand(CancelPlayerAccountCommand command)
        {
            ValidationErrorCollection errorValidations = new ValidationErrorCollection();
            ValidationHelper.Validate(_container, command.PlayerAccountInfo, command, errorValidations);
            if (errorValidations.Any()) {
                throw new ValidationErrorException(errorValidations);
            }

            //ยกเลิกบัญชี
            command.PlayerAccountInfo.Active = false;
            _iCancelPlayerAccount.ApplyAction(command.PlayerAccountInfo, command);
        }
    }
}
