using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.PlayerProfile.Models;
using TheS.Casinova.PlayerProfile.Commands;
using PerfEx.Infrastructure.Validation;
using TheS.Casinova.PlayerProfile.DAL;

namespace TheS.Casinova.PlayerProfile.BackServices.Validators
{
    public class UserProfile_ChangePasswordValidators
        : ValidatorBase<UserProfile, ChangePasswordCommand>
    {
        private IGetUserProfile _iGetUserProfile;

        public UserProfile_ChangePasswordValidators(IPlayerProfileDataBackQuery dqr)
        {
            _iGetUserProfile = dqr;
        }

        public override void Validate(UserProfile entity, ChangePasswordCommand command, ValidationErrorCollection errors)
        {
            GetUserProfileCommand getUserProfileCmd = new GetUserProfileCommand {
                UserName = command.UserName
            };

            getUserProfileCmd.PlayerProfile = _iGetUserProfile.Get(getUserProfileCmd);

            //ตรวจสอบรหัสผ่านเดิมว่าถูกต้องหรือไม่
            if (getUserProfileCmd.PlayerProfile.Password != command.UserProfile.Password) {
                errors.Add(new ValidationError {
                    Instance = entity,
                    ErrorMessage = "รหัสผ่านเดิมไม่ถูกต้อง",
                });
            }
        }
    }
}
