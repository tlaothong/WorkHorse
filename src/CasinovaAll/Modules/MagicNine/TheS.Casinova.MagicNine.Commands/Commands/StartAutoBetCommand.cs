using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.MagicNine.Models;

namespace TheS.Casinova.MagicNine.Commands
{
   public class StartAutoBetCommand
    {
       //input
       /// <summary>
       /// 1. UserName ชื่อผู้เล่น
       /// 2. RoundID รอบโต๊ะเกมที่ลงเดิมพัน
       /// 3. Amount จำนวนเงินทั้งหมดที่ลงเดิมพันแบบอัตโนมัติ
        ///4. Interval ระยะห่างของเวลาในการลงเดิมพันแต่ละครั้ง
        /// </summary>
        public GamePlayAutoBetInformation GamePlayAutoBetInfo { get; set; }

        //input&output
        /// <summary>
        /// รหัสสำหรับตรวจสอบ
        /// </summary>
        public Guid StartTrackingID { get; set; }

    }
}
