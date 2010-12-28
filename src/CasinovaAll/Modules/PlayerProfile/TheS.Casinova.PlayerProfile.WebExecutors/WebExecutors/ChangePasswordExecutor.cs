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
    /// เปลี่ยนรหัสผ่านใหม่
    /// </summary>
    public class ChangePasswordExecutor
         : SynchronousCommandExecutorBase<ChangePasswordCommand>     
    {
         //private IChangePassword _iChangePassword;
         private IDependencyContainer _container;
         private IMembershipServices _membershipSvc;
         //private IGetPlayerPassword _iGetPlayerPassword;

         public ChangePasswordExecutor(IDependencyContainer container, IMembershipServices membershipSvc ) 
       {
             //_iChangePassword = dac;
             _container = container;
             _membershipSvc = membershipSvc;
       }

         protected override void ExecuteCommand(ChangePasswordCommand command)
       {
           //Validation
           var errors = ValidationHelper.Validate(_container, command.UserProfile, command);
           if (errors.Any()) {
               throw new ValidationErrorException(errors);
           }

           _membershipSvc.ChangePassword(command.UserProfile);
           //_iChangePassword.ChangePassWord(command);         
       }
    }
}
