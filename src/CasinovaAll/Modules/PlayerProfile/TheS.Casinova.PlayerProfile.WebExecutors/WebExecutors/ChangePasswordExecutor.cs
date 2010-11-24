using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.PlayerProfile.Commands;
using TheS.Casinova.PlayerProfile.BackServices;
using TheS.Casinova.PlayerProfile.DAL;
using TheS.Casinova.PlayerProfile.Command;

namespace TheS.Casinova.PlayerProfile.WebExecutors
{
    /// <summary>
    /// เปลี่ยนรหัสผ่านใหม่
    /// </summary>
    public class ChangePasswordExecutor
         : SynchronousCommandExecutorBase<ChangePasswordCommand>     
    {
         private IChangePassword _iChangePassword;
         private IGetPlayerPassword _iGetPlayerPassword;

         public ChangePasswordExecutor(IPlayerProfileBackService dac, IPlayerProfileDataQuery dqr) 
       {
             _iChangePassword = dac;
             _iGetPlayerPassword = dqr;
       }

         protected override void ExecuteCommand(ChangePasswordCommand command)
       {
           GetPlayerPasswordCommand getPassword = new GetPlayerPasswordCommand { 
               UserName = command.UserName
           };

           getPassword.PlayerProfile = _iGetPlayerPassword.Get(getPassword);

           //ตรวจสอบรหัสผ่านเก่า ว่าตรงกับที่ server มีอยู่หรือไม่
           if (getPassword.PlayerProfile.Password != command.OldPassword) {
               Console.WriteLine("กรอก Password ไม่ตรงกับ Password เดิม");
           }
           else {
               _iChangePassword.ChangePassWord(command);
           }          
       }
    }
}
