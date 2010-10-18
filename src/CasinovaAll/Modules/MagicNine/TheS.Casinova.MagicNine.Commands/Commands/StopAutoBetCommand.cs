using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheS.Casinova.MagicNine.Commands
{
    public class StopAutoBetCommand
    {
        //input
        /// <summary>
        /// ชื่อผู้เล่น
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// รหัสโต๊ะเกมที่ลงเดิมพัน
        /// </summary>
        public int RoundID { get; set; }

        //input&output
        /// <summary>
        /// รหัสสำหรับตรวจสอบ
        /// </summary>
        public Guid StartTracking { get; set; }
    }
}
