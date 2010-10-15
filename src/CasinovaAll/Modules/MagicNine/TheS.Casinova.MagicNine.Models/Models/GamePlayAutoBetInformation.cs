using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheS.Casinova.MagicNine.Models
{
    /// <summary>
    /// ข้อมูลการลงพนันอัตโนมัติของผู้เล่นในโต๊ะนั้นๆ
    /// </summary>
    public class GamePlayAutoBetInformation
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
        /// รหัสตรวจสอบการเริ่มต้นของการลงพนันอัตโนมัติ
        /// </summary>
        public Guid StartTrackingID { get; set; }

        /// <summary>
        /// รหัสตรวจสอบการหยุดของการลงพนันอัตโนมัติ
        /// </summary>
        public Guid StopTrackingID { get; set; }

        /// <summary>
        /// จำนวนเงินที่ลงพนันอัตโนมัติ
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// ระยะห่างในการลงพนันแต่ละครั้ง
        /// </summary>
        public int Interval { get; set; }

        /// <summary>
        /// จำนวนเงินที่ได้รับคืน เมื่อหยุดโปรแกรมก่อน
        /// </summary>
        public int Return { get; set; }
    }
}
