using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.Validation;
using TheS.Casinova.TwoWins.Models;
using TheS.Casinova.TwoWins.Commands;

namespace TheS.Casinova.TwoWins.Validators
{
    public class RangeBetInformation_RangeBetValidators
     : ValidatorBase<RangeBetInformation, RangeBetCommand>
    {
        public override void Validate(RangeBetInformation entity, RangeBetCommand command, ValidationErrorCollection errors)
        {
            //ตรวจสอบจำนวนเงินเดิมพัน
            if (entity.ThruAmount < entity.FromAmount) {
                errors.Add(new ValidationError {
                    Instance = entity,
                    ErrorMessage = "ค่า ThruAmount ไม่ถูกต้อง ",
                });
            }
        }
    }
}
