using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.PlayerProfile.Models;

namespace TheS.Casinova.PlayerProfile.Command
{
    /// <summary>
    /// command ดึงข้อมูลรหัสผ่านของผู้เล่น
    /// </summary>
    public class GetPlayerPasswordCommand
    {
        //input
        /// <summary>
        /// ชื่อผู้เล่น
        /// </summary>
        public string UserName { get; set; }

        //output
        /// <summary>
        /// ข้อมูลโปรไฟล์ของผู้เล่น
        /// </summary>
        public UserProfile PlayerProfile { get; set; }
    }
}
