using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.ChipExchange.Models;

namespace TheS.Casinova.ChipExchange.Commands
{
    /// <summary>
    /// command ดึงรหัสคูปอง
    /// </summary>
    public class GetVoucherCodeCommand
    {
        //input
        /// <summary>
        /// ชื่อผู้เล่น
        /// </summary>
        public string UserName { get; set; }

        //output
        /// <summary>
        /// รหัสคูปอง
        /// </summary>
        public VoucherInformation VoucherCode { get; set; }

    }
}
