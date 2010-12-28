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
using TheS.Casinova.Common.Services;

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
        private IGenerateTrackingID _svc;
        private IMembershipServices _membershipSvc;

        public RegisterUserExecutor(IPlayerProfileBackService dac, IDependencyContainer container, IGenerateTrackingID svc, IMembershipServices membershipSvc)
        {
            _iRegisterUser = dac;
            _container = container;
            _svc = svc;
            _membershipSvc = membershipSvc;
        }

        protected override void ExecuteCommand(RegisterUserCommand command)
        {
            //Validation
            var errors = ValidationHelper.Validate(_container, command.RegisterUserInfo, command);
            if (errors.Any()) {
                throw new ValidationErrorException(errors);
            }

            _membershipSvc.RegisterUser(command.RegisterUserInfo);
            command.RegisterUserInfo.TrackingID = _svc.GenerateTrackingID();
            _iRegisterUser.RegisterUser(command);

        }
    }
}
