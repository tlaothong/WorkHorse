using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheS.Casinova.ChipExchange.Commands
{
    /// <summary>
    /// command ซื้อคูปองด้วยชิพ
    /// </summary>
    public class PayVoucherCommand
    {
        //input
        /// <summary>
        /// ชื่อผู้เล่น
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// จำนวนเงิน
        /// </summary>
        public double Amount { get; set; }
    }
}
