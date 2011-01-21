using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.Validation;
using TheS.Casinova.MLN.Models;
using TheS.Casinova.MLN.Commands;

namespace TheS.Casinova.MLN.Validators
{
    public class MLNInformation_CreateMLNInfoValidators
         : ValidatorBase<MLNInformation, CreateMLNInfoCommand>
    {
        public override void Validate(MLNInformation entity, CreateMLNInfoCommand command, ValidationErrorCollection errors)
        {
            //ตรวจสอบการกรอกข้อมูล UserName
            if (string.IsNullOrEmpty(entity.UserName)) {
                errors.Add(new ValidationError {
                    Instance = entity,
                    ErrorMessage = "กรอกข้อมูล userName",
                });
            }

            //ตรวจสอบการกรอกข้อมูล upline
            if (string.IsNullOrEmpty(entity.UplineLevel1)) {
                errors.Add(new ValidationError{
                    Instance = entity,
                    ErrorMessage = "กรอกข้อมูล upline",
                });
            }
        }
    }
}
