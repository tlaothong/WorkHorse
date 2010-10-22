using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheS.Casinova.PlayerAccount.Commands
{
    /// <summary>
    /// สร้างบัญชีใหม่
    /// </summary>
    public class CreatePlayerAccountCommand
    {
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
        /// หมายเลขตรวจสอบ
        /// </summary>
        public int CVV { get; set; }

        /// <summary>
        /// วันหมดอายุ
        /// </summary>
        public DateTime ExpireDate { get; set; }

        /// <summary>
        /// สถานะการทำงาน
        /// </summary>
        public bool Active { get; set; }
    }
}
