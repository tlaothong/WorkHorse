using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.TwoWins.Models;

namespace TheS.Casinova.TwoWins.Commands
{
    /// <summary>
    /// ดึงข้อมูลการลงพนันทั้งหมดของโต๊ะเกม
    /// </summary>
    public class ListBetInfoByRoundIDCommand
    {
        //input
        /// <summary>
        /// รหัสโต๊ะเกมที่ต้่องการข้อมูลการลงพนัน
        /// </summary>
        public int RoundID { get; set; }

        //output
        /// <summary>
        /// ข้อมูลการลงพนันทั้งหมดของโต๊ะเกมที่ต้องการ
        /// </summary>
        public IEnumerable<BetInformation> BetInfoList { get; set; }
    }
}
