using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.Validation;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.Colors.Commands;
using TheS.Casinova.Colors.Models;

namespace TheS.Casinova.Colors.Validators
{
    class GameRoundConfigurationValidators_CheckActiveGameRoundToCreate
        :ValidatorBase<GameRoundConfiguration, CheckActiveRoundToCreateCommand>
    {
        public override void Validate(GameRoundConfiguration entity, CheckActiveRoundToCreateCommand command, ValidationErrorCollection errors)
        {

            //ตรวจสอบข้อมูลชื่อโต๊ะเกม
            if (entity.Name == null) {
                errors.Add(new ValidationError {
                    Instance = entity,
                    ErrorMessage = "กรุณากรอกชื่อโต๊ะเกม",
                });
            }

            //ตรวจสอบข้อมูลชื่อโต๊ะเกม
            if (entity.Name.Length < 5 || entity.Name.Length > 50) {
                errors.Add(new ValidationError {
                    Instance = entity,
                    ErrorMessage = "ชื่อโต๊ะเกมต้องมากกว่า 5 แต่ไม่เกิน 50 ตัวอักษร",
                });
            }
        }
    }
}
