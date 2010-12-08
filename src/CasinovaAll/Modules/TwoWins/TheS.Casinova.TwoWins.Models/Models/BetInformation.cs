using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheS.Casinova.TwoWins.Models
{
    public class BetInformation
    {
        /// <summary>
        /// รหัสโต๊ะเกม
        /// </summary>
        public int RoundID { get; set; }

        /// <summary>
        /// ชื่อผู้เล่น
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// จำนวนเงินที่ลงพนัน
        /// </summary>
        public double Amount { get; set; }

        /// <summary>
        /// รหัสมือที่ลงพนัน
        /// </summary>
        public int HandID { get; set; }

        /// <summary>
        /// จำนวนเงินที่เคยลงเดิมพันไว้
        /// </summary>
        public double OldAmount { get; set; }

        /// <summary>
        /// จำนวนเงินลงเดิมพันที่ต้องการเปลี่ยน
        /// </summary>
        public double NewAmount { get; set; }

        /// <summary>
        /// สถานะเวลาของมือที่ลงพนัน
        /// </summary>
        public string HandStatus { get; set; }

        /// <summary>
        /// เวลาที่ลงพนัน
        /// </summary>
        public DateTime HandTime { get; set; }

        /// <summary>
        /// จำนวนเงินทั้งหมดที่ลงเดิมพัน
        /// </summary>
        public double TotalBet { get; set; }

        /// <summary>
        /// รหัสตรวจสอบ
        /// </summary>
        public Guid TrackingID { get; set; }
    }
}
