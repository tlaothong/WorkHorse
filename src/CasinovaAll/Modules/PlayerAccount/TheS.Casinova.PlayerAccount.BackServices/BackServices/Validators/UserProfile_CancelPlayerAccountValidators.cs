using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.PlayerProfile.Models;
using TheS.Casinova.PlayerAccount.Commands;
using PerfEx.Infrastructure.Validation;
using TheS.Casinova.PlayerAccount.DAL;

namespace TheS.Casinova.PlayerAccount.BackServices.Validators
{
    public class UserProfile_CancelPlayerAccountValidators
        : ValidatorBase<UserProfile, CancelPlayerAccountCommand>
    {
        private IGetUserProfile _iGetUserProfile;

        public UserProfile_CancelPlayerAccountValidators(IPlayerAccountDataBackQuery dqr)
        {
            _iGetUserProfile = dqr;
        }

        public override void Validate(UserProfile entity, CancelPlayerAccountCommand command, ValidationErrorCollection errors)
        {
            GetUserProfileCommand getUserProfileCmd = new GetUserProfileCommand {
                UserProfileInput = new UserProfile { UserName = entity.UserName },
            };

            getUserProfileCmd.UserProfileOutput = _iGetUserProfile.Get(getUserProfileCmd);

            if (getUserProfileCmd.UserProfileOutput.Password != command.Password) {
                errors.Add(new ValidationError {
                    Instance = entity,
                    ErrorMessage = "รหัสผ่านไม่ถูกต้อง",
                });
            }
        }
    }
}
