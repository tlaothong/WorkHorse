using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheS.Casinova.MagicNine.Models
{
    /// <summary>
    /// ข้อมูลการลงพนัน
    /// </summary>
    public partial class BetInformation
    {
        /// <summary>
        /// รหัสโต๊ะเกมที่ลงพนัน
        /// </summary>
        public int RoundID { get; set; }

        /// <summary>
        /// ชื่อผู้เล่นที่ลงพนัน
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// วันเวลาที่ลงพนัน
        /// </summary>
        public DateTime BetDateTime { get; set; }

        /// <summary>
        /// ลำดับที่ลงพนันได้
        /// </summary>
        public double BetOrder { get; set; }

        /// <summary>
        /// รหัสสำหรับตรวจสอบ
        /// </summary>
        public Guid BetTrackingID { get; set; }

        /// <summary>
        /// จำนวนเงินที่ลงพนัน
        /// </summary>
        public double Amount { get; set; }

        /// <summary>
        /// จำนวนชิฟตายที่ลงพนัน
        /// </summary>
        public double BonusChips { get; set; }

        /// <summary>
        /// จำนวนชิฟเป็นที่ลงพนัน
        /// </summary>
        public double Chips { get; set; }
    }
}
