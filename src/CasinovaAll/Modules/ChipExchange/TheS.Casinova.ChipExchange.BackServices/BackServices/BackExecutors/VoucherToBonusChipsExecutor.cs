using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.ChipExchange.Commands;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.ChipExchange.DAL;
using TheS.Casinova.ChipExchange.Models;

namespace TheS.Casinova.ChipExchange.BackServices.BackExecutors
{
    public class VoucherToBonusChipsExecutor
        : SynchronousCommandExecutorBase<VoucherToBonusChipsCommand>
    {
        private IGetVoucherInfo _iGetVoucherInfo;
        private IGetExchangeSetting _iGetExchangeSetting;
        private IIncreasePlayerBonusChipsByVoucher _iIncreasePlayerBonusChipByVoucher;
        private IUpdateUsedVoucher _iUpdateUsedVoucher;

        public VoucherToBonusChipsExecutor(IChipExchangeDataAccess dac, IChipExchangeDataBackQuery dqr)
        {
            _iGetVoucherInfo = dqr;
            _iGetExchangeSetting = dqr;
            _iIncreasePlayerBonusChipByVoucher = dac;
            _iUpdateUsedVoucher = dac;
        }

        protected override void ExecuteCommand(VoucherToBonusChipsCommand command)
        {
            //ดึงข้อมูลคูปองจากรหัสที่ได้
            GetVoucherInfoCommand getVoucherInfoCmd = new GetVoucherInfoCommand { VoucherCode = command.VoucherCode, };
            getVoucherInfoCmd.VoucherInfo = _iGetVoucherInfo.Get(getVoucherInfoCmd);

            //เพิ่มชิปตายให้ผู้เล่นหาก รหัสคูปองถูกต้อง และยังไม่ถูกใช้
            if ((getVoucherInfoCmd.VoucherInfo != null) || (getVoucherInfoCmd.VoucherInfo.CanUse != true)) {
                //Get exchange setting
                GetExchangeSettingCommand getExchangeSettingCmd = new GetExchangeSettingCommand { Name = "Exchange1" };
                getExchangeSettingCmd.ExchangeSetting = _iGetExchangeSetting.Get(getExchangeSettingCmd);

                //Update used voucher
                VoucherInformation voucherInfo = new VoucherInformation { UserName = getVoucherInfoCmd.VoucherInfo.UserName, VoucherCode = getVoucherInfoCmd.VoucherInfo.VoucherCode };
                UpdateUsedVoucherCommand updateUsedVoucherCmd = new UpdateUsedVoucherCommand { VoucherInfo = voucherInfo };
                _iUpdateUsedVoucher.ApplyAction(voucherInfo, updateUsedVoucherCmd);

                //Update player bonus chips by exchange rate
                ExchangeInformation exchangeInfo = new ExchangeInformation { 
                    UserName = command.UserName, 
                    Amount = getExchangeSettingCmd.ExchangeSetting.MoneyToBonusChipRate * getVoucherInfoCmd.VoucherInfo.Amount,
                };                                
                _iIncreasePlayerBonusChipByVoucher.ApplyAction(exchangeInfo, command);                
            }
            else {
                Console.WriteLine("######################### Invalid The Voucher code ##############################");
            }
        }
    }
}
