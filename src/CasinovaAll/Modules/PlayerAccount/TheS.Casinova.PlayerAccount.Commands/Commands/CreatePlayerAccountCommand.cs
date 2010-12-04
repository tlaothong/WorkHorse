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
        /// ข้อมูลบัญชีที่ผู้เล่นสมัคร
        /// 1.UserName ชื่อผู้เล่น
        /// 2.CardType ประเภทบัญชี
        /// 3.AccountNo หมายเลขบัญชี
        /// 4.CVV รหัสตรวจสอบหมายเลขบัญชี
        /// 5.ExpireDate วันหมดอายุของบัญชี
        /// 6.Active สถานะการทำงาน (Bs ใส่เอง)
        /// </summary>
        public PlayerAccountInformation PlayerAccountInfo{ get; set; }
    }
}
