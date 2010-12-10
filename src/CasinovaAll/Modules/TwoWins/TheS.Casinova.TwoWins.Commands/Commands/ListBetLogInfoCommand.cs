using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.TwoWins.Models;

namespace TheS.Casinova.TwoWins.Commands
{
    /// <summary>
    /// command ดึงข้อมูลการลงเดิมพันของผู้เล่นที่เคยเล่นไว้ในโต๊ะเกม
    /// </summary>
    public class ListBetLogInfoCommand
    {
        //input
        /// <summary>
        /// ข้อมูลเพื่อลิสต์ข้อมูลการลงพนันที่ผุ้เล่นเคยลงไว้
        /// 1.UserName ชื่อผู้เล่น
        /// 2.RoundID รหัสโต๊ะเกม
        /// </summary>
        public BetInformation BetInfo { get; set; }

        //ouput
        /// <summary>
        /// ข้อมูลการลงพนันของผู้เล่น
        /// </summary>
        public IEnumerable<BetInformation> BetInformation { get; set; }
    }
}
    