using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.ChipExchange.Commands;
using TheS.Casinova.ChipExchange.Models;
using PerfEx.Infrastructure.Validation;
using TheS.Casinova.ChipExchange.DAL;
using TheS.Casinova.ChipExchange.Command;
using TheS.Casinova.PlayerProfile.Models;

namespace TheS.Casinova.ChipExchange.Validators
{
    public class ExchangeInformation_ChipsToBonusChipsValidators
         : ValidatorBase<ExchangeInformation, ChipsToBonusChipsCommand>
    {
         private IGetPlayerBalance _iGetPlayerBalance;
        private IGetMultiLevelNetworkInfo _iGetBonusPoint;

        public ExchangeInformation_ChipsToBonusChipsValidators(IChipsExchangeModuleDataQuery dqr)
        {
            _iGetPlayerBalance = dqr;
            _iGetBonusPoint = dqr;
        }

        public override void Validate(ExchangeInformation entity, ChipsToBonusChipsCommand command, ValidationErrorCollection errors)
        {

            //ตรวจสอบจำนวนเงิน
            if (entity.Amount < 1) {
                errors.Add(new ValidationError {
                    Instance = entity,
                    ErrorMessage = "ค่า Amount ไม่ถูกต้อง",
                });
            }

            #region Check bonus point

            //ดึงข้อมูลจำนวนโบนัส
            GetMultiLevelNetworkInfoCommand cmd_BonusPoint = new GetMultiLevelNetworkInfoCommand {
                UserName = entity.UserName
            };

            //จำนวนโบนัส
            cmd_BonusPoint.MultiLevelNetwork = _iGetBonusPoint.Get(cmd_BonusPoint);

            if (cmd_BonusPoint.MultiLevelNetwork != null) {

                //ตรวจสอบจำนวนโบนัสว่่าเพียงพอที่จะแลกชิพตายหรือไม่
                if (entity.Amount > cmd_BonusPoint.MultiLevelNetwork.Bonus) {
                    errors.Add(new ValidationError {
                        Instance = entity,
                        ErrorMessage = "มีจำนวนโบนัสไม่เพียงพอ",
                    });
                }
            }

            #endregion Check bonus point

            #region Check chips amount

            //ดึงข้อมูลจำนวนชิพเป็น
            GetPlayerBalanceCommand cmd_Balance = new GetPlayerBalanceCommand {
                ChipsBalance = new UserProfile { 
                    UserName = entity.UserName
                }
            };

            //จำนวนชิพเป็น
            cmd_Balance.UserProfie = _iGetPlayerBalance.Get(cmd_Balance);

            if (cmd_Balance.UserProfie != null) {

                //ตรวจสอบจำนวนโบนัสว่่าเพียงพอที่จะแลกชิพตายหรือไม่
                if (entity.Amount > cmd_Balance.UserProfie.Refundable) {
                    errors.Add(new ValidationError {
                        Instance = entity,
                        ErrorMessage = "มีจำนวนชิพเป็นไม่เพียงพอ",
                    });
                }
            }

            #endregion Check chips amount
        }
    }
}
