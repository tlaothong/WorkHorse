using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.DevilSix.Commands;
using TheS.Casinova.DevilSix.Models;
using PerfEx.Infrastructure.Validation;

namespace TheS.Casinova.DevilSix.Validators
{
    public class BetInformation_ListBetLogValidators
         : ValidatorBase<BetInformation, ListBetLogCommand>
    {
        public override void Validate(BetInformation entity, ListBetLogCommand command, ValidationErrorCollection errors)
        {
            //ตรวจสอบข้อมูล RoundID 
            if (entity.RoundID < 1 || entity.RoundID > 4) {
                errors.Add(new ValidationError {
                    Instance = entity,
                    ErrorMessage = "ค่า RoundID ไม่ถูกต้อง",
                });
            }
        }
    }
}
