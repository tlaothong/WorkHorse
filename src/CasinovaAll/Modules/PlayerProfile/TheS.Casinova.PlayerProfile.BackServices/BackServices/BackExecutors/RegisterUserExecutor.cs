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
    public class RegisterUserExecutor
        : SynchronousCommandExecutorBase<RegisterUserCommand>
    {
        private IRegisterUser _iRegisterUser;

        public RegisterUserExecutor(IPlayerProfileDataAccess dac)
        {
            _iRegisterUser = dac;
        }

        protected override void ExecuteCommand(RegisterUserCommand command)
        {
            UserProfile userProfile = new UserProfile {
                UserName = command.UserName,
                Password = command.Password,
                Email = command.Email,
                CellPhone = command.CellPhone,
                Upline = command.Upline,
                Active = false,
            };

            _iRegisterUser.Create(userProfile, command);

            //TODO: ขาดการบันทึกชื่อผู้เล่นเป็น donwline ให้กับคนที่แนะนำ(MLN module)
        }
    }
}
