using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.Validation;
using TheS.Casinova.ChipExchange.Models;
using TheS.Casinova.ChipExchange.Commands;
using TheS.Casinova.ChipExchange.DAL;
using TheS.Casinova.PlayerProfile.Models;

namespace TheS.Casinova.ChipExchange.Validators
{
    public class VoucherInformation_PayVoucherValidators
         : ValidatorBase<VoucherInformation, PayVoucherCommand>
    {
        private IGetPlayerBalance _iGetPlayerBalance;

        public VoucherInformation_PayVoucherValidators(IChipsExchangeModuleDataQuery dqr)
        {
            _iGetPlayerBalance = dqr;
        }
        
        public override void Validate(VoucherInformation entity, PayVoucherCommand command, ValidationErrorCollection errors)
        {
            double chipsTotal; //จำนวนชิพทั้งหมดที่ผู้เล่นมี
            GetPlayerBalanceCommand playerBalanceCmd;

            playerBalanceCmd = new GetPlayerBalanceCommand {
                UserProfie = new UserProfile { 
                    UserName = command.VoucherInformation.UserName
                }
            };

            playerBalanceCmd.ChipsBalance = _iGetPlayerBalance.Get(playerBalanceCmd);
            chipsTotal = playerBalanceCmd.ChipsBalance.NonRefundable + playerBalanceCmd.ChipsBalance.Refundable;

            //ตรวจสอบข้อมูลจำนวนเงิน
            if (entity.Amount < 1) {
                errors.Add(new ValidationError {
                    Instance = entity,
                    ErrorMessage = "ค่า Amount ไม่ถูกต้อง",
                });
            }

            //ตรวจสอบจำนวนเงินที่มี
            if (chipsTotal < entity.Amount) {
                errors.Add(new ValidationError {
                    Instance = entity,
                    ErrorMessage = "มีจำนวนเงินไม่เพียงพอ",
                });
            }
        }
    }
}
