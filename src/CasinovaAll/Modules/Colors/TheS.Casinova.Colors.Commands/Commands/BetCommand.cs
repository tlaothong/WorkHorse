using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.Colors.Models;

namespace TheS.Casinova.Colors.Commands
{
    /// <summary>
    /// command ลงเงินสีที่ต้องการ ระบบจะทำการหักเงินผู้เล่น และบันทึกข้อมูลการลงพนัน
    /// </summary>
    public class BetCommand
    {
        //input
        /// <summary>
        /// ข้อมูลการลงเดิมพันของผู้เล่น
        ///  1. UserName ชื่อผู้เล่นที่ลงพนัน
        ///  2. RoundID รหัสโต๊ะเกมที่ลงพนัน
        ///  3. Amount จำนวนเงินลงพนัน
        ///  4. ActionType สิ่งที่ทำ
        ///  5. TrackingID รหัสที่ใช้ในการตรวจสอบ(ws ใส่)
        /// </summary>
        public PlayerActionInformation BetPlayerActionInfo { get; set; }

        //output
        /// <summary>
        /// รหัสตรวจสอบ
        /// </summary>
        public Guid BetTrackingID { get; set; }
    }
}
