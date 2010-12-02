using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.PlayerAccount.Models;
using TheS.Casinova.PlayerAccount.Commands;
using PerfEx.Infrastructure.Validation;
using TheS.Casinova.PlayerAccount.DAL;

namespace TheS.Casinova.PlayerAccount.BackServices.Validators
{
    public class PlayerAccountInfo_CreatePlayerAccountValidators
        : ValidatorBase<PlayerAccountInformation, CreatePlayerAccountCommand>
    {
        IGetPlayerAccountInfo _iGetPlayerAccountInfo;

        public PlayerAccountInfo_CreatePlayerAccountValidators(IPlayerAccountDataBackQuery dqr)
        {
            _iGetPlayerAccountInfo = dqr;
        }

        public override void Validate(PlayerAccountInformation entity, CreatePlayerAccountCommand command, ValidationErrorCollection errors)
        {
            GetPlayerAccountCommand getPlayerAccountInfoCmd = new GetPlayerAccountCommand {
                PlayerAccountInfoInput = new PlayerAccountInformation {
                    UserName = entity.UserName,
                }
            };

            getPlayerAccountInfoCmd.PlayerAccountInfo = _iGetPlayerAccountInfo.Get(getPlayerAccountInfoCmd);

            if (getPlayerAccountInfoCmd.PlayerAccountInfo != null) {
                errors.Add(new ValidationError {
                    Instance = entity,
                    ErrorMessage = "บัญชีของผู้เล่นนี้เคยถูกสร้างแล้ว",
                });
            }

            if (entity.CardType != "CreditCard") {
                errors.Add(new ValidationError {
                    Instance = entity,
                    ErrorMessage = "บัญชีหลักต้องใช้บัตร Credit card เท่านั้น",
                });
            }
        }
    }
}
