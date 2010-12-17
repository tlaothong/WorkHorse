using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.TwoWins.Models;

namespace TheS.Casinova.TwoWins.Commands
{
    /// <summary>
    /// command การลงเดิมพันแบบทีละมือ
    /// </summary>
    public class SingleBetCommand
    {
        //input
        /// <summary>
        /// ข้อมูลการลงเดิมพันแบบทีละมือ
        /// 1.UserName ชื่อผู้เล่น
        /// 2.Amount จำนวนเงินที่ลงเดิมพัน
        /// 3.RoundID รหัสโต๊ะเกม
        /// 4.BetTrackingID รหัสตรวจสอบการลงพนัน
        /// </summary>
        public BetInformation BetInfo { get; set; }

        //output
        /// <summary>
        /// รหัสตรวจสอบ
        /// </summary>
        public Guid BetTrackingID { get; set; }
    }
}
