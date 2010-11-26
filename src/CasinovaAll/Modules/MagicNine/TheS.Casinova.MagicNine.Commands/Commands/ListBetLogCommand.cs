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
        /// 1. RoundID รอบของโต๊ะที่ลงพนัน
        /// 2. UserName ชื่อผู้เล่นที่ลงพนัน
        /// </summary>
        public BetInformation BetInfo { get; set; }

        //output
        /// <summary>
        /// ข้อมูลการลงพนันทั้งหมด
        /// </summary>
        public IEnumerable<BetInformation> BetInformation { get; set; }
    }
}
