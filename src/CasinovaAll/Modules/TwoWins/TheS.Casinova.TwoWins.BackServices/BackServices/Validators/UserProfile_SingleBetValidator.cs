using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.PlayerProfile.Models;
using TheS.Casinova.TwoWins.Commands;
using PerfEx.Infrastructure.Validation;
using TheS.Casinova.TwoWins.DAL;

namespace TheS.Casinova.TwoWins.BackServices.Validators
{
    public class UserProfile_SingleBetValidator
        : ValidatorBase<UserProfile, SingleBetCommand>
    {
        public override void Validate(UserProfile entity, SingleBetCommand command, ValidationErrorCollection errors)
        {
            if (entity.Refundable + entity.NonRefundable < command.BetInfo.Amount) {
                errors.Add(new ValidationError {
                    Instance = entity,
                    ErrorMessage = "จำนวนชิฟที่มีอยู่ไม่พอลงเงินพนัน",
                });
            }             
        }
    }
}
