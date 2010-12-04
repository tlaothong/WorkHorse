using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.PlayerAccount.Models;
using TheS.Casinova.PlayerAccount.Commands;
using PerfEx.Infrastructure.Validation;
using TheS.Casinova.PlayerAccount.DAL;
using TheS.Casinova.PlayerProfile.Models;

namespace TheS.Casinova.PlayerAccount.BackServices.Validators
{
    public class PlayerAccountInfo_ActivatePlayerAccountValidators
        : ValidatorBase<PlayerAccountInformation, ActivatePlayerAccountCommand>
    {
        private IGetPlayerAccountInfoByAccountType _iGetPlayerAccountInfoByAccountType;

        public PlayerAccountInfo_ActivatePlayerAccountValidators(IPlayerAccountDataBackQuery dqr)
        {
            _iGetPlayerAccountInfoByAccountType = dqr;
        }

        public override void Validate(PlayerAccountInformation entity, ActivatePlayerAccountCommand command, ValidationErrorCollection errors)
        {
            GetPlayerAccountInfoByAccountTypeCommand getPlayerAccountInfoCmd = new GetPlayerAccountInfoByAccountTypeCommand {
                PlayerAccountInfo = entity,
            };

            getPlayerAccountInfoCmd.PlayerAccountInfo = _iGetPlayerAccountInfoByAccountType.Get(getPlayerAccountInfoCmd);

            if (getPlayerAccountInfoCmd.PlayerAccountInfo.Active == true) {
                errors.Add(new ValidationError {
                    Instance = getPlayerAccountInfoCmd.PlayerAccountInfo,
                    ErrorMessage = "บัญชีนี้ได้ถูกยกเลิกไปแล้ว ไม่สามารถยกเลิกซ้ำได้",
                });
            }
        }
    }
}
