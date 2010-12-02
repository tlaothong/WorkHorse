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
        IGetPlayerAccountInfoByAccountType _iGetPlayerAccountInfoByAccountType;

        public PlayerAccountInfo_CreatePlayerAccountValidators(IPlayerAccountDataBackQuery dqr)
        {
            _iGetPlayerAccountInfoByAccountType = dqr;
        }

        public override void Validate(PlayerAccountInformation entity, CreatePlayerAccountCommand command, ValidationErrorCollection errors)
        {
            GetPlayerAccountInfoByAccountTypeCommand getPlayerAccountInfoCmd = new GetPlayerAccountInfoByAccountTypeCommand {
                PlayerAccountInfo = new PlayerAccountInformation {
                    UserName = entity.UserName,
                    AccountType = "Primary",
                }
            };

            getPlayerAccountInfoCmd.PlayerAccountInformation = _iGetPlayerAccountInfoByAccountType.Get(getPlayerAccountInfoCmd);

            if (getPlayerAccountInfoCmd.PlayerAccountInformation != null) {
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
