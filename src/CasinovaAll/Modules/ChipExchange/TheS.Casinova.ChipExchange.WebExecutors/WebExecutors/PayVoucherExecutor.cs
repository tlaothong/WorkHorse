using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.ChipExchange.Commands;
using TheS.Casinova.ChipExchange.BackServices;
using TheS.Casinova.ChipExchange.DAL;

namespace TheS.Casinova.ChipExchange.WebExecutors
{
    /// <summary>
    /// ซื้อคูปอง
    /// </summary>
   public class PayVoucherExecutor
   : SynchronousCommandExecutorBase<PayVoucherCommand>
    {
        private IPayVoucher _iPayVoucher;
        private IGetPlayerBalance _iGetPlayerBalance;

        public PayVoucherExecutor(IChipsExchangeModuleBackService dac, IChipsExchangeModuleDataQuery dqr)
        {
            _iPayVoucher = dac;
            _iGetPlayerBalance = dqr;
        }

        protected override void ExecuteCommand(PayVoucherCommand command)
        {
            double totalChipsBalance;   //จำนวนชิพทั้งหมด

            GetPlayerBalanceCommand cmd_PlayerBalance = new GetPlayerBalanceCommand { 
                UserName = command.UserName
            };

            cmd_PlayerBalance.ChipsBalance = _iGetPlayerBalance.Get(cmd_PlayerBalance);
            totalChipsBalance = cmd_PlayerBalance.ChipsBalance.NonRefundable + cmd_PlayerBalance.ChipsBalance.Refundable;
            
            //ตรวจสอบจำนวนชิพทั้งหมดว่าเพียงพอหรือไม่
            if (totalChipsBalance < command.Amount) {
                Console.WriteLine("จำนวนชิพไม่เพียงพอที่จะสามารถซื้อคูปองได้");
            }
            else {
                //TODO: Generate trackingID
                _iPayVoucher.PayVoucher(command);
            }

        }
    }
}
