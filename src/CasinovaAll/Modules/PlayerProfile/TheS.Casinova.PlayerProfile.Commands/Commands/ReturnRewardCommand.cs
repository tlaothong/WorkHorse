using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.PlayerProfile.Models;

namespace TheS.Casinova.PlayerProfile.Commands
{
    /// <summary>
    /// แจกงินรางวัลให้ผู้เล่นที่ชนะ
    /// </summary>
    public class ReturnRewardCommand
    {
        //input
        /// <summary>
        /// ข้อมูลผู้เล่นที่จะแจกเงินรางวัล
        /// </summary>
        public UserProfile UserProfile { get; set; }
    }
}
