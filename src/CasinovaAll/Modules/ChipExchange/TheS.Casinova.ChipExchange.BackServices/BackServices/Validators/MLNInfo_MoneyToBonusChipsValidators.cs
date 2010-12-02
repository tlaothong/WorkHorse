using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.ChipExchange.Models;
using TheS.Casinova.ChipExchange.Commands;
using PerfEx.Infrastructure.Validation;
using TheS.Casinova.ChipExchange.DAL;

namespace TheS.Casinova.ChipExchange.BackServices.Validators
{
    public class MLNInfo_MoneyToBonusChipsValidators
        : ValidatorBase<MultiLevelNetworkInformation, MoneyToBonusChipsCommand>
    {
        private IGetMLNInfo _iGetMLNInfo;

        public MLNInfo_MoneyToBonusChipsValidators(IChipExchangeDataBackQuery dqr)
        {
            _iGetMLNInfo = dqr;
        }

        public override void Validate(MultiLevelNetworkInformation entity, MoneyToBonusChipsCommand command, ValidationErrorCollection errors)
        {
            GetMLNInfoCommand getMLNInfoCmd = new GetMLNInfoCommand {
                MLNInfoInput = entity,
            };

            getMLNInfoCmd.MLNInfo = _iGetMLNInfo.Get(getMLNInfoCmd);

            //Request amount should more than bonus
            if (getMLNInfoCmd.MLNInfo.Bonus < command.ExchangeInformation.Amount) {
                errors.Add(new ValidationError {
                    Instance = entity,
                    ErrorMessage = "โบนัสไม่พอแลกชิปตาย",
                });
            }
        }
    }
}
