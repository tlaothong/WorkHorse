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
        /// ชื่อผู้เล่นที่จะยกเลิกบัญชี
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// รหัสบัญชีที่จะยกเลิก
        /// </summary>
        public string CardType { get; set; }

        /// <summary>
        /// ข้อมูลบัญชีผู้เล่นที่จะยกเลิก
        /// 1.UserName ชื่อผู้เล่น
        /// 2.AccountType บัญชีที่ต้องการจะยกเลิก
        /// </summary>
        public PlayerAccountInformation PlayerAccountInfo { get; set; }

        /// <summary>
        /// รหัสผ่านยืนยันการยกเลิกบัญชี
        /// </summary>
        public string Password { get; set; }
    }
}
