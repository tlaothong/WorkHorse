using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.PlayerAccount.Models;

namespace TheS.Casinova.PlayerAccount.Commands
{
    /// <summary>
    /// command แก้ไขบัญชีของผู้เล่น
    /// </summary>
    public class EditPlayerAccountCommand
    { 
        /// <summary>
        /// ข้อมูลบัญชีที่ต้องการแก้ไข
        /// 1.UserName ชื่อผู้เล่น
        /// 2.AccountType ประเภทบัญชี
        /// 3.AccountNo หมายเลขบัญชี
        /// 4.CVV รหัสตรวจสอบหมายเลขบัญชี
        /// 5.ExpireDate วันหมดอายุของบัตร
        /// 6.CardType ประเภทบัตร
        /// </summary>
        public PlayerAccountInformation PlayerAccountInfo { get; set; }

    }
}
