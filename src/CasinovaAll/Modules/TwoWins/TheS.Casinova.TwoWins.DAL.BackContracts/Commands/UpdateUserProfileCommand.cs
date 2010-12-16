using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.PlayerProfile.Models;

namespace TheS.Casinova.TwoWins.Commands
{
    /// <summary>
    /// อัพเดทข้อมูลผู้เล่น
    /// </summary>
    public class UpdateUserProfileCommand
    {
        //input
        /// <summary>
        /// ข้อมูลผู้เล่นที่จะอัพเดท
        /// </summary>
        public UserProfile UserProfile { get; set; }
    }
}
