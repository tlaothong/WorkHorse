using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.PlayerAccount.Models;

namespace TheS.Casinova.PlayerAccount.Commands
{
    /// <summary>
    /// command สร้างข้อมูลบัญชีของผู้เล่น
    /// </summary>
    public class CreatePlayerAccountCommand
    {
        //input
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
        public string AccountNo { get; set; }

        /// <summary>
        /// รหัสตรวจสอบหมายเลขบัญชี
        /// </summary>
        public int CVV { get; set; }

        /// <summary>
        /// วันหมดอายุของบัญชี
        /// </summary>
        public DateTime ExpireDate { get; set; }

        /// สถานะการทำงาน
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// ข้อมูลบัญชีที่ผู้เล่นสมัคร
        /// 1.UserName ชื่อผู้เล่น
        /// 2.AccountType ประเภทบัญชี
        /// 3.AccountNo หมายเลขบัญชี
        /// 4.CVV รหัสตรวจสอบหมายเลขบัญชี
        /// 5.ExpireDate วันหมดอายุของบัญชี
        /// 6.FirstName ชื่อ
        /// 7.LastName สกุล
        /// </summary>
        public PlayerAccountInformation PlayerAccountInfo { get; set; }
    }
}
