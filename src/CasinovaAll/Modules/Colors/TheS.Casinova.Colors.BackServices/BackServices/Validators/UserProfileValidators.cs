using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.PlayerProfile.Models;
using TheS.Casinova.Colors.Commands;
using PerfEx.Infrastructure.Validation;

namespace TheS.Casinova.Colors.BackServices.Validators
{
    public class UserProfileValidators
        : ValidatorBase<UserProfile, BetCommand>
    {
        public override void Validate(UserProfile entity, BetCommand command, ValidationErrorCollection errors)
        {
            if (entity.NonRefundable + entity.Refundable < command.PlayerActionInfo.Amount) {
                errors.Add(new ValidationError {
                    Instance = entity,
                    ErrorMessage = "จำนวนชิฟที่มีอยู่ไม่พอลงเงินพนัน",
                });
            }
        }
    }
}
