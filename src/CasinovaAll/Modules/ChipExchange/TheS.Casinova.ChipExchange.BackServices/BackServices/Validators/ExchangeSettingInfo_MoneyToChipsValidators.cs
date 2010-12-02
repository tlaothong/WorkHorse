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
    public class ExchangeSettingInfo_MoneyToChipsValidators
        : ValidatorBase<ExchangeSettingInformation, MoneyToChipsCommand>
    {
        private IGetExchangeSetting _iGetExchangeSetting;

        public ExchangeSettingInfo_MoneyToChipsValidators(IChipExchangeDataBackQuery dqr)
        {
            _iGetExchangeSetting = dqr;
        }

        public override void Validate(ExchangeSettingInformation entity, MoneyToChipsCommand command, ValidationErrorCollection errors)
        {
            GetExchangeSettingCommand getExchangeSettingCmd = new GetExchangeSettingCommand {
                ExchangeSettingInput = entity,
            };

            getExchangeSettingCmd.ExchangeSetting = _iGetExchangeSetting.Get(getExchangeSettingCmd);

            //Request amount should more than minimum exchange rate
            if (command.ExchangeInformation.Amount < getExchangeSettingCmd.ExchangeSetting.MinMoneyToChipExchange) {
                errors.Add(new ValidationError {
                    Instance = entity,
                    ErrorMessage = "จำนวนเงินที่ต้องการแลกชิฟน้อยกว่าขั้นต่ำที่กำหนด",
                });
            }
        }
    }
}
