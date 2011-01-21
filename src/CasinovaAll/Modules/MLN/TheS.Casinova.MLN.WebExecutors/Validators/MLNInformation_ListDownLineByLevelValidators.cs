using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.MLN.Models;
using PerfEx.Infrastructure.Validation;
using TheS.Casinova.MLN.Commands;

namespace TheS.Casinova.MLN.Validators
{
    public class MLNInformation_ListDownLineByLevelValidators
         : ValidatorBase<MLNInformation, ListDownLineByLevelCommand>
    {
        public override void Validate(MLNInformation entity, ListDownLineByLevelCommand command, ValidationErrorCollection errors)
        {
            //ตรวจสอบการกรอกข้อมูล upline
            if (string.IsNullOrEmpty(entity.UplineLevel1)) {
                errors.Add(new ValidationError {
                    Instance = entity,
                    ErrorMessage = "กรอกข้อมูล upline",
                });
            }
        }
    }
}
