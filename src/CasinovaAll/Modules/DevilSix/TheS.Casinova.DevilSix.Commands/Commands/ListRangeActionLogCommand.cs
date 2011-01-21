using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.DevilSix.Models;

namespace TheS.Casinova.DevilSix.Commands
{
    public class ListRangeActionLogCommand
    {
        //input
        /// <summary>
        /// ข้อมูลเพื่อลิสต์ประวัติการลงพนันของโตีะเกมแต่ละโต๊ะตามช่วงที่ผู้เล่นเลือก
        /// 1. RoundID รหัสโต๊ะเกม
        /// 2. FromBetDateTime วันที่ที่ต้องการเริ่มดู
        /// 3. ThruBetDateTime วันที่สุดท้ายที่ต้องการดู
        /// </summary>
        public BetInformation FromBetDateTime { get; set; }

        public BetInformation ThruBetDateTime { get; set; }

        //output
        /// <summary>
        /// ข้อมูลประวัติการลงพนัน
        /// </summary>
        public IEnumerable<BetInformation> ActionLogInformation { get; set; }
    }
}
