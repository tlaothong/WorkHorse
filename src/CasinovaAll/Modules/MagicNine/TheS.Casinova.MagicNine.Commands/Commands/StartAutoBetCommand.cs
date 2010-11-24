using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheS.Casinova.MagicNine.Commands
{
   public class StartAutoBetCommand
    {
       //input
       /// <summary>
       /// ชื่อผู้เล่น
       /// </summary>
        public string UserName { get; set; }

       /// <summary>
       /// รหัสโต๊ะเกมที่ลงเดิมพัน
       /// </summary>
        public int RoundID { get; set; }

       /// <summary>
       /// จำนวนเงินทั้งหมดที่ลงเดิมพันแบบอัตโนมัติ
       /// </summary>
        public double Amount { get; set; }

        /// <summary>
        /// ระยะห่างของเวลาในการลงเดิมพันแต่ละครั้ง
        /// </summary>
        public int Interval { get; set; }

        //input&output
        /// <summary>
        /// รหัสสำหรับตรวจสอบ
        /// </summary>
        public Guid StartTrackingID { get; set; }

    }
}
