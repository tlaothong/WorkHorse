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
    /// register ข้อมูลการสมัครสมาชิกของผู้เล่น
    /// </summary>
    public class RegisterUserExecutor
        : SynchronousCommandExecutorBase<RegisterUserCommand>       
    {
        private IRegisterUser _iRegisterUser;
        private ICheckUserName _iCheckUserName;
        private ICheckEmail _iCheckEmail;
        private ICheckUpline _iCheckUpline;

        public RegisterUserExecutor(IPlayerProfileBackService dac, IPlayerProfileDataQuery dqr) 
       {
           _iRegisterUser = dac;
           _iCheckUserName = dqr;
           _iCheckEmail = dqr;
           _iCheckUpline = dqr;
           
       }

        protected override void ExecuteCommand(RegisterUserCommand command)
       {            
           CheckUserNameCommand checkUserName = new CheckUserNameCommand { 
               UserName = command.UserName
           };
           CheckEmailCommand checkEmail = new CheckEmailCommand {
               Email = command.Email
           };
           CheckUplineCommand checkUpline = new CheckUplineCommand {
               Upline = command.Upline
           };

           checkUserName.PlayerProfile = _iCheckUserName.Get(checkUserName);
           checkEmail.PlayerProfile = _iCheckEmail.Get(checkEmail);
           checkUpline.PlayerProfile = _iCheckUpline.Get(checkUpline);

           //ตรวจสอบ username ว่าซ้ำหรือไม่
           if (checkUserName.PlayerProfile.UserName == command.UserName) {
               Console.WriteLine("UserName นี้มีผู้ใช้งานแล้ว");
           }
           //ตรวจสอบ email ว่าซ้ำหรือไม่
           else if (checkEmail.PlayerProfile.Email == command.Email) {
               Console.WriteLine("Email นี้มีผู้ใช้งานแล้ว");
           }
           //ตรวจสอบ upline ว่ามีข้อมูลหรือไม่
           else if (checkUpline.PlayerProfile.Upline != command.UserName) {
               Console.WriteLine("กรอกข้อมูล Upline ไม่ถูกต้อง");
           }
           else {
               //TODO: Generate TrackingID
               _iRegisterUser.RegisterUser(command);
           }
       }
    }
}
