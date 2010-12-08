using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.TwoWins.Models;

namespace TheS.Casinova.TwoWins.Commands
{
    public class ListRangeActionLog
    {
        //input
        /// <summary>
        /// รหัสโต๊ะเกมเริ่มต้น
        /// </summary>
        public int FromRoundID { get; set; }

        /// <summary>
        /// รหัสโตีะเกมสุดท้าย
        /// </summary>
        public int ThruRoundID { get; set; }

        //output
        /// <summary>
        /// ข้อมูลประวัติการลงพนัน
        /// </summary>
        public IEnumerable<ActionLogInformation> ActionLogInformation { get; set; }
    }
}
