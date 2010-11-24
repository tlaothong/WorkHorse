using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.MagicNine.Models;

namespace TheS.Casinova.MagicNine.Commands
{
    public class StopAutoBetCommand
    {
        //input
        /// <summary>
        /// ข้อมูลการหยุด autobet
        /// 1. RoundID รอบโต๊ะเกมที่ลงเดิมพัน
        /// 2. UserName ชื่อผู้เล่น
        /// </summary>
        public GamePlayAutoBetInformation GamePlayAutoBetInfo { get; set; }

        //input&output
        /// <summary>
        /// รหัสสำหรับตรวจสอบ
        /// </summary>
        public Guid StopTrackingID { get; set; }
    }
}
