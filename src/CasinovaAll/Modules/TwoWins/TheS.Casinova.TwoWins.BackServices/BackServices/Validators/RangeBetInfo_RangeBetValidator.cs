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
    public class RangeBetInfo_RangeBetValidator
        : ValidatorBase<RangeBetInformation, RangeBetCommand>
    {
        private IGetRoundInfo _iGetRoundInfo;

        public RangeBetInfo_RangeBetValidator(ITwowinsDataBackQuery dqr)
        {
            _iGetRoundInfo = dqr;
        }

        public override void Validate(RangeBetInformation entity, RangeBetCommand command, ValidationErrorCollection errors)
        {
            GetRoundInfoCommand getRoundInfoCmd = new GetRoundInfoCommand { RoundID = entity.RoundID };
            getRoundInfoCmd.RoundInfo = _iGetRoundInfo.Get(getRoundInfoCmd);

            if (entity.RangeBetDateTime > getRoundInfoCmd.RoundInfo.ThruDateTime) {
                errors.Add(new ValidationError {
                    Instance = entity,
                    ErrorMessage = "หมดเวลาลงพนันแล้ว",
                });
            }
        }
    }
}
