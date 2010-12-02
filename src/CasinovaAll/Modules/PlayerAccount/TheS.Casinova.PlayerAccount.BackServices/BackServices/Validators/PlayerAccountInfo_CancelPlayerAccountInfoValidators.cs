using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.PlayerProfile.Models;
using TheS.Casinova.PlayerAccount.Commands;
using PerfEx.Infrastructure.Validation;
using TheS.Casinova.PlayerAccount.Models;
using TheS.Casinova.PlayerAccount.DAL;

namespace TheS.Casinova.PlayerAccount.BackServices.Validators
{
    public class PlayerAccountInfo_CancelPlayerAccountInfoValidators
        : ValidatorBase<PlayerAccountInformation, CancelPlayerAccountCommand>
    {
        private IGetUserProfile _iGetUserProfile;
        private IGetPlayerAccountInfoByAccountType _iGetPlayerAccountInfoByAccountType;

        public PlayerAccountInfo_CancelPlayerAccountInfoValidators(IPlayerAccountDataBackQuery dqr)
        {
            _iGetUserProfile = dqr;
            _iGetPlayerAccountInfoByAccountType = dqr;
        }

        public override void Validate(PlayerAccountInformation entity, CancelPlayerAccountCommand command, ValidationErrorCollection errors)
        {
            GetUserProfileCommand getUserProfileCmd = new GetUserProfileCommand {
                UserProfileInput = new UserProfile { UserName = entity.UserName },
            };

            getUserProfileCmd.UserProfileOutput = _iGetUserProfile.Get(getUserProfileCmd);

            GetPlayerAccountInfoByAccountTypeCommand getPlayerAccountInfoCmd = new GetPlayerAccountInfoByAccountTypeCommand {
                PlayerAccountInfo = entity,
            };

            getPlayerAccountInfoCmd.PlayerAccountInformation = _iGetPlayerAccountInfoByAccountType.Get(getPlayerAccountInfoCmd);

            if (getUserProfileCmd.UserProfileOutput.Password != command.Password) {
                errors.Add(new ValidationError { 
                    Instance = entity,
                    ErrorMessage = "รหัสผ่านไม่ถูกต้อง",
                });
            }

            if (getPlayerAccountInfoCmd.PlayerAccountInformation.Active != false) {
                errors.Add(new ValidationError {
                    Instance = getPlayerAccountInfoCmd.PlayerAccountInformation,
                    ErrorMessage = "บัญชีนี้ได้ถูกยกเลิกไปแล้ว ไม่สามารถยกเลิกซ้ำได้",
                });
            }
        }
    }
}
