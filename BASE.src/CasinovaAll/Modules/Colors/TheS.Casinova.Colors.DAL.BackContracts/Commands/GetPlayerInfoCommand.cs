using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.TwoWins.Models;

namespace TheS.Casinova.TwoWins.Commands
{
    /// <summary>
    /// ดึงข้อมูลผู้เล่น
    /// </summary>
    public class GetPlayerInfoCommand
    {
        //input
        /// <summary>
        /// ชื่อผู้เล่นที่ต้องการข้อมูล
        /// </summary>
        public string UserName { get; set; }

        //output       
        /// <summary>
        /// ข้อมูลผู้เล่นที่จะได้รับ
        /// </summary>
        public PlayerInformation PlayerInfo { get; set; }
    }
}
