using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.ChipExchange.Models;
using TheS.Casinova.ChipExchange.Commands;
using PerfEx.Infrastructure.Validation;
using TheS.Casinova.ChipExchange.DAL;

namespace TheS.Casinova.ChipExchange.BackServices.Validators
{
    public class VoucherInfo_VoucherToBonusChipsValidators
        : ValidatorBase<VoucherInformation, VoucherToBonusChipsCommand>
    {
        private IGetVoucherInfo _iGetVoucherInfo;

        public VoucherInfo_VoucherToBonusChipsValidators(IChipExchangeDataBackQuery dqr)
        {
            _iGetVoucherInfo = dqr;
        }

        public override void Validate(VoucherInformation entity, VoucherToBonusChipsCommand command, ValidationErrorCollection errors)
        {
            //ดึงข้อมูลคูปองจากรหัสที่ได้
            GetVoucherInfoCommand getVoucherInfoCmd = new GetVoucherInfoCommand { VoucherCode = command.VoucherInformation.VoucherCode, };
            getVoucherInfoCmd.VoucherInfo = _iGetVoucherInfo.Get(getVoucherInfoCmd);

            if (getVoucherInfoCmd.VoucherInfo == null) {
                errors.Add(new ValidationError {
                    Instance = entity,
                    ErrorMessage = "ไม่มีคูปองที่ระบุมา",
                });
            }
            else if (getVoucherInfoCmd.VoucherInfo.CanUse == false) {
                errors.Add(new ValidationError {
                    Instance = entity,
                    ErrorMessage = "คูปองนี้ถูกใช้ไปแล้ว",
                });
            }                
        }
    }
}
