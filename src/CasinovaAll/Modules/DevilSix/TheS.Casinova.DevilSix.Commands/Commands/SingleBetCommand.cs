using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.DevilSix.Models;


namespace TheS.Casinova.DevilSix.Commands
{
    /// <summary>
    /// command ลงพนันด้วยผู้เล่นเอง
    /// </summary>
    public class SingleBetCommand
    {
        //input
        /// <summary>
        /// ข้อมูลการลงเดิมพัน
        /// 1. RoundID รหัสโต๊ะเกมที่ลงพนัน,
        /// 2. UserName ชื่อผู้เล่นที่ลงพนัน
        /// 3. Amount จำนวนเงินที่ลงพนัน
        /// 4. BetTrackingID รหัสตรวจสอบการลงพนัน(Ws ใส่)
        /// </summary>
        public BetInformation BetInfo { get; set; }

        //output
        /// <summary>
        /// รหัสสำหรับตรวจสอบ
        /// </summary>
        public Guid TrackingID { get; set; }
    }
}
