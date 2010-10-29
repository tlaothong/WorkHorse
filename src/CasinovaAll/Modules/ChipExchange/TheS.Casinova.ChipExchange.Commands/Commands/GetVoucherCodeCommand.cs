using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheS.Casinova.ChipExchange.Commands
{
    /// <summary>
    /// command ดึงหมายเลขคูปอง
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
        /// หมายเลขคูปอง
        /// </summary>
        public string VoucherCode { get; set; }

    }
}
