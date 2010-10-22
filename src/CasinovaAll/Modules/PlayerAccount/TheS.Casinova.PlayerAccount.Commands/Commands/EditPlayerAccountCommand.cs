using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheS.Casinova.PlayerAccount.Commands
{
    /// <summary>
    /// แก้ไขข้อมูลบัญชี
    /// </summary>
    public class EditPlayerAccountCommand
    {
        /// <summary>
        /// รหัสบัญชีของผู้เล่น
        /// </summary>
        public int PlayerAccoundID { get; set; }

        /// <summary>
        /// ชื่อผู้เล่น
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// ประเภทบัญชี
        /// </summary>
        public string AccountType { get; set; }

        /// <summary>
        /// หมายเลขบัญชี
        /// </summary>
        public int AccountNo { get; set; }

        /// <summary>
        /// รหัสตรวจสอบหมายเลขบัญชี
        /// </summary>
        public int CVV { get; set; }

        /// <summary>
        /// วันหมดอายุของบัญชี
        /// </summary>
        public DateTime ExpireDate { get; set; }
    }
}
