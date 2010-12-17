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
    /// สร้างบัญชีของผู้เล่น
    /// </summary>
    public class CreatePlayerAccountExecutor
    : SynchronousCommandExecutorBase<CreatePlayerAccountCommand>
    {
        private ICreatePlayerAccount _iCreatePlayerAccount;
        private IDependencyContainer _container;

        public CreatePlayerAccountExecutor(IPlayerAccountModuleBackService dac, IDependencyContainer container)
        {
            _iCreatePlayerAccount = dac;
            _container = container;
        }

        protected override void ExecuteCommand(CreatePlayerAccountCommand command)
        {
            //Validation
            var errors = ValidationHelper.Validate(_container, command.PlayerAccountInfo, command);
            if (errors.Any()) {
                throw new ValidationErrorException(errors);
            }
            _iCreatePlayerAccount.CreatePlayerAccount(command);
        }
    }
}
