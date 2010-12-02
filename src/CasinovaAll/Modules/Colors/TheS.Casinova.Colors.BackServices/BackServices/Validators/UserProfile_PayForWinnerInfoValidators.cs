using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.Colors.Commands;
using TheS.Casinova.PlayerProfile.Models;
using PerfEx.Infrastructure.Validation;

namespace TheS.Casinova.Colors.BackServices.Validators
{
    public class UserProfile_PayForWinnerInfoValidators
        : ValidatorBase<UserProfile, PayForColorsWinnerInfoCommand>
    {
        public override void Validate(UserProfile entity, PayForColorsWinnerInfoCommand command, ValidationErrorCollection errors)
        {
            if ((entity.NonRefundable + entity.Refundable) < command.PlayerActionInfo.Amount) {
                errors.Add(new ValidationError {
                    Instance = entity,
                    ErrorMessage = "จำนวนชิฟที่มีอยู่ไม่พอลงเงินพนัน",
                });
            }
        }
    }
}
