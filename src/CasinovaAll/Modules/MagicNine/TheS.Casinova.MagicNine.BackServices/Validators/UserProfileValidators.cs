using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.PlayerProfile.Models;
using TheS.Casinova.MagicNine.Commands;
using PerfEx.Infrastructure.Validation;
using TheS.Casinova.MagicNine.DAL;

namespace TheS.Casinova.MagicNine.Validators
{
    public class UserProfileValidators
        : ValidatorBase<UserProfile, SingleBetCommand>
    {
        public override void Validate(UserProfile entity, SingleBetCommand command, ValidationErrorCollection errors)
        {
            if (entity.Refundable + entity.NonRefundable < command.Amount) {
                errors.Add(new ValidationError {
                    Instance = entity,
                    ErrorMessage = "จำนวนชิฟที่มีอยู่ไม่พอลงเงินพนัน",
                });
            }
        }
    }
}
