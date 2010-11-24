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
        private IGetUserProfile _iGetUserProfile;

        public RegisterUserExecutor(IPlayerProfileDataAccess dac, IPlayerProfileDataBackQuery dqr)
        {
            _iRegisterUser = dac;
            _iGetUserProfile = dqr;
        }

        protected override void ExecuteCommand(RegisterUserCommand command)
        {
            GetUserProfileCommand getUserProfileCmd = new GetUserProfileCommand {
                UserName = command.Upline
            };

            UserProfile userProfile = new UserProfile {
                UserName = command.UserName,
                Password = command.Password,
                Email = command.Email,
                CellPhone = command.CellPhone,
                Upline = command.Upline,
                VeriflyCode = command.VeriflyCode,
                Active = false,
            };

            if (command.Upline != null) { //สมัครสมาชิกโดยมีผู้แนะนำ
                getUserProfileCmd.PlayerProfile = _iGetUserProfile.Get(getUserProfileCmd);

                if (getUserProfileCmd.PlayerProfile != null) {  //ตรวจสอบ upline ที่ระบุมาว่ามีอยู่จริง
                    //บันทึกข้อมูลการสมัคร
                    _iRegisterUser.Create(userProfile, command);

                    //TODO: ขาดการบันทึกชื่อผู้เล่นเป็น donwline ให้กับคนที่แนะนำ(MLN module)
                }
                else {
                    Console.WriteLine("################### ไม่มีชื่อ Upline ในระบบ ##################");
                }
            }
            else { //สมัครสมาชิกโดนไม่มีผู้แนะนำ
                //บันทึกข้อมูลการสมัคร
                _iRegisterUser.Create(userProfile, command);
            }
        }
    }
}
