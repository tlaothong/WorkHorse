using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.Colors.Models;
using TheS.Casinova.Colors.Commands;
using PerfEx.Infrastructure.Validation;
using PerfEx.Infrastructure.CommandPattern;

namespace TheS.Casinova.Colors.Validators
{
    using PerfEx.Infrastructure.LotUpdate;

    public class GameRoundConfiguration_CreateGameRoundConfigurationValidator
        : ValidatorBase<GameRoundConfiguration, CreateGameRoundConfigurationCommand>
    {
        public override void Validate(GameRoundConfiguration entity, CreateGameRoundConfigurationCommand command, ValidationErrorCollection errors)
        {
            // TODO: สมมติ ไม่ได้เอาจริง
            if (entity.Interval < 20) {
                errors.Add(new ValidationError {
                    Instance = entity,
                    ErrorMessage = "ค่า Interval ต่ำกว่า 20 ไม่ได้เด้อ",
                });
            }
        }
    }
}
