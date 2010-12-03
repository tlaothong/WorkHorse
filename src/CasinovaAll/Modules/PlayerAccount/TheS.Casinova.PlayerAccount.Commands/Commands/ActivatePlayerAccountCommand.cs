using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.PlayerAccount.Models;

namespace TheS.Casinova.PlayerAccount.Commands
{
    /// <summary>
    /// เปิดใช้งานบัญชีที่ถูกยกเลิกไว้
    /// </summary>
    public class ActivatePlayerAccountCommand
    {
        //input
        /// <summary>
        /// ข้อมูลบัญชีที่ต้องการเปิดใช้งาน
        /// 1.UserName
        /// 2.AccountType
        /// </summary>
        public PlayerAccountInformation PlayerAccountInfo { get; set; }

        public string Password { get; set; }
    }
}
