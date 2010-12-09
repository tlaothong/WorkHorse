using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.TwoWins.Models;

namespace TheS.Casinova.TwoWins.Commands
{
    public class ChangeBetInfoCommand
    {
        //input
        /// <summary>
        /// เปลี่ยนแปลงข้อมูลการลงพนัน
        /// 1.UserName ชื่อผู้เล่น
        /// 2.HandID รหัสมือที่ลงพนัน
        /// 3.Amount จำนวนเงินใหม่ที่ลง
        /// 5.RoundID รหัสโต๊ะเกม
        /// </summary>
        public BetInformation BetInfo { get; set; }

        //output
        /// <summary>
        /// รหัสตรวจสอบ
        /// </summary>
        public Guid BetTrackingID { get; set; }
    }
}
