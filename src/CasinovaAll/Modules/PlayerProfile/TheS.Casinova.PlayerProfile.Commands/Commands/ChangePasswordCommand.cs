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
        /// ชื่อของผู้เล่น
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// รหัสผ่านเดิม
        /// </summary>
        public string OldPassword { get; set; }

        /// <summary>
        /// ข้อมูลผู้เล่นที่ต้องการเปลี่ยนรหัสผ่าน
        /// 1.UserName ชื่อผู้เล่น
        /// 2.OldPassword รหัสผ่านเดิม
        /// </summary>
        public UserProfile UserProfile { get; set; }

        /// <summary>
        /// รหัสผ่านที่ต้องการเปลี่ยน
        /// </summary>
        public string NewPassword { get; set; }
    }
}
