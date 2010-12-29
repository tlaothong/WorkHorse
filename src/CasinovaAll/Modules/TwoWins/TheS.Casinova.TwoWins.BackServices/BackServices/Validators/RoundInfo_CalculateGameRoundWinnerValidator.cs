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
    public class RoundInfo_CalculateGameRoundWinnerValidator
        : ValidatorBase<RoundInformation, CalculateGameRoundWinnerCommand>
    {
        private IGetRoundInfo _iGetRoundInfo;

        public RoundInfo_CalculateGameRoundWinnerValidator(ITwowinsDataBackQuery dqr)
        {
            _iGetRoundInfo = dqr;
        }

        public override void Validate(RoundInformation entity, CalculateGameRoundWinnerCommand command, ValidationErrorCollection errors)
        {
            GetRoundInfoCommand getRoundInfoCmd = new GetRoundInfoCommand { RoundID = entity.RoundID };
            getRoundInfoCmd.RoundInfo = _iGetRoundInfo.Get(getRoundInfoCmd);

            if (DateTime.Now < getRoundInfoCmd.RoundInfo.FromDateTime) {
                errors.Add(new ValidationError {
                    Instance = getRoundInfoCmd.RoundInfo,
                    ErrorMessage = "โต๊ะเกมยังไม่เริ่มเล่น",
                });
            }
        }
    }
}
