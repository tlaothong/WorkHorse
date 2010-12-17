using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.PlayerProfile.Models;

namespace TheS.Casinova.PlayerProfile.Commands
{
    /// <summary>
    /// ยืนยันการสมัครสมาชิก
    /// </summary>
    public class VerifyUserCommand
    {
        /// <summary>
        /// ข้อมูลผู้เล่นที่จะยืนยันการสมัคร
        /// 1.UserName ชื่อผู้เล่น
        /// 2.VerifyCode รหัสยืนยัน
        /// </summary>
        public UserProfile UserProfile { get; set; }
    }
}
