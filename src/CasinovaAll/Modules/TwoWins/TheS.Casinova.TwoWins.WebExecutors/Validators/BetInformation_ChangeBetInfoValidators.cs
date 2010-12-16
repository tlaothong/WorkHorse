using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.Validation;
using TheS.Casinova.TwoWins.Commands;
using TheS.Casinova.TwoWins.Models;

namespace TheS.Casinova.TwoWins.Validators
{
    public class BetInformation_ChangeBetInfoValidators
         : ValidatorBase<BetInformation, ChangeBetInfoCommand>
    {
        public override void Validate(BetInformation entity, ChangeBetInfoCommand command, ValidationErrorCollection errors)
        {
            //ตรวจสอบจำนวนเงินเดิมพัน
            if (entity.Amount < 1) {
                errors.Add(new ValidationError {
                    Instance = entity,
                    ErrorMessage = "ค่า Amount ต้องมากกว่า 0 ",
                });
            }
        }
    }
}
