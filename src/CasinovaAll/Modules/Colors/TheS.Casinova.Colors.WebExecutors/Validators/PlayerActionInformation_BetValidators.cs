using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.Validation;
using TheS.Casinova.Colors.Commands;
using TheS.Casinova.Colors.Models;

namespace TheS.Casinova.Colors.Validators
{
    public class PlayerActionInformation_BetValidators
         : ValidatorBase<PlayerActionInformation, BetCommand>
    {
        public override void Validate(PlayerActionInformation entity, BetCommand command, ValidationErrorCollection errors)
        {
            //ตรวจสอบจำนวนเงินที่ลงเดิมพัน
            if (entity.Amount < 1) {
                errors.Add(new ValidationError {
                    Instance = entity,
                    ErrorMessage = "ค่า Amount ต้องมากกว่า 0 ",
                });
            }
        }
    }
}
