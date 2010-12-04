using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.ChipExchange.Models;
using TheS.Casinova.ChipExchange.Commands;
using PerfEx.Infrastructure.Validation;

namespace TheS.Casinova.ChipExchange.BackServices.Validators
{
    public class ChequeInfo_ChipsToMoneyValidators
        : ValidatorBase<ChequeInformation, ChipsToMoneyCommand>
    {
        public override void Validate(ChequeInformation entity, ChipsToMoneyCommand command, ValidationErrorCollection errors)
        {
            if (string.IsNullOrEmpty(entity.Address)) {
                errors.Add(new ValidationError {
                    Instance = entity,
                    ErrorMessage = "กรุณากรอกข้อมูลที่อยู่",
                });
            }
        }
    }
}
