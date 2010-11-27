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
    public class UserProfile_VerifyUserValidators
        : ValidatorBase<UserProfile, VerifyUserCommand>
    {
        private IGetUserProfile _iGetUserProfile;

        public UserProfile_VerifyUserValidators(IPlayerProfileDataBackQuery dqr)
        {
            _iGetUserProfile = dqr;
        }

        public override void Validate(UserProfile entity, VerifyUserCommand command, ValidationErrorCollection errors)
        {
            GetUserProfileCommand getUserProfileCmd = new GetUserProfileCommand {
                UserName = entity.UserName
            };
            var userProfile = _iGetUserProfile.Get(getUserProfileCmd);

            if(userProfile == null){
                errors.Add(new ValidationError {
                    Instance = entity,
                    ErrorMessage = "ไม่มีชื่อผู้เล่นนี้ในระบบ",
                });
            }
            else if (entity.VeriflyCode != userProfile.VeriflyCode) {
                errors.Add(new ValidationError {
                    Instance = entity,
                    ErrorMessage = "รหัสยืนยันไม่ถูกต้อง",
                });
            }
        }             
    }
}
