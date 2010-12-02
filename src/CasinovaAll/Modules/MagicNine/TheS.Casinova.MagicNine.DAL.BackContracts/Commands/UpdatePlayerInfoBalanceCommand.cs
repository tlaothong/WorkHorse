using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.PlayerProfile.Models;

namespace TheS.Casinova.MagicNine.Commands
{
    /// <summary>
    /// อัพเดทชิฟของผู้เล่น
    /// </summary>
    public class UpdatePlayerInfoBalanceCommand 
    {        
        //input
        /// <summary>
        /// ข้อมูลผู้เล่นที่จะอัพเดทชิฟ
        /// </summary>
        public UserProfile UserProfile { get; set; }
    }
}
