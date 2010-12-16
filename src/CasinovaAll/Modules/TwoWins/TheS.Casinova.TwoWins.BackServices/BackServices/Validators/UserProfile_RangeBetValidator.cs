using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.PlayerProfile.Models;
using TheS.Casinova.TwoWins.Commands;
using PerfEx.Infrastructure.Validation;

namespace TheS.Casinova.TwoWins.BackServices.Validators
{
    public class UserProfile_RangeBetValidator
        : ValidatorBase<UserProfile, RangeBetCommand>
    {
        public override void Validate(UserProfile entity, RangeBetCommand command, ValidationErrorCollection errors)
        {
            if (entity.Refundable + entity.NonRefundable < command.RangeBetInfo.FromAmount) {
                errors.Add(new ValidationError {
                    Instance = entity,
                    ErrorMessage = "จำนวนชิฟที่มีอยู่ไม่พอลงพนันอย่างน้อยหนึ่งมือ",
                });
            }
        }
    }
}
