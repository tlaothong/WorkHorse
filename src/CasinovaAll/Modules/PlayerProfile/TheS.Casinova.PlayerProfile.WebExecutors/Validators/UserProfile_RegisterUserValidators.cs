using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.Validation;
using TheS.Casinova.PlayerProfile.Models;
using TheS.Casinova.PlayerProfile.Commands;
using TheS.Casinova.PlayerProfile.Command;
using TheS.Casinova.PlayerProfile.DAL;

namespace TheS.Casinova.PlayerProfile.Validator
{
    using PerfEx.Infrastructure.LotUpdate;

    public class UserProfile_RegisterUserValidators
           : ValidatorBase<UserProfile, RegisterUserCommand>
    {
        public override void Validate(UserProfile entity, RegisterUserCommand command, ValidationErrorCollection errors)
        {
            //ตรวจสอบการกรอกข้อมูล password ว่ามีหรือไม่ 
            if (string.IsNullOrEmpty(entity.Password)) {
                errors.Add(new ValidationError {
                    Instance = entity,
                    ErrorMessage = "ค่า Password ไม่ถูกต้อง",
                });
            }

            //ตรวจสอบการกรอกข้อมูล email ว่ามีหรือไม่ 
            if (string.IsNullOrEmpty(entity.Email)) {
                errors.Add(new ValidationError {
                    Instance = entity,
                    ErrorMessage = "ค่า Email ไม่ถูกต้อง",
                });
            }

            //ตรวจสอบการกรอกข้อมูล cellPhone ว่ามีหรือไม่ 
            if (string.IsNullOrEmpty(entity.CellPhone)) {
                errors.Add(new ValidationError {
                    Instance = entity,
                    ErrorMessage = "ค่า CellPhone ไม่ถูกต้อง",
                });
            }  
        }
    }
}
