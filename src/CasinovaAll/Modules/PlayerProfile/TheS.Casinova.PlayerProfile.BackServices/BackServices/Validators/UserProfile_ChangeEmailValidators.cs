using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.PlayerProfile.Models;
using TheS.Casinova.PlayerProfile.Commands;
using PerfEx.Infrastructure.Validation;
using TheS.Casinova.PlayerProfile.DAL;

namespace TheS.Casinova.PlayerProfile.BackServices.Validators
{
    public class UserProfile_ChangeEmailValidators
        : ValidatorBase<UserProfile, ChangeEmailCommand>
    {
        private IGetUserProfile _iGetUserProfile;
        private IGetUserProfileByEmail _iGetUserProfileByEmail;

        public UserProfile_ChangeEmailValidators(IPlayerProfileDataBackQuery dqr)
        {
            _iGetUserProfile = dqr;
            _iGetUserProfileByEmail = dqr;
        }

        public override void Validate(UserProfile entity, ChangeEmailCommand command, ValidationErrorCollection errors)
        {
            GetUserProfileCommand getUserProfileCmd = new GetUserProfileCommand {
                UserName = entity.UserName
            };
            
            //ดึงข้อมูลผู้เล่นจากชื่อ
            var userProfile = _iGetUserProfile.Get(getUserProfileCmd);
      
            GetUserProfileByEmailCommand getUserProfileByEmailCmd = new GetUserProfileByEmailCommand {
                Email = command.NewEmail,
            };

            //ดึงข้อมูลผู้เล่นจากอีเมลล์
            getUserProfileByEmailCmd.UserProfile = _iGetUserProfileByEmail.Get(getUserProfileByEmailCmd);

            //ตรวจสอบรหัสผ่าน
            if (entity.Password != userProfile.Password) {
                errors.Add(new ValidationError {
                    Instance = entity,
                    ErrorMessage = "รหัสผ่านไม่ถูกต้อง",
                });
            }

            //ตรวจสอบอีเมลล์เดิมว่าถูกต้องหรือไม่
            if (command.UserProfile.Email != userProfile.Email) {
                errors.Add(new ValidationError {
                    Instance = entity,
                    ErrorMessage = "E-mail เดิมไม่ถูกต้อง",
                });
            }

            //ตรวจสอบอีเมลล์ใหม่ว่ายังไม่เคยถูกใช้
            if (getUserProfileByEmailCmd.UserProfile != null) {
                errors.Add(new ValidationError {
                    Instance = entity,
                    ErrorMessage = "E-mail นี้ถูกใช้แล้ว",
                });
            }
        }
    }
}
