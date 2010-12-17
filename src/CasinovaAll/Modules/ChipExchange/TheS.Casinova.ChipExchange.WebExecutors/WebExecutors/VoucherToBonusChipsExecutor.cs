using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.ChipExchange.Commands;
using TheS.Casinova.ChipExchange.BackServices;
using TheS.Casinova.ChipExchange.DAL;
using TheS.Casinova.ChipExchange.Command;

namespace TheS.Casinova.ChipExchange.WebExecutors
{
    /// <summary>
    /// แลกคูปองเป็นชิพตาย
    /// </summary>
    public class VoucherToBonusChipsExecutor
    : SynchronousCommandExecutorBase<VoucherToBonusChipsCommand>
    {
        private IVoucherToBonusChips _iVoucherToBonusChips;
        private IGetVoucherInfo _iGetVoucherInfo;

        public VoucherToBonusChipsExecutor(IChipsExchangeModuleBackService dac, IChipsExchangeModuleDataQuery dqr)
        {
            _iVoucherToBonusChips = dac;
            _iGetVoucherInfo = dqr;
        }

        protected override void ExecuteCommand(VoucherToBonusChipsCommand command)
        {
            bool voucherCanUse;  //สถานะการใช้งานคูปอง

            #region Voucher validation

            //ดึงข้อมูลคูปอง
            GetVoucherInfoCommand cmd_VoucherInfo = new GetVoucherInfoCommand {
                VoucherCode = command.VoucherInformation.VoucherCode
            };

            cmd_VoucherInfo.VoucherInfo = _iGetVoucherInfo.Get(cmd_VoucherInfo);

            //ตรวจสอบว่ามีคูปองนี้หรือไม่
            if (cmd_VoucherInfo.VoucherInfo == null) {
                Console.WriteLine("ไม่มีหมายเลขคูปองนี้");
            }
            else {

                voucherCanUse = cmd_VoucherInfo.VoucherInfo.CanUse;

                //ตรวจสอบการใช้งานของคูปอง ว่าสามารถใช้งานได้หรือไม่
                if (voucherCanUse == false) {
                    Console.WriteLine("คูปองนี้ไม่สามารถใช้งานได้");
                }
                else {
                    //TODO: Generate trackingID
                    _iVoucherToBonusChips.VoucherToBonusChips(command);
                }
            }

            #endregion Voucher validation
        }
    }
}
