using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.PlayerAccount.Commands;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.PlayerAccount.DAL;
using PerfEx.Infrastructure;
using PerfEx.Infrastructure.Validation;
using TheS.Casinova.PlayerProfile.Models;

namespace TheS.Casinova.PlayerAccount.BackServices.BackExecutors
{
    public class ActivatePlayerAccountExecutor
        : SynchronousCommandExecutorBase<ActivatePlayerAccountCommand>
    {
        private IActivatePlayerAccount _iActivatePlayerAccount;
        private IDependencyContainer _container;

        public ActivatePlayerAccountExecutor(IDependencyContainer container, IPlayerAccountDataAccess dac)
        {
            _iActivatePlayerAccount = dac;
            _container = container;
        }

        protected override void ExecuteCommand(ActivatePlayerAccountCommand command)
        {
            ValidationErrorCollection errorValidations = new ValidationErrorCollection();

            UserProfile userProfile = new UserProfile { UserName = command.PlayerAccountInfo.UserName, Password = command.Password };
            ValidationHelper.Validate(_container, userProfile, command, errorValidations);
         
            ValidationHelper.Validate(_container, command.PlayerAccountInfo, command, errorValidations);

            if (errorValidations.Any()) {
                throw new ValidationErrorException(errorValidations);
            }

            //เปิดใช้งานบัญชี
            command.PlayerAccountInfo.Active = true;
            _iActivatePlayerAccount.ApplyAction(command.PlayerAccountInfo, command);
        }
    }
}
