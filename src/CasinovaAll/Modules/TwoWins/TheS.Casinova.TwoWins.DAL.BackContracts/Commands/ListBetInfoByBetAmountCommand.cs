using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.TwoWins.Models;

namespace TheS.Casinova.TwoWins.Commands
{
    /// <summary>
    /// ดึงข้อมูลการลงพนันด้วยจำนวนที่ลงพนัน
    /// </summary>
    public class ListBetInfoByBetAmountCommand
    {
        //input
        /// <summary>
        /// ค่าเงินที่ลงพนัน
        /// </summary>
        public double BetAmount { get; set; }

        //output
        /// <summary>
        /// ข้อมูลการลงพนัน
        /// </summary>
        public IEnumerable<BetInformation> BetInfoList { get; set; }
    }
}
