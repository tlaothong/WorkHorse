using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheS.Casinova.MagicNine.Models
{
    /// <summary>
    /// ข้อมูลการลงเดิมพันแบบอัตโนมัติ
    /// </summary>
    public class GamePlayAutoBetInformation
    {
        /// <summary>
        /// ชื่อผู้เล่นที่ลงเดิมพัน
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// รหัสโต๊ะเกมที่ลงพนัน
        /// </summary>
        public int RoundID { get; set; }

        /// <summary>
        /// จำนวนเงินทั้งหมดที่ลงเดิมพันแบบอัตโนมัติ
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// ระยะห่างของเวลาในการลงเดิมพันแต่ละครั้ง
        /// </summary>
        public int Interval { get; set; }

        /// <summary>
        /// จำนวนเงินที่ได้คืน
        /// </summary>
        public int MoneyRefund { get; set; }

        /// <summary>
        /// tracking id เมื่อเริ่ม autobet
        /// </summary>
        public Guid StartTrackingID { get; set; }

        /// <summary>
        /// tracking id เมื่อหยุด autobet
        /// </summary>
        public Guid StopTrackingID { get; set; }
    }
}
