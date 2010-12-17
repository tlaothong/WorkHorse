using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.Validation;
using TheS.Casinova.PlayerAccount.Models;
using TheS.Casinova.PlayerAccount.Commands;

namespace TheS.Casinova.PlayerAccount.Validator
{
    public class PlayerAccountInformation_GetPlayerAccountValidators
         : ValidatorBase<PlayerAccountInformation, GetPlayerAccountCommand>
    {
        public override void Validate(PlayerAccountInformation entity, GetPlayerAccountCommand command, ValidationErrorCollection errors)
        {
            //ตรวจสอบข้อมูลชนิดบัญชีว่ามีหรือไม่
            if (string.IsNullOrEmpty(entity.AccountType)) {
                errors.Add(new ValidationError {
                    Instance = entity,
                    ErrorMessage = "ค่า AccountType ไม่ถูกต้อง",
                });
            }
        }
    }
}
