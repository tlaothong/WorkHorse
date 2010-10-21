using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheS.Casinova.PlayerProfile.Commands
{
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
        /// รหัสผ่านที่ต้องการเปลี่ยน
        /// </summary>
        public string NewPassword { get; set; }
    }
}
