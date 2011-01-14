using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.DevilSix.Models;


namespace TheS.Casinova.DevilSix.Commands
{
   public class StartAutoBetCommand
    {
       //input
       /// <summary>
       /// ข้อมูลการเริ่ม autobet
       /// 1. UserName ชื่อผู้เล่น
       /// 2. RoundID รอบโต๊ะเกมที่ลงเดิมพัน
       /// 3. Amount จำนวนเงินที่ลงเดิมพันแบบอัตโนมัติแต่ละหครั้ง
       /// 4. TotalAmount จำนวนเงินทั้งหมดที่ต้องการลงเดิมพัน
        ///4. Interval ระยะห่างของเวลาในการลงเดิมพันแต่ละครั้ง
        ///5. StartTrackingID รหัสตรวจสอบการเริ่มลงเดิมพันแบบอัตโนมัติ [WS ใส่]
        ///6. BetTrackingID รหัสตรวจสอบการลงเดิมพันน [WS ใส่]
        /// </summary>
        public GamePlayAutoBetInformation GamePlayAutoBetInfo { get; set; }

        //input&output
        /// <summary>
        /// รหัสสำหรับตรวจสอบ
        /// </summary>
        public Guid StartTrackingID { get; set; }

    }
}
