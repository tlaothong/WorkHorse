using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.PlayerProfile.Models;

namespace TheS.Casinova.PlayerProfile.Commands
{
    /// <summary>
    /// command เปลี่ยนรหัสผ่าน
    /// </summary>
    public class ChangePasswordCommand
    {
        //input
        /// <summary>
        /// ข้อมูลผู้เล่นที่ต้องการเปลี่ยนรหัสผ่าน
        /// 1.UserName ชื่อผู้เล่น
        /// 2.OldPassword รหัสผ่านเดิม
        /// 3.NewPassword รหัสผ่านที่ต้องการเปลี่ยน
        /// </summary>
        public UserProfile UserProfile { get; set; }
    }
}
