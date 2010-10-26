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
        private IGetUserProfile _iGetUserProfile;

        public ChangePasswordExecutor(IPlayerProfileDataAccess dac, IPlayerProfileDataBackQuery dqr)
        {
            _iChangePassword = dac;
            _iGetUserProfile = dqr;
        }

        protected override void ExecuteCommand(ChangePasswordCommand command)
        {
            GetUserProfileCommand getUserProfileCmd = new GetUserProfileCommand { 
                UserName = command.UserName 
            };

            getUserProfileCmd.PlayerProfile = _iGetUserProfile.Get(getUserProfileCmd);

            //ตรวจสอบรหัสผ่านเดิมว่าถูกต้องหรือไม่
            if (getUserProfileCmd.PlayerProfile.Password == command.OldPassword) {
                UserProfile userProfile = new UserProfile {
                    UserName = command.UserName,
                    Password = command.NewPassword,
                };

                //บันทึกรหัสผ่านใหม่
                _iChangePassword.ApplyAction(userProfile, command);
            }
            else {
                Console.WriteLine("############### รหัสผ่านเดิม ไม่ถูกต้อง ######################");
            }
        }
    }
}
