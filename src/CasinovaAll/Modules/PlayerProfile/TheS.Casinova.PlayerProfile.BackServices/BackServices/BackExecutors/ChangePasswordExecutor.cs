using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.PlayerProfile.Commands;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.PlayerProfile.DAL;
using TheS.Casinova.PlayerProfile.Models;

namespace TheS.Casinova.PlayerProfile.BackServices.BackExecutors
{
    public class ChangePasswordExecutor
        : SynchronousCommandExecutorBase<ChangePasswordCommand>
    {
        private IChangePassword _iChangePassword;

        public ChangePasswordExecutor(IPlayerProfileDataAccess dac)
        {
            _iChangePassword = dac;
        }

        protected override void ExecuteCommand(ChangePasswordCommand command)
        {
            UserProfile userProfile = new UserProfile {
                UserName = command.UserName,
                Password = command.NewPassword,
            };

            _iChangePassword.ApplyAction(userProfile, command);
        }
    }
}
