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
    /// เปลี่ยนรหัสผ่านใหม่
    /// </summary>
    public class ChangePasswordExecutor
         : SynchronousCommandExecutorBase<ChangePasswordCommand>     
    {
         private IChangePassword _iChangePassword;
         private IDependencyContainer _container;
         //private IGetPlayerPassword _iGetPlayerPassword;

         public ChangePasswordExecutor(IPlayerProfileBackService dac, IDependencyContainer container ) 
       {
             _iChangePassword = dac;
             _container = container;
       }

         protected override void ExecuteCommand(ChangePasswordCommand command)
       {
           //Validation
           var errors = ValidationHelper.Validate(_container, command.UserProfile, command);
           if (errors.Any()) {
               throw new ValidationErrorException(errors);
           }

           _iChangePassword.ChangePassWord(command);         
       }
    }
}
