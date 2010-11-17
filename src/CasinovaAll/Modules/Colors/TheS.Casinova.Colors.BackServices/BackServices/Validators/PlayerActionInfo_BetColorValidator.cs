using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.Colors.Models;
using TheS.Casinova.Colors.Commands;
using PerfEx.Infrastructure.Validation;

namespace TheS.Casinova.Colors.BackServices.Validators
{
    public class PlayerActionInfo_BetColorValidator
        : ValidatorBase<PlayerActionInformation, BetCommand>
    {
        public override void Validate(PlayerActionInformation entity, BetCommand command, ValidationErrorCollection errors)
        {
            if (entity.ActionType == "Black" || entity.ActionType == "White") { }
            else {
                errors.Add(new ValidationError {
                    Instance = entity,
                    ErrorMessage = "ลงพนันได้เฉพาะสีดำ/ขาว",
                });
            }
        }
    }
}
