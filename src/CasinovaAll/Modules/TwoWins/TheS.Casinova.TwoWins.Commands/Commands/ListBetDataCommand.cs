using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.TwoWins.Models;

namespace TheS.Casinova.TwoWins.Commands
{
    /// <summary>
    /// ดึงข้อมูลสถิติการลงเดิมพันในเกม
    /// </summary>
    public class ListBetDataCommand
    {
        //input
        /// <summary>
        /// ข้อมูลโต๊ะเกมที่ต้องการดูสถิติ
        /// 1.RoundID ทั้งหมดที่ต้องการ
        /// </summary>
        public IEnumerable<ActionLogInformation> ActionLogInfo { get; set; }

        //output
        /// <summary>
        /// ข้อมูลประวัติการลงพนัน
        /// </summary>
        public IEnumerable<ActionLogInformation> ActionLogInformation { get; set; }
    }
}
