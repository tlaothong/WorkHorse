using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.PlayerProfile.Models;

namespace TheS.Casinova.ChipExchange.Commands
{
    /// <summary>
    /// command ดึงข้อมูลชิพเป็น, ชิพตาย
    /// </summary>
    public class GetPlayerBalanceCommand
    {
        //input
        /// <summary>
        /// ชื่อผู้เล่น
        /// </summary>
        public string UserName { get; set; }

        //output
        /// <summary>
        /// ข้อมูลชิพเป็น-ชิพตาย
        /// </summary>
        public UserProfile ChipsBalanc { get; set; }
    }
}
