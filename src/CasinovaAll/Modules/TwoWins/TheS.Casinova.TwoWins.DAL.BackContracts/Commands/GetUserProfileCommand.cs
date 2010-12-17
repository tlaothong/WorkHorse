using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.PlayerProfile.Models;

namespace TheS.Casinova.TwoWins.Commands
{
    /// <summary>
    /// ดึงข้อมูลของผู้
    /// </summary>
    public class GetUserProfileCommand
    {
        //input
        /// <summary>
        /// ชื่อผู้เล่นที่จะดึงข้อมูล
        /// </summary>
        public string UserName { get; set; }

        //output
        /// <summary>
        /// ข้อมูลของผู้เล่นที่ต้องการ
        /// </summary>
        public UserProfile UserProfile { get; set; }
    }
}
