using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.MagicNine.Models;

namespace TheS.Casinova.MagicNine.Commands
{
    /// <summary>
    /// ดึงข้อมูลการลงพนันทั้งหมดในโต๊ะเกมที่ผู้เล่นลงพนันไว้
    /// </summary>
    public class ListBetLogCommand
    {
        //input

        /// <summary>
        /// โต๊ะเกมที่ลงพนัน
        /// </summary>
        public int RoundID { get; set; }

        /// <summary>
        /// ชื่อผู้เล่นที่ลงพนัน
        /// </summary>
        public string UserName { get; set; }

        //output

        /// <summary>
        /// ข้อมูลการลงพนันทั้งหมด
        /// </summary>
        public IEnumerable<BetInformation> BetInformations { get; set; }
    }
}
