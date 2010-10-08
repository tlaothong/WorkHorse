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
        /// จำนวนยอดเงินคงเหลือ
        /// </summary>
        public double Balance { get; set; }
    }
}
