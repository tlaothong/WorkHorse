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
        /// จำนวนชิฟตายที่ลงพนัน
        /// </summary>
        public double BonusChips { get; set; }

        /// <summary>
        /// จำนวนชิฟเป็นที่ลงพนัน
        /// </summary>
        public double Chips { get; set; }

        /// <summary>
        /// จำนวนชิฟทั้งหมดที่ลงพนัน
        /// </summary>
        public double Amount { get; set; }

        /// <summary>
        /// รหัสมือที่ลงพนัน
        /// </summary>
        public int HandID { get; set; }

        /// <summary>
        /// สถานะเวลาของมือที่ลงพนัน
        /// </summary>
        public string HandStatus { get; set; }

        /// <summary>
        /// เวลาที่ลงพนัน
        /// </summary>
        public DateTime BetDateTime { get; set; }

        /// <summary>
        /// รหัสตรวจสอบการลงพนัน
        /// </summary>
        public Guid BetTrackingID { get; set; }

        /// <summary>
        /// สถานะการอนุญาตให้เปลี่ยนค่าที่ลงพนัน
        /// </summary>
        public bool CanChange { get; set; }
    }
}
