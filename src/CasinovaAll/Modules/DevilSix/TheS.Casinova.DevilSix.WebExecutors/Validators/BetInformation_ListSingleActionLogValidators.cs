using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.DevilSix.Models;
using TheS.Casinova.DevilSix.Commands;
using PerfEx.Infrastructure.Validation;

namespace TheS.Casinova.DevilSix.Validators
{
    public class BetInformation_ListSingleActionLogValidators
         : ValidatorBase<BetInformation, ListSingleActionLogCommand>
    {
        public override void Validate(BetInformation entity, ListSingleActionLogCommand command, ValidationErrorCollection errors)
        {
            
            //ตรวจสอบข้อมูล RoundID 
            if (entity.RoundID < 1 || entity.RoundID > 4) {
                errors.Add(new ValidationError {
                    Instance = entity,
                    ErrorMessage = "ค่า RoundID ไม่ถูกต้อง",
                });
            }

            //ตรวจสอบวันที่ที่สามารถดูสถิติได้                
            if (entity.BetDateTime >= DateTime.Today) {
                errors.Add(new ValidationError {
                    Instance = entity,
                    ErrorMessage = "อนุญาตให้ดูเฉพาะข้อมูลย้อนหลัง",
                });
            }
        }
    }
}
