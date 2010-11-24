using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheS.Casinova.PlayerProfile.Commands
{
    public class ChangeEmailCommand
    {
        //input
        /// <summary>
        /// ชื่อของผู้เล่น
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// อีเมลล์เดิมของผู้เล่น
        /// </summary>
        public string OldEmail { get; set; }
        
        /// <summary>
        /// อีเมลล์ใหม่ของผู้เล่น
        /// </summary>
        public string NewEmail { get; set; }
    }
}
