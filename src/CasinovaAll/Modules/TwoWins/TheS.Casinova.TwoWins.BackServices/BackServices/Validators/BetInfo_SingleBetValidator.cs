using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.TwoWins.Models;
using TheS.Casinova.TwoWins.Commands;
using PerfEx.Infrastructure.Validation;
using TheS.Casinova.TwoWins.DAL;

namespace TheS.Casinova.TwoWins.BackServices.Validators
{
    public class BetInfo_SingleBetValidator
        : ValidatorBase<BetInformation, SingleBetCommand>
    {
        private IGetRoundInfo _iGetRoundInfo;

        public BetInfo_SingleBetValidator(ITwowinsDataBackQuery dqr)
        {
            _iGetRoundInfo = dqr;
        }

        public override void Validate(BetInformation entity, SingleBetCommand command, ValidationErrorCollection errors)
        {
            GetRoundInfoCommand getRoundInfoCmd = new GetRoundInfoCommand { RoundID = entity.RoundID };
            getRoundInfoCmd.RoundInfo = _iGetRoundInfo.Get(getRoundInfoCmd);

            if (entity.BetDateTime > getRoundInfoCmd.RoundInfo.ThruDateTime) {
                errors.Add(new ValidationError {
                    Instance = entity,
                    ErrorMessage = "หมดเวลาลงพนันแล้ว",
                });
            }
        }
    }
}
