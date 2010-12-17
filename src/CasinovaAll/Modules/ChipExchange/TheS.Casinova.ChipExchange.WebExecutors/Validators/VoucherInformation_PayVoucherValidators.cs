using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.Validation;
using TheS.Casinova.ChipExchange.Models;
using TheS.Casinova.ChipExchange.Commands;
using TheS.Casinova.ChipExchange.DAL;
using TheS.Casinova.PlayerProfile.Models;

namespace TheS.Casinova.ChipExchange.Validators
{
    public class VoucherInformation_PayVoucherValidators
         : ValidatorBase<VoucherInformation, PayVoucherCommand>
    {
        
        public override void Validate(VoucherInformation entity, PayVoucherCommand command, ValidationErrorCollection errors)
        {
            //ตรวจสอบข้อมูลจำนวนเงิน
            if (entity.Amount < 1) {
                errors.Add(new ValidationError {
                    Instance = entity,
                    ErrorMessage = "ค่า Amount ไม่ถูกต้อง",
                });
            }
        }
    }
}
