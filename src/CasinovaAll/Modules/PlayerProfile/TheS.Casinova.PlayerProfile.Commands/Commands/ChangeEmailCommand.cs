using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.PlayerProfile.Models;

namespace TheS.Casinova.PlayerProfile.Commands
{
    public class ChangeEmailCommand
    {
        //input 
        /// <summary>
        /// ข้อมูลผู้เล่นที่ต้องการเปลี่ยนอีเมลล์
        /// 1.UserName ชื่อผู้เล่น
        /// 2.Email อีเมลล์เดิมสำหรับยืนยัน
        /// 3.Password รหัสผ่าน
        /// 4.อีเมลล์ใหม่ของผู้เล่น
        /// </summary>
        public UserProfile UserProfile { get; set; }
    }
}
