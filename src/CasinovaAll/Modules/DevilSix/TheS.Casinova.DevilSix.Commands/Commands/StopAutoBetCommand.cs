using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.DevilSix.Models;


namespace TheS.Casinova.DevilSix.Commands
{
    public class StopAutoBetCommand
    {
        //input
        /// <summary>
        /// ข้อมูลการหยุด autobet
        /// 1. RoundID รอบโต๊ะเกมที่ลงเดิมพัน
        /// 2. UserName ชื่อผู้เล่น
        /// 3. StopTrackingID รหัสตรวจสอบสำหรับหยุด autobet(ws ใส่)
        /// </summary>
        public GamePlayAutoBetInformation GamePlayAutoBetInfo { get; set; }

        //input&output
        /// <summary>
        /// รหัสสำหรับตรวจสอบ
        /// </summary>
        public Guid StopTrackingID { get; set; }
    }
}
