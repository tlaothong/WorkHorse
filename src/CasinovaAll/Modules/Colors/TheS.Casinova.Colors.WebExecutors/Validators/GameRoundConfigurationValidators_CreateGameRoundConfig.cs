using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.Colors.Models;
using TheS.Casinova.Colors.Commands;
using PerfEx.Infrastructure.Validation;
using PerfEx.Infrastructure.CommandPattern;

namespace TheS.Casinova.Colors.Validators
{
    using PerfEx.Infrastructure.LotUpdate;

    public class GameRoundConfiguration_CreateGameRoundConfigurationValidator
        : ValidatorBase<GameRoundConfiguration, CreateGameRoundConfigurationCommand>
    {
        public override void Validate(GameRoundConfiguration entity, CreateGameRoundConfigurationCommand command, ValidationErrorCollection errors)
        {
            //ตรวจสอบข้อมูลชื่อโต๊ะเกม
            if (entity.Name.Length < 5 || entity.Name.Length > 50) {
                errors.Add(new ValidationError {
                    Instance = entity,
                    ErrorMessage = "ชื่อโต๊ะเกมต้องมากกว่า 5 แต่ไม่เกิน 50 ตัวอักษร",
                });
            }

            //ตรวจสอบจำนวนโต๊ะเกม
            if (entity.TableAmount < 0 || entity.TableAmount > 99) {
                errors.Add(new ValidationError {
                    Instance = entity,
                    ErrorMessage = "ค่า TableAmount ต้องมากกว่า 0 และน้อยกว่า 99 ",
                });
            }

            //ตรวจสอบระยะเวลาที่ใช้ในการเล่นเกม
            if (entity.GameDuration < 0 || entity.GameDuration > 1440) {
                errors.Add(new ValidationError {
                    Instance = entity,
                    ErrorMessage = "ค่า GameDuration ต้องมากกว่า 0 และไม่เกิน 1440 นาที (24 ชั่วโมง) ",
                });
            }

            // ตรวจสอบค่าระยะห่างในการเริ่มเกม
            if (entity.Interval < 0 || entity.Interval > 1440) {
                errors.Add(new ValidationError {
                    Instance = entity,
                    ErrorMessage = "ค่า Interval ต้องมากกว่า 0 และไม่เกิน 1440 นาที (24 ชั่วโมง) ",
                });
            }
        }
    }
}
