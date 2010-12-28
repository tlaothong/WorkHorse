using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.PlayerProfile.Commands;
using TheS.Casinova.PlayerProfile.BackServices;
using TheS.Casinova.PlayerProfile.DAL;
using TheS.Casinova.PlayerProfile.Command;
using TheS.Casinova.PlayerProfile.Models;
using PerfEx.Infrastructure;
using PerfEx.Infrastructure.Validation;
using TheS.Casinova.Common.Services;

namespace TheS.Casinova.PlayerProfile.WebExecutors
{
    /// <summary>
    /// เปลี่ยนอีเมลใหม่
    /// </summary>
    public class ChangeEmailExecutor
        : SynchronousCommandExecutorBase<ChangeEmailCommand>
    {             
        //private IChangeEmail _iChangeEmail;
        private IDependencyContainer _container;
        private IMembershipServices _membershipSvc;
       
        public ChangeEmailExecutor(IDependencyContainer container, IMembershipServices membershipSvc)
        {
            //_iChangeEmail = dac;
            _container = container;
            _membershipSvc = membershipSvc;
        }

        protected override void ExecuteCommand(ChangeEmailCommand command)
        {
            //Validation
            var errors = ValidationHelper.Validate(_container, command.UserProfile, command);
            if (errors.Any()) {
                throw new ValidationErrorException(errors);
            }

            _membershipSvc.ChangeEmail(command.UserProfile);
            //_iChangeEmail.ChangeEmail(command);
            
        }
     }
}

