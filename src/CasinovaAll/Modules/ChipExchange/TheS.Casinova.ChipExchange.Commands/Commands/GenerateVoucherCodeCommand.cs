using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheS.Casinova.ChipExchange.Commands
{
    /// <summary>
    /// สร้างรหัสคูปอง
    /// </summary>
    public class GenerateVoucherCodeCommand
    {
        //input
        /// <summary>
        /// จำนวนเงินที่ต้องการซื้อคูปอง
        /// </summary>
        public int Amount { get; set; }

        //output
        /// <summary>
        /// รหัสคูปอง
        /// </summary>
        public string VoucherCode { get; set; }
    }
}
