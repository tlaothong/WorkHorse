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
    public class ExchangeSettingInfo_ChipsToMoneyValidators
        : ValidatorBase<ExchangeSettingInformation, ChipsToMoneyCommand>
    {
        private IGetExchangeSetting _iGetExchangeSetting;

        public ExchangeSettingInfo_ChipsToMoneyValidators(IChipExchangeDataBackQuery dqr)
        {
            _iGetExchangeSetting = dqr;
        }

        public override void Validate(ExchangeSettingInformation entity, ChipsToMoneyCommand command, ValidationErrorCollection errors)
        {
            GetExchangeSettingCommand getExchangeSettingCmd = new GetExchangeSettingCommand {
                ExchangeSettingInput = entity,
            };

            getExchangeSettingCmd.ExchangeSetting = _iGetExchangeSetting.Get(getExchangeSettingCmd);

            if (getExchangeSettingCmd.ExchangeSetting.MinChipToMoneyExchange < command.Amount) {
                errors.Add(new ValidationError {
                    Instance = entity,
                    ErrorMessage = "ชิฟที่จะแลกเป็นเงิน น้อยกว่าขั้นต่ำที่กำหนด",
                });
            }
        }
    }
}
