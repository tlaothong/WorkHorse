using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.MagicNine.Models;

namespace TheS.Casinova.MagicNine.Commands
{
    /// <summary>
    /// command ลงพนันด้วยผู้เล่นเอง
    /// </summary>
    public class SingleBetCommand
    {
        //input
        /// <summary>
        /// ข้อมูลการลง้เดิมพัน
        /// 1. RoundID รหัสโต๊ะเกมที่ลงพนัน,
        /// 2. UserName ชื่อผู้เล่นที่ลงพนัน
        /// 3. BetTrackingID รหัสตรวจสอบการลงพนัน(Ws ใส่)
        /// </summary>
        public BetInformation BetInfo { get; set; }

        //output
        /// <summary>
        /// รหัสสำหรับตรวจสอบ
        /// </summary>
        public Guid TrackingID { get; set; }
    }
}
