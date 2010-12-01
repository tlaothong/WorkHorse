using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.Validation;
using TheS.Casinova.PlayerProfile.Models;
using TheS.Casinova.PlayerProfile.Commands;
using TheS.Casinova.PlayerProfile.DAL;
using TheS.Casinova.PlayerProfile.Command;

namespace TheS.Casinova.PlayerProfile.Validators
{
    public class UserProfile_ChangeEmailValidators
         : ValidatorBase<UserProfile, ChangeEmailCommand>
    { 
        private IGetPlayerEmail _iGetPlayerEmail;
        private ICheckEmail _iCheckEmail;

        public UserProfile_ChangeEmailValidators( IPlayerProfileDataQuery dqr)
        {
            _iGetPlayerEmail = dqr;
            _iCheckEmail = dqr;
        }

        public override void Validate(UserProfile entity, ChangeEmailCommand command, ValidationErrorCollection errors)
        { 
             GetPlayerEmailCommand getEmail = new GetPlayerEmailCommand {
                    UserName = entity.UserName
            };

            CheckEmailCommand checkEmail = new CheckEmailCommand { 
                Email = command.UserProfile.NewEmail
            };

            getEmail.PlayerProfile = _iGetPlayerEmail.Get(getEmail);
            checkEmail.PlayerProfile = _iCheckEmail.Get(checkEmail);

            //ตรวจสอบ email ใหม่ว่ากรอกข้อมูลถูกต้องหรือไม่
            if (command.UserProfile.NewEmail == null) {
                errors.Add(new ValidationError {
                    Instance = command,
                    ErrorMessage = "กรอก new Email ไม่ถูกต้อง",
                });
            }

            //ตรวจสอบ password ว่าถูกต้องหรือ
            if (getEmail.PlayerProfile.Password != entity.Password) {
                errors.Add(new ValidationError {
                    Instance = entity,
                    ErrorMessage = "กรอก Password ไม่ถูกต้อง",
                });
            }

            //ตรวจสอบอีเมลเก่า ว่าตรงกับที่ server มีอยู่หรือไม่
            if (getEmail.PlayerProfile.Email != command.UserProfile.NewEmail) {
                errors.Add(new ValidationError {
                    Instance = entity,
                    ErrorMessage = "กรอก e-mail ไม่ตรงกับ e-mail เดิม",
                });
            }

            //ตรวจสอบอีเมลใหม่ว่าซ้ำหรือไม่
             if (checkEmail.PlayerProfile.Email == command.UserProfile.NewEmail) {
                 errors.Add(new ValidationError {
                     Instance = entity,
                     ErrorMessage = "e-mail นี้มีผู้ใช้งานแล้ว",
                 });
            }
        }
    }
}
