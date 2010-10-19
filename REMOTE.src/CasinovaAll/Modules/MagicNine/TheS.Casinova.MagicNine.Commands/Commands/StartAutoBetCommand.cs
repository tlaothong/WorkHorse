using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.MagicNine.Models;

namespace TheS.Casinova.MagicNine.Commands
{
    /// <summary>
    /// เริ่มการลงพนันอัตโนมัติ
    /// </summary>
    public class StartAutoBetCommand
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
        /// จำนวนเงินที่ลงพนันอัตโนมัติ
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// ระยะห่างในการลงพนันแต่ละครั้ง
        /// </summary>
        public int Interval { get; set; }
    }
}
