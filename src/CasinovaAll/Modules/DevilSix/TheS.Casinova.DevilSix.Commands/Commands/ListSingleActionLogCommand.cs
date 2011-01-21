using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.DevilSix.Models;

namespace TheS.Casinova.DevilSix.Commands
{
    public class ListSingleActionLogCommand
    {
        //input
        /// <summary>
        /// ข้อมูลเพื่อลิสต์ประวัติการลงพนันของโตีะเกมแต่ละโต๊ะตามวันที่ที่ผู้เล่นเลือก
        /// 1. RoundID รหัสโต๊ะเกม
        /// 2. DateTime วันที่ที่ต้องการดู
        /// </summary>
        public BetInformation ActionLogInfo { get; set; }

        //output
        /// <summary>
        /// ข้อมูลประวัติการลงพนัน
        /// </summary>
        public IEnumerable<BetInformation> ActionLogInformation { get; set; }

    }
}
