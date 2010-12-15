using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.Validation;
using TheS.Casinova.TwoWins.Models;
using TheS.Casinova.TwoWins.Commands;

namespace TheS.Casinova.TwoWins.Validators
{
    public class BetInformation_SingleBetValidators
        : ValidatorBase<BetInformation, SingleBetCommand>
    {
        public override void Validate(BetInformation entity, SingleBetCommand command, ValidationErrorCollection errors)
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
