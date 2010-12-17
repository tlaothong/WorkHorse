using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.ChipExchange.Commands;
using TheS.Casinova.ChipExchange.Models;
using PerfEx.Infrastructure.Validation;

namespace TheS.Casinova.ChipExchange.Validators
{
    public class VoucherInformation_VoucherToBonusChipsValidators
         : ValidatorBase<VoucherInformation, VoucherToBonusChipsCommand>
    {
        public override void Validate(VoucherInformation entity, VoucherToBonusChipsCommand command, ValidationErrorCollection errors)
        {
            int count = entity.VoucherCode.Count();
            //ตรวจสอบข้อมูลรหัสคูปอง
            if (count != 5) {
                errors.Add(new ValidationError {
                    Instance = entity,
                    ErrorMessage = "ค่า VoucherCode ไม่ถูกต้อง",
                });
            }
        }
    }
}
