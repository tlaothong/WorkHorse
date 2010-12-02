using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheS.Casinova.PlayerAccount.Models
{
    /// <summary>
    /// ข้อมูลบัญชีของผู้เล่น
    /// </summary>
    public class PlayerAccountInformation
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
        /// ชื่อเจ้าของบัตร
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// นามสกุลเจ้าของบัตร
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// ประเภทบัญชี
        /// </summary>
        public string AccountType { get; set; }

        /// <summary>
        /// ประเภทบัตร
        /// </summary>
        public string CardType { get; set; }

        /// <summary>
        /// หมายเลขบัญชี
        /// </summary>
        public string AccountNo { get; set; }

        /// <summary>
        /// รหัสตรวจสอบหมายเลขบัญชี
        /// </summary>
        public string CVV { get; set; }

        /// <summary>
        /// วันหมดอายุของบัญชี
        /// </summary>
        public DateTime ExpireDate { get; set; }

        /// <summary>
        /// สถานะการใช้งาน
        /// </summary>
        public bool Active { get; set; }
    }
}
