using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.PlayerProfile.Models;

namespace TheS.Casinova.PlayerProfile.Command
{
    /// <summary>
    /// command ตรวจสอบ email ว่ามีอยู่หรือไม่
    /// </summary>
   public class CheckEmailCommand
    {
        //input
        /// <summary>
        /// อีเมลของผู้เล่น
        /// </summary>
        public string Email { get; set; }

        //output
        /// <summary>
        /// ข้อมูลโปรไฟล์ของผู้เล่น
        /// </summary>
        public UserProfile PlayerProfile { get; set; }
    }
}
