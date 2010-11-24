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
        public int BetOrder { get; set; }

        /// <summary>
        /// รหัสสำหรับตรวจสอบ
        /// </summary>
        public Guid BetTrackingID { get; set; }
    }
}
