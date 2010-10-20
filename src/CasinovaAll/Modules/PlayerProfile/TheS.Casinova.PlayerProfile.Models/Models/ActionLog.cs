using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheS.Casinova.PlayerProfile.Models
{
    /// <summary>
    /// ข้อมูล action log ของผู้เล่น
    /// </summary>
    public class ActionLog
    {
        /// <summary>
        /// ชื่อของผู้เลน
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// สิ่งที่ผู้เล่นทำในเกม
        /// </summary>
        public string Action { get; set; }

        /// <summary>
        /// เวลาที่เกิด action ในเกม
        /// </summary>
        public DateTime DateTime { get; set; }

        /// <summary>
        /// ชื่อเกม
        /// </summary>
        public string GameName { get; set; }

        /// <summary>
        /// จำนวนเงินที่เกิดจาก action ต่าง ๆ ในเกม
        /// </summary>
        public double Amount { get; set; }
    }
}
