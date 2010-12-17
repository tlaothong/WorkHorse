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
       
        public override void Validate(UserProfile entity, ChangeEmailCommand command, ValidationErrorCollection errors)
        {
            //ตรวจสอบการกรอกข้อมูล email ว่ามีหรือไม่ 
            if (string.IsNullOrEmpty(entity.Email)) {
                errors.Add(new ValidationError {
                    Instance = entity,
                    ErrorMessage = "ค่า Email ไม่ถูกต้อง",
                });
            }

            //ตรวจสอบการกรอกข้อมูล new email ว่ามีหรือไม่ 
            if (string.IsNullOrEmpty(entity.NewEmail)) {
                errors.Add(new ValidationError {
                    Instance = entity,
                    ErrorMessage = "ค่า New Email ไม่ถูกต้อง",
                });
            }
        }
    }
}
