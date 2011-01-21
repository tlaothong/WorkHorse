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
                if (entity.BetInterval != 1 && entity.BetInterval != 2) {
                    errors.Add(new ValidationError {
                        Instance = entity,
                        ErrorMessage = "ค่า Amount ไม่ถูกต้อง",
                    });
                }
            }

            if (entity.RoundID == 2) {
                if (entity.BetInterval != 1 && entity.BetInterval != 5 && entity.BetInterval != 10 && entity.BetInterval != 20) {
                    errors.Add(new ValidationError {
                        Instance = entity,
                        ErrorMessage = "ค่า Amount ไม่ถูกต้อง",
                    });
                }
            }

            if (entity.RoundID == 3) {
                if (entity.BetInterval != 1 && entity.BetInterval != 5 && entity.BetInterval != 10 && entity.BetInterval != 50 && entity.BetInterval != 200) {
                    errors.Add(new ValidationError {
                        Instance = entity,
                        ErrorMessage = "ค่า Amount ไม่ถูกต้อง",
                    });
                }
            }

            if (entity.RoundID == 4) {
                if (entity.BetInterval != 1 && entity.BetInterval != 10 && entity.BetInterval != 100 && entity.BetInterval != 500 && entity.BetInterval != 2000) {
                    errors.Add(new ValidationError {
                        Instance = entity,
                        ErrorMessage = "ค่า Amount ไม่ถูกต้อง",
                    });
                }
            }

            //ตรวจสอบจำนวนเงินทั้งหมด
            if (entity.Amount < entity.BetInterval) {
                errors.Add(new ValidationError {
                    Instance = entity,
                    ErrorMessage = "ค่า Amountไม่ถูกต้อง",
                });
            }
        }
    }
}
