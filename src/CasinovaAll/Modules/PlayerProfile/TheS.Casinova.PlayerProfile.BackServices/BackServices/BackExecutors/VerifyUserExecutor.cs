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
    public class VerifyUserExecutor
        : SynchronousCommandExecutorBase<VerifyUserCommand>
    {
        private IVeriflyUser _iVeriflyUser;
        private IDependencyContainer _container;

        public VerifyUserExecutor(IDependencyContainer container, IPlayerProfileDataAccess dac)
        {
            _iVeriflyUser = dac;
            _container = container;
        }

        protected override void ExecuteCommand(VerifyUserCommand command)
        {
            ValidationErrorCollection errorValidations = new ValidationErrorCollection();

            //ตรวจสอบรหัสยืนยันว่าถูกต้องหรือไม่
            ValidationHelper.Validate(_container, command.UserProfile, command, errorValidations);
            if (errorValidations.Any()) {
                throw new ValidationErrorException(errorValidations);
            }

            //ระบบยืนยันการสมัคร
            command.UserProfile.Active = true;
            _iVeriflyUser.ApplyAction(command.UserProfile, command);
        }
    }
}
