using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.Validation;
using TheS.Casinova.DevilSix.Models;
using TheS.Casinova.DevilSix.Commands;


namespace TheS.Casinova.DevilSix.Validators
{
    public class GamePlayAutoBetInformation_StopAutoBetValidators
        : ValidatorBase<GamePlayAutoBetInformation, StopAutoBetCommand>
    {
        public override void Validate(GamePlayAutoBetInformation entity, StopAutoBetCommand command, ValidationErrorCollection errors)
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
