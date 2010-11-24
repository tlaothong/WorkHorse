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
    public class VeriflyUserExecutor
        : SynchronousCommandExecutorBase<VeriflyUserCommand>
    {
        private IVeriflyUser _iVeriflyUser;
        private IGetUserProfile _iGetUserProfile;

        public VeriflyUserExecutor(IPlayerProfileDataAccess dac, IPlayerProfileDataBackQuery dqr)
        {
            _iVeriflyUser = dac;
            _iGetUserProfile = dqr;
        }

        protected override void ExecuteCommand(VeriflyUserCommand command)
        {
            GetUserProfileCommand getUserProfileCmd = new GetUserProfileCommand { UserName = command.UserName };
            getUserProfileCmd.PlayerProfile = _iGetUserProfile.Get(getUserProfileCmd);

            //ตรวจสอบรหัสยืนยันว่าถูกต้องหรือไม่
            if (command.VeriflyCode == getUserProfileCmd.PlayerProfile.VeriflyCode) {
                //ระบบยืนยันการสมัคร
                _iVeriflyUser.ApplyAction(command.UserName, command);
            }
            else {
                Console.WriteLine("######################## รหัสยืนยันไม่ถูกต้อง #############################");
            }
        }
    }
}
