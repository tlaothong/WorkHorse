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
    /// เปลี่ยนอีเมลใหม่
    /// </summary>
    public class ChangeEmailExecutor
        : SynchronousCommandExecutorBase<ChangeEmailCommand>
    {             
        private IChangeEmail _iChangeEmail;
        private IGetPlayerEmail _iGetPlayerEmail;
        private ICheckEmail _iCheckEmail;
        
        public ChangeEmailExecutor(IPlayerProfileBackService dac, IPlayerProfileDataQuery dqr)
        {
            _iChangeEmail = dac;
            _iGetPlayerEmail = dqr;
            _iCheckEmail = dqr;
        }

        protected override void ExecuteCommand(ChangeEmailCommand command)
        {
            GetPlayerEmailCommand getEmail = new GetPlayerEmailCommand { 
                UserName = command.UserName
            };

            CheckEmailCommand checkEmail = new CheckEmailCommand { 
                Email = command.NewEmail
            };

            getEmail.PlayerProfile = _iGetPlayerEmail.Get(getEmail);
            checkEmail.PlayerProfile = _iCheckEmail.Get(checkEmail);

            //ตรวจสอบอีเมลเก่า ว่าตรงกับที่ server มีอยู่หรือไม่
            if (getEmail.PlayerProfile.Email != command.OldEmail) {
                Console.WriteLine("กรอก e-mail ไม่ตรงกับ e-mail เดิม");
            }
            //ตรวจสอบอีเมลใหม่ว่าซ้ำหรือไม่
            else if (checkEmail.PlayerProfile.Email == command.NewEmail) {
                Console.WriteLine("e-mail นี้มีผู้ใช้งานแล้ว");
            }
            else {
                _iChangeEmail.ChangeEmail(command);
            }
        }
     }
}

