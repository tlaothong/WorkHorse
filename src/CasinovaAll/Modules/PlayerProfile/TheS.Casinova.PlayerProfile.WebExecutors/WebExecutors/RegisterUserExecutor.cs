using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.PlayerProfile.Commands;
using TheS.Casinova.PlayerProfile.BackServices;
using TheS.Casinova.PlayerProfile.DAL;
using TheS.Casinova.PlayerProfile.Command;
using PerfEx.Infrastructure;
using PerfEx.Infrastructure.Validation;

namespace TheS.Casinova.PlayerProfile.WebExecutors
{
    /// <summary>
    /// register ข้อมูลการสมัครสมาชิกของผู้เล่น
    /// </summary>
    public class RegisterUserExecutor
        : SynchronousCommandExecutorBase<RegisterUserCommand>       
    {
        private IRegisterUser _iRegisterUser;
        private IDependencyContainer _container;

        public RegisterUserExecutor(IPlayerProfileBackService dac, IDependencyContainer container)
        {
            _iRegisterUser = dac;
            _container = container;
        }

        protected override void ExecuteCommand(RegisterUserCommand command)
        {
            //Validation
            var errors = ValidationHelper.Validate(_container, command.RegisterUserInfo, command);
            if (errors.Any()) {
                throw new ValidationErrorException(errors);
            }

            //TODO: Generate TrackingID
            _iRegisterUser.RegisterUser(command);

        }
    }
}
