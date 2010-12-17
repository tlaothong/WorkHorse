using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.PlayerAccount.Models;

namespace TheS.Casinova.PlayerAccount.Commands
{
    /// <summary>
    /// ยกเลิกบัญชีของผู้เล่น
    /// </summary>
    public class CancelPlayerAccountCommand
    {
        //input
        /// <summary>
        /// ข้อมูลบัญชีผู้เล่นที่จะยกเลิก
        /// 1.UserName ชื่อผู้เล่น
        /// 2.AccountType บัญชีที่ต้องการจะยกเลิก
        /// </summary>
        public PlayerAccountInformation PlayerAccountInfo { get; set; }

        public string Password { get; set; }
    }
}
