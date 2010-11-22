using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.MagicNine.Models;

namespace TheS.Casinova.MagicNine.Commands
{
    /// <summary>
    /// command ลงพนันด้วยผู้เล่นเอง
    /// </summary>
    public class SingleBetCommand
    {
        //input
        /// <summary>
        /// รหัสโต๊ะเกมที่ลงพนัน
        /// </summary>
        public int RoundID { get; set; }

        /// <summary>
        /// ชื่อผู้เล่นที่ลงพนัน
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// จำนวนเงินที่ลงพนัน
        /// </summary>
        public double Amount { get; set; }

        //input&output
        /// <summary>
        /// รหัสสำหรับตรวจสอบ
        /// </summary>
        public Guid TrackingID { get; set; }
    }
}
