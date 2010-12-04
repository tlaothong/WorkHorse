using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.PlayerProfile.Commands;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.PlayerProfile.DAL;
using TheS.Casinova.PlayerProfile.Models;
using PerfEx.Infrastructure;
using PerfEx.Infrastructure.Validation;

namespace TheS.Casinova.PlayerProfile.BackServices.BackExecutors
{
    public class ChangePasswordExecutor
        : SynchronousCommandExecutorBase<ChangePasswordCommand>
    {
        private IChangePassword _iChangePassword;
        private IDependencyContainer _container;

        public ChangePasswordExecutor(IDependencyContainer container, IPlayerProfileDataAccess dac)
        {
            _iChangePassword = dac;
            _container = container;
        }

        protected override void ExecuteCommand(ChangePasswordCommand command)
        {
            ValidationErrorCollection errorValidations = new ValidationErrorCollection();
            ValidationHelper.Validate(_container, command.UserProfile, command, errorValidations);
            if (errorValidations.Any()) {
                throw new ValidationErrorException(errorValidations);
            }

            //บันทึกรหัสผ่านใหม่
            command.UserProfile.Password = command.UserProfile.NewPassword;
            _iChangePassword.ApplyAction(command.UserProfile, command);
        }
    }
}
