using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.PlayerProfile.Models;
using TheS.Casinova.MagicNine.Commands;
using PerfEx.Infrastructure.Validation;

namespace TheS.Casinova.MagicNine.BackServices.Validators
{
    public class UserProfile_StartAutoBetValidators
        : ValidatorBase<UserProfile, StartAutoBetCommand>
    {
        public override void Validate(UserProfile entity, StartAutoBetCommand command, ValidationErrorCollection errors)
        {
            if (entity.Refundable + entity.NonRefundable < command.GamePlayAutoBetInfo.Amount) {
                errors.Add(new ValidationError {
                    Instance = entity,
                    ErrorMessage = "จำนวนชิฟที่มีอยู่ไม่พอลงเงินพนัน",
                });
            }
        }
    }
}
