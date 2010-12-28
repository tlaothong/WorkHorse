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
    public class BetInfo_ChangeBetValidator
        : ValidatorBase<BetInformation, ChangeBetInfoCommand>
    {
        private IGetRoundInfo _iGetRoundInfo;

        public BetInfo_ChangeBetValidator(ITwowinsDataBackQuery dqr)
        {
            _iGetRoundInfo = dqr;
        }

        public override void Validate(BetInformation entity, ChangeBetInfoCommand command, ValidationErrorCollection errors)
        {
            GetRoundInfoCommand getRoundInfoCmd = new GetRoundInfoCommand { RoundID = entity.RoundID };
            getRoundInfoCmd.RoundInfo = _iGetRoundInfo.Get(getRoundInfoCmd);

            if (entity.BetDateTime > getRoundInfoCmd.RoundInfo.ThruDateTime) {
                errors.Add(new ValidationError {
                    Instance = entity,
                    ErrorMessage = "หมดเวลาลงพนันแล้ว",
                });
            }
            
            if (entity.CanChange == false) {
                errors.Add(new ValidationError {
                    Instance = entity,
                    ErrorMessage = "การลงพนันนี้ไม่สามารถแก้ไขได้แล้ว",
                });
            }

            if (entity.Amount > command.BetInfo.Amount) {
                errors.Add(new ValidationError {
                    Instance = entity,
                    ErrorMessage = "จำนวนเงินที่แก้ไขต้องมากกว่าเดิม",
                });
            }
        }
    }
}
