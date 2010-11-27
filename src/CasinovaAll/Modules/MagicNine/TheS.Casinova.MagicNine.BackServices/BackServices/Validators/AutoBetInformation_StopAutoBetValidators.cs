using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.MagicNine.Models;
using TheS.Casinova.MagicNine.Commands;
using PerfEx.Infrastructure.Validation;

namespace TheS.Casinova.MagicNine.BackServices.Validators
{
    public class AutoBetInformation_StopAutoBetValidators
        : ValidatorBase<GamePlayAutoBetInformation, StopAutoBetCommand>
    {
        public override void Validate(GamePlayAutoBetInformation entity, StopAutoBetCommand command, ValidationErrorCollection errors)
        {
            if (entity.ThruDateTime != null) {
                errors.Add(new ValidationError {
                    Instance = entity,
                    ErrorMessage = "การลงพนันนี้ถูกหยุดไปแล้ว",
                });
            }
        }
    }
}
