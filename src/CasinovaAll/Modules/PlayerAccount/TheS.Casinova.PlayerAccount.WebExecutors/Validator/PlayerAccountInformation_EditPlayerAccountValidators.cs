using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.Validation;
using TheS.Casinova.PlayerAccount.Models;
using TheS.Casinova.PlayerAccount.Commands;

namespace TheS.Casinova.PlayerAccount.Validator
{
    public class PlayerAccountInformation_EditPlayerAccountValidators
         : ValidatorBase<PlayerAccountInformation, EditPlayerAccountCommand>
    {
        public override void Validate(PlayerAccountInformation entity, EditPlayerAccountCommand command, ValidationErrorCollection errors)
        {
            //ตรวจสอบข้อมูลชนิดบัญชีว่ามีหรือไม่
            if (string.IsNullOrEmpty(entity.AccountType)) {
                errors.Add(new ValidationError {
                    Instance = entity,
                    ErrorMessage = "ค่า AccountType ไม่ถูกต้อง",
                });
            }

            //ตรวจสอบข้อมูลชนิดบัตรเครดิตว่ามีหรือไม่
            if (string.IsNullOrEmpty(entity.CardType)) {
                errors.Add(new ValidationError {
                    Instance = entity,
                    ErrorMessage = "ค่า CardType ไม่ถูกต้อง",
                });
            }

            //ตรวจสอบข้อมูลหมายเลขบัตรเครดิต
            if (string.IsNullOrEmpty(entity.AccountNo)) {
                errors.Add(new ValidationError {
                    Instance = entity,
                    ErrorMessage = "ค่าหมายเลขบัตรเครดิตไม่ถูกต้อง",
                });
            }

            //ตรวจสอบข้อมูลจำนวนหมายเลขบัตรเครดิต
            if(!string.IsNullOrEmpty(entity.AccountNo)){
                 int countAccountNo = entity.AccountNo.Count();
                 if (countAccountNo != 13 && countAccountNo != 16) {
                     errors.Add(new ValidationError {
                         Instance = entity,
                         ErrorMessage = "จำนวนหมายเลขบัตรเครดิตไม่ถูกต้อง",
                     });
                 }
            }

            //ตรวจสอบข้อมูลหมายเลข cvv
            if (string.IsNullOrEmpty(entity.CVV)) {
                errors.Add(new ValidationError {
                    Instance = entity,
                    ErrorMessage = "หมายเลข CVV ไม่ถูกต้อง",
                });
            }

            //ตรวจสอบข้อมูลจำนวนหมายเลขบัตรเครดิต
             if(!string.IsNullOrEmpty(entity.AccountNo)){
                 int countCVV = entity.CVV.Count();
                 if (countCVV != 4 ) {
                     errors.Add(new ValidationError {
                         Instance = entity,
                         ErrorMessage = "จำนวนหมายเลข CVV ไม่ถูกต้อง",
                     });
                 }
            }
        }
    }
}
