using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.ChipExchange.Commands;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.ChipExchange.DAL;
using TheS.Casinova.ChipExchange.Models;
using PerfEx.Infrastructure;
using PerfEx.Infrastructure.Validation;

namespace TheS.Casinova.ChipExchange.BackServices.BackExecutors
{
    public class VoucherToBonusChipsExecutor
        : SynchronousCommandExecutorBase<VoucherToBonusChipsCommand>
    {
        private IGetVoucherInfo _iGetVoucherInfo;
        private IGetExchangeSetting _iGetExchangeSetting;
        private IIncreasePlayerBonusChipsByVoucher _iIncreasePlayerBonusChipByVoucher;
        private IUpdateUsedVoucher _iUpdateUsedVoucher;
        private IDependencyContainer _container;

        public VoucherToBonusChipsExecutor(IDependencyContainer container, IChipExchangeDataAccess dac, IChipExchangeDataBackQuery dqr)
        {
            _iGetVoucherInfo = dqr;
            _iGetExchangeSetting = dqr;
            _iIncreasePlayerBonusChipByVoucher = dac;
            _iUpdateUsedVoucher = dac;
            _container = container;
        }

        protected override void ExecuteCommand(VoucherToBonusChipsCommand command)
        {
            ValidationErrorCollection errorValidations = new ValidationErrorCollection();

            VoucherInformation voucherInfo = new VoucherInformation { VoucherCode = command.VoucherCode };

            //ตรวจสอบคูปองมีจริงหรือไม่, คูปองถูกใช้ไปแล้วหรือยัง
            ValidationHelper.Validate(_container, voucherInfo, command, errorValidations);

            if (errorValidations.Any()) {
                throw new ValidationErrorException(errorValidations);
            }

            //ดึงข้อมูลคูปองจากรหัสที่ได้
            GetVoucherInfoCommand getVoucherInfoCmd = new GetVoucherInfoCommand { VoucherCode = command.VoucherCode, };
            getVoucherInfoCmd.VoucherInfo = _iGetVoucherInfo.Get(getVoucherInfoCmd);

            //Get exchange setting
            GetExchangeSettingCommand getExchangeSettingCmd = new GetExchangeSettingCommand { Name = "Exchange1" };
            getExchangeSettingCmd.ExchangeSetting = _iGetExchangeSetting.Get(getExchangeSettingCmd);

            //Update used voucher
                voucherInfo.UserName = getVoucherInfoCmd.VoucherInfo.UserName;
                voucherInfo.VoucherCode = getVoucherInfoCmd.VoucherInfo.VoucherCode;
                voucherInfo.CanUse = false;

            UpdateUsedVoucherCommand updateUsedVoucherCmd = new UpdateUsedVoucherCommand { VoucherInfo = voucherInfo };
            _iUpdateUsedVoucher.ApplyAction(voucherInfo, updateUsedVoucherCmd);

            //Update player bonus chips by exchange rate
            ExchangeInformation exchangeInfo = new ExchangeInformation {
                UserName = command.UserName,
                Amount = getExchangeSettingCmd.ExchangeSetting.VoucherToBonusChipRate * getVoucherInfoCmd.VoucherInfo.Amount,
            };
            _iIncreasePlayerBonusChipByVoucher.ApplyAction(exchangeInfo, command);
        }
    }
}
