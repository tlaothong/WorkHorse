using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.Validation;
using TheS.Casinova.ChipExchange.Commands;
using TheS.Casinova.ChipExchange.Models;

namespace TheS.Casinova.ChipExchange.Validators
{
    public class ChequeInformation_ChipsToMoneyValidators
         : ValidatorBase<ChequeInformation, ChipsToMoneyCommand>
    {
        public override void Validate(ChequeInformation entity, ChipsToMoneyCommand command, ValidationErrorCollection errors)
        {
            //ตรวจสอบข้อมูล address
            if (string.IsNullOrEmpty(entity.Address)) {
                errors.Add(new ValidationError {
                    Instance = entity,
                    ErrorMessage = "ค่า Address ไม่ถูกต้อง",
                });
            }
        }
    }
}
