using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.PlayerProfile.Models;

namespace TheS.Casinova.ChipExchange.Commands
{
    /// <summary>
    /// ดึงข้อมูล user profile
    /// </summary>
    public class GetUserProfileCommand
    {
        //input
        /// <summary>
        /// ชื่อผู้เล่น
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// ข้อมูล user profile
        /// </summary>
        public UserProfile UserProfile { get; set; }
    }
}
