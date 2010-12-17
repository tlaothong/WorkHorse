using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.TwoWins.Models;

namespace TheS.Casinova.TwoWins.Commands
{
    /// <summary>
    /// บันทึกข้อมูลการลงพนัน
    /// </summary>
    public class CreateBetInfoCommand
    {
        //input
        /// <summary>
        /// ข้อมูลการลงพนัน
        /// 1.UserName ชื่อผู้เล่น
        /// 2.RoundID รหัสโต๊ะเกม
        /// 3.BetTrackingID รหัสตรวจสอบการลงพนัน
        /// 4.BetDateTime วันเวลาที่ลงพนัน
        /// 5.HandID รหัสสำหรับเพิ่มเงินที่ลงพนัน
        /// 6.Status ช่วงเวลาที่ลงพนันหรือแก้ไข(Normal, Critical)
        /// 7.BonusChips จำนวนชิฟตายที่ใช้ลงพนัน
        /// 8.Chips จำนวนชิฟเป็นที่ใช้ลงพนัน
        /// 9.CanChange การอนุญาตให้แก้ไข
        /// </summary>
        public BetInformation BetInfo { get; set; }
    }
}
