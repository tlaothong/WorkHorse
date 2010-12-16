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
        /// ข้อมูลรหัสโต๊ะเกมที่ต้องการดูสถิติ
        /// 1. FromRoundID รหัสโต๊ะเกมเริ่มต้น
        /// 2. ThruRoundID รหัสโต๊ะเกมสุดท้าย
        /// </summary>
        public ActionLogInformation ActionLogInfo { get; set; }

        //public RoundInformation FromRoundInfo { get; set; }
        //public RoundInformation ThruRoundInfo { get; set; }

        //output
        /// <summary>
        /// ข้อมูลผลผู้ชนะของเกมแต่ละโต๊ะ
        /// </summary>
        public IEnumerable<ActionLogInformation> RangeActionLog { get; set; }

        /// <summary>
        /// ข้อมูลจำนวนเงินรวมทั้งหมดและจำนวนมือทั้งหมด
        /// </summary>
        public RoundInformation RoundInformation { get; set; }
       
    }
}
