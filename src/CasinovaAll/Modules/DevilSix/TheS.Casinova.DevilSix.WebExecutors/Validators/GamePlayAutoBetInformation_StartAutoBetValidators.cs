using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.DevilSix.Models;
using PerfEx.Infrastructure.Validation;
using TheS.Casinova.DevilSix.Commands;

namespace TheS.Casinova.DevilSix.Validators
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
            //ตรวจสอบข้อมูลระยะห่างของเวลาในการลงเดิมพันแบบอัตโนมัติ
            if (entity.Interval < 1) {
                errors.Add(new ValidationError {
                    Instance = entity,
                    ErrorMessage = "ค่า Interval ไม่ถูกต้อง",
                });
            }

            //ตรวจสอบข้อมูลจำนวน Amount
            if (entity.RoundID == 1) {
                if (entity.Amount != 1 && entity.Amount != 2) {
                    errors.Add(new ValidationError {
                        Instance = entity,
                        ErrorMessage = "ค่า Amount ไม่ถูกต้อง",
                    });
                }
            }

            if (entity.RoundID == 2) {
                if (entity.Amount != 1 && entity.Amount != 5 && entity.Amount != 10 && entity.Amount != 20) {
                    errors.Add(new ValidationError {
                        Instance = entity,
                        ErrorMessage = "ค่า Amount ไม่ถูกต้อง",
                    });
                }
            }

            if (entity.RoundID == 3) {
                if (entity.Amount != 1 && entity.Amount != 5 && entity.Amount != 10 && entity.Amount != 50 && entity.Amount != 200) {
                    errors.Add(new ValidationError {
                        Instance = entity,
                        ErrorMessage = "ค่า Amount ไม่ถูกต้อง",
                    });
                }
            }

            if (entity.RoundID == 4) {
                if (entity.Amount != 1 && entity.Amount != 10 && entity.Amount != 100 && entity.Amount != 500 && entity.Amount != 2000) {
                    errors.Add(new ValidationError {
                        Instance = entity,
                        ErrorMessage = "ค่า Amount ไม่ถูกต้อง",
                    });
                }
            }

            //ตรวจสอบจำนวนเงินทั้งหมด
            if (entity.TotalAmount < entity.Amount ){
                errors.Add(new ValidationError {
                    Instance = entity,
                    ErrorMessage = "ค่า Amountไม่ถูกต้อง",
                });
            }
        }
    }
}
