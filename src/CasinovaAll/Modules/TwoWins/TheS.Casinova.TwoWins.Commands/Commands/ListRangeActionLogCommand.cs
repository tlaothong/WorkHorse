using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.TwoWins.Models;

namespace TheS.Casinova.TwoWins.Commands
{
    /// <summary>
    /// command ดึงข้อมูลสถิติของเกมแบบเป็นช่วง โดยจะแสดงข้อมูลผลผู้ชนะ
    /// </summary>
    public class ListRangeActionLogCommand
    {
        //input
        /// <summary>
        /// ข้อมูลโต๊ะเกมที่ต้องการดูสถิติ
        /// 1.RoundID ทั้งหมดที่ต้องการ
        /// </summary>
        public IEnumerable<RoundWinnerInformation> RoundWinnerInfo { get; set; }

        //output
        /// <summary>
        /// ข้อมูลผลผู้ชนะของเกมแต่ละโต๊ะ
        /// </summary>
        public IEnumerable<ActionLogInformation> RangeActionLog { get; set; }
       
    }
}
