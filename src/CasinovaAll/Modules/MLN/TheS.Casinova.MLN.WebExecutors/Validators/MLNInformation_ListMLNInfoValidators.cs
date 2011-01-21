using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.Validation;
using TheS.Casinova.MLN.Models;
using TheS.Casinova.MLN.Commands;

namespace TheS.Casinova.MLN.Validators
{
    public class MLNInformation_ListMLNInfoValidators
         : ValidatorBase<MLNInformation, ListMLNInfoCommand>
    {
        public override void Validate(MLNInformation entity, ListMLNInfoCommand command, ValidationErrorCollection errors)
        {
            //ตรวจสอบการกรอกข้อมูล UserName
            if (string.IsNullOrEmpty(entity.UserName)) {
                errors.Add(new ValidationError {
                    Instance = entity,
                    ErrorMessage = "กรอกข้อมูล userName",
                });
            }
        }
    }
}
