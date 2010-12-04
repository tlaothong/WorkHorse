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
    public class UserProfile_RegisterUserValidators
        : ValidatorBase<UserProfile, RegisterUserCommand>
    {
        private IGetUserProfile _iGetUserProfile;

        public UserProfile_RegisterUserValidators(IPlayerProfileDataBackQuery dqr)
        {
            _iGetUserProfile = dqr;
        }

        public override void Validate(UserProfile entity, RegisterUserCommand command, ValidationErrorCollection errors)
        {
            GetUserProfileCommand getUserProfileCmd = new GetUserProfileCommand {
                GetUserProfileInfo = new UserProfile {
                    UserName = entity.Upline
                }

            };
            var upline = _iGetUserProfile.Get(getUserProfileCmd);

            if (upline == null) {
                errors.Add(new ValidationError {
                    Instance = entity,
                    ErrorMessage = "ไม่มีผู้เล่นที่ระบุ",
                });
            }
        }
    }
}
