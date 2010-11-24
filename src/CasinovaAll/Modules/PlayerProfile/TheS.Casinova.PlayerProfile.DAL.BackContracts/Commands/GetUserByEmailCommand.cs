using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.PlayerProfile.Models;

namespace TheS.Casinova.PlayerProfile.Commands
{
    /// <summary>
    /// ดึงข้อมูลผู้เล่นจากอีเมลล์
    /// </summary>
    public class GetUserProfileByEmailCommand
    {
        //input
        /// <summary>
        /// อีเมลล์ที่ต้องการดึงข้อมูลผู้เล่น
        /// </summary>
        public string Email { get; set; }

        //output
        /// <summary>
        /// ข้อมูลผู้เล่นที่ต้องการ
        /// </summary>
        public UserProfile UserProfile { get; set; }
    }
}
