using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.Validation;
using TheS.Casinova.MagicNine.Models;
using TheS.Casinova.MagicNine.Commands;

namespace TheS.Casinova.MagicNine.Validators
{
    public class GamePlayAutoBetInformation_StartAutoBetValidators
         : ValidatorBase<GamePlayAutoBetInformation, StartAutoBetCommand>
    {
        public override void Validate(GamePlayAutoBetInformation entity, StartAutoBetCommand command, ValidationErrorCollection errors)
        {
            //ตรวจสอบข้อมูล RoundID 
            if (entity.RoundID < 1 || entity.RoundID > 4) {
                errors.Add(new ValidationError {
                    Instance = entity,
                    ErrorMessage = "ค่า RoundID ไม่ถูกต้อง",
                });
            }

            //ตรวจสอบข้อมูลจำนวนเงิน
            if (entity.Amount < 1) {
                errors.Add(new ValidationError {
                    Instance = entity,
                    ErrorMessage = "ค่า Amount ไม่ถูกต้อง",
                });
            }

            //ตรวจสอบข้อมูลระยะห่างของเวลาในการลงเดิมพันแบบอัตโนมัติ
            if (entity.Interval < 1) {
                errors.Add(new ValidationError {
                    Instance = entity,
                    ErrorMessage = "ค่า Interval ไม่ถูกต้อง",
                });
            }
        }
    }
}
