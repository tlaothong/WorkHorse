using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.ChipExchange.Models;

namespace TheS.Casinova.ChipExchange.Commands
{
    /// <summary>
    /// อัพเดทสถานะของคูปองเมื่อถูกใช้
    /// </summary>
    public class UpdateUsedVoucherCommand
    {
        //input
        /// <summary>
        /// คูปองที่ถูกใช้แล้ว
        /// </summary>
        public VoucherInformation VoucherInfo { get; set; }
    }
}
