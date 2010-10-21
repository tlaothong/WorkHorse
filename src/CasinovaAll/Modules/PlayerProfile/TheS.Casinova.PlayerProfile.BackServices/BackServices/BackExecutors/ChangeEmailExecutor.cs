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
        private IGetUserProfile _iGetUserProfile;
        private IGetUserProfileByEmail _iGetUserProfileByEmail;

        public ChangeEmailExecutor(IPlayerProfileDataAccess dac, IPlayerProfileDataBackQuery dqr)
        {
            _iChangeEmail = dac;
            _iGetUserProfile = dqr;
            _iGetUserProfileByEmail = dqr;
        }

        protected override void ExecuteCommand(ChangeEmailCommand command)
        {
            GetUserProfileCommand getUserProfileCmd = new GetUserProfileCommand { 
                UserName = command.UserName 
            };

            //ดึงข้อมูลผู้เล่นจากชื่อ
            getUserProfileCmd.PlayerProfile = _iGetUserProfile.Get(getUserProfileCmd);

            //ตรวจสอบอีเมลล์เดิมว่าถูกต้องหรือไม่
            if (getUserProfileCmd.PlayerProfile.Email == command.OldEmail) {
                GetUserProfileByEmailCommand getUserProfileByEmailCmd = new GetUserProfileByEmailCommand {
                    Email = command.NewEmail,
                };

                //ดึงข้อมูลผู้เล่นจากอีเมลล์
                getUserProfileByEmailCmd.UserProfile = _iGetUserProfileByEmail.Get(getUserProfileByEmailCmd);

                //หากไม่พบข้อมูลผู้เล่น แสดงว่าอีเมลล์ที่ต้องการเปลี่ยนยังไม่ถูกใช้
                if (getUserProfileByEmailCmd.UserProfile == null) {
                    UserProfile userProfile = new UserProfile {
                        UserName = command.UserName,
                        Email = command.NewEmail,
                    };

                    _iChangeEmail.ApplyAction(userProfile, command);
                }
                else { //หากพบข้อมูลผู้เล่น แสดงว่าอีเมลล์ที่ต้องการเปลี่ยนถูกใช้แล้ว
                    Console.WriteLine("############### ไม่สามารถใช้ E-mail ที่ถูกใช้แล้วได้ ############");
                }
            }
            else {
                Console.WriteLine("################# อีเมลล์เดิมไม่ถูกต้อง #################");
            }
        }
    }
}
