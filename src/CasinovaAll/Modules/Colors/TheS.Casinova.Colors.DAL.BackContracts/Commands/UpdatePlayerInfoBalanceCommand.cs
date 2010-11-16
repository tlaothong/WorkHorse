using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.Colors.Models;

namespace TheS.Casinova.Colors.Commands
{
    /// <summary>
    /// อัพเดทยอดเงินของผู้เล่น
    /// </summary>
    public class UpdatePlayerInfoBalanceCommand
    {
        //input
        /// <summary>
        /// ชื่อผู้เล่นทีจะอัพเดทยอดเงิน
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// ยอดรวมชิฟตาย
        /// </summary>
        public double NonRefundable { get; set; }

        /// <summary>
        /// ยอดรวมชิฟเป็น
        /// </summary>
        public double Refundable { get; set; }
    }
}
