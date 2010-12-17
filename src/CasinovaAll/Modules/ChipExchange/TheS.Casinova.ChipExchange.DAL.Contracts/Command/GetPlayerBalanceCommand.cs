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
        /// ข้อมูลเพื่อดึงจำนวนชิพทั้งหมด
        /// 1. UserName ชื่อผู้เล่น
        /// </summary>
        public UserProfile UserProfie { get; set; }

        //output
        /// <summary>
        /// ข้อมูลชิพเป็น-ชิพตาย
        /// </summary>
        public UserProfile ChipsBalance { get; set; }
    }
}
