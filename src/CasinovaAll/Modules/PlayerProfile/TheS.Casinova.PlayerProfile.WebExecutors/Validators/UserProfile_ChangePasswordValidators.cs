using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.Validation;
using TheS.Casinova.PlayerProfile.Models;
using TheS.Casinova.PlayerProfile.Commands;

namespace TheS.Casinova.PlayerProfile.Validators
{
    public class UserProfile_ChangePasswordValidators
         : ValidatorBase<UserProfile, ChangePasswordCommand>
    {
        public override void Validate(UserProfile entity, ChangePasswordCommand command, ValidationErrorCollection errors)
        {
            //ตรวจสอบการกรอกข้อมูล password ว่ามีหรือไม่ 
            if (string.IsNullOrEmpty(entity.Password)) {
                errors.Add(new ValidationError {
                    Instance = entity,
                    ErrorMessage = "ค่า Password ไม่ถูกต้อง",
                });
            }

            //ตรวจสอบการกรอกข้อมูล new password ว่ามีหรือไม่ 
            if (string.IsNullOrEmpty(entity.NewPassword)) {
                errors.Add(new ValidationError {
                    Instance = entity,
                    ErrorMessage = "ค่า New Password ไม่ถูกต้อง",
                });
            }
        }
    }
}
