using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheS.Casinova.MagicNine.Commands
{
    /// <summary>
    /// หยุดการลงพนันอัตโนมัติ
    /// </summary>
    public class StopAutoBetCommand
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
        /// รหัสตรวจสอบการหยุดของการลงพนันอัตโนมัติ
        /// </summary>
        public Guid StopTrackingID { get; set; }
    }
}
