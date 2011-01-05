using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.ChipExchange.Commands;
using TheS.Casinova.ChipExchange.Models;
using PerfEx.Infrastructure.Validation;

namespace TheS.Casinova.ChipExchange.Validators
{
    public class ExchangeInformation_ChipsToBonusChipsValidators
         : ValidatorBase<ExchangeInformation, ChipsToBonusChipsCommand>
    {
        public override void Validate(ExchangeInformation entity, ChipsToBonusChipsCommand command, ValidationErrorCollection errors)
        {
            throw new NotImplementedException();
        }
    }
}
