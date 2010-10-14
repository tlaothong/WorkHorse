using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.MagicNine.Models;

namespace TheS.Casinova.MagicNine.Commands
{
    /// <summary>
    /// command ลิสต์ข้อมูลผลการลงเดิมพันของผู้เล่น
    /// </summary>
    public class ListBetLogCommand
    {
        //input
        /// <summary>
        /// username ของผู้เล่น
        /// </summary>
        public string UserName { get; set; } 

        /// <summary>
        /// round ที่ต้องการลิสต์ข้อมูลผลการลงเดิมพัน
        /// </summary>
        public int RoundID { get; set; }   

        //ouput
        /// <summary>
        /// ข้อมูลผลการลงเดิมพัน
        /// </summary>
        public IEnumerable<BetInformation> BetInfo { get; set; } 
    }
}
