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
    public class ChangeEmailExecutor
        : SynchronousCommandExecutorBase<ChangeEmailCommand>
    {
        private IChangeEmail _iChangeEmail;

        public ChangeEmailExecutor(IPlayerProfileDataAccess dac)
        {
            _iChangeEmail = dac;
        }

        protected override void ExecuteCommand(ChangeEmailCommand command)
        {
            UserProfile userProfile = new UserProfile {
                UserName = command.UserName,
                Email = command.NewEmail,
            };            

            _iChangeEmail.ApplyAction(userProfile, command);
        }
    }
}
