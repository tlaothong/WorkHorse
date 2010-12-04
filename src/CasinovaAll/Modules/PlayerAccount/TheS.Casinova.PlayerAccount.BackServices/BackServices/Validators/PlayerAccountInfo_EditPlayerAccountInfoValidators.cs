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
    public class PlayerAccountInfo_EditPlayerAccountInfoValidators
        : ValidatorBase<PlayerAccountInformation, EditPlayerAccountCommand>
    {
        private IGetPlayerAccountInfoByAccountType _iGetPlayerAccountInfoByAccountType;

        public PlayerAccountInfo_EditPlayerAccountInfoValidators(IPlayerAccountDataBackQuery dqr)
        {
            _iGetPlayerAccountInfoByAccountType = dqr;
        }

        public override void Validate(PlayerAccountInformation entity, EditPlayerAccountCommand command, ValidationErrorCollection errors)
        {
            GetPlayerAccountInfoByAccountTypeCommand getPlayerAccountByAccountTypeCmd = new GetPlayerAccountInfoByAccountTypeCommand {
                PlayerAccountInfo = new PlayerAccountInformation {
                    UserName = entity.UserName,
                    AccountType = entity.AccountType,
                },
            };

            getPlayerAccountByAccountTypeCmd.PlayerAccountInfo = _iGetPlayerAccountInfoByAccountType.Get(getPlayerAccountByAccountTypeCmd);

            if (getPlayerAccountByAccountTypeCmd.PlayerAccountInfo.Active != true) {
                errors.Add(new ValidationError {
                    Instance = entity,
                    ErrorMessage = "บัญชีนี้ถูกปิดไว้ ไม่สามารถแก้ไขได้",
                });
            }

            switch (entity.AccountType) {
                case "Primary":
                    if (entity.CardType != "CreditCard") {
                        errors.Add(new ValidationError {
                            Instance = entity,
                            ErrorMessage = "บัญชีหลักต้องใช้บัตร Credit card เท่านั้น",
                        });
                    }
                    break;
                case "Secondary":
                    break;
                default:
                    break;
            }
        }
    }
}
