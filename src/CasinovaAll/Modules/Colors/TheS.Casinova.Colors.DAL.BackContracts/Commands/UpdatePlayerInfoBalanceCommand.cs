using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.Colors.Models;
using TheS.Casinova.PlayerProfile.Models;

namespace TheS.Casinova.Colors.Commands
{
    /// <summary>
    /// อัพเดทยอดเงินของผู้เล่น
    /// </summary>
    public class UpdatePlayerInfoBalanceCommand
    {
        //input
        /// <summary>
        /// ข้อมูลผู้เล่นที่จะหักเงิน
        /// 1.UserName ชื่อผู้เล่นทีจะอัพเดทยอดเงิน
        /// 2.NonRefundable ยอดรวมชิฟตาย
        /// 3.Refundable ยอดรวมชิฟเป็น
        /// </summary>
        public UserProfile UserProfile { get; set; }
    }
}
