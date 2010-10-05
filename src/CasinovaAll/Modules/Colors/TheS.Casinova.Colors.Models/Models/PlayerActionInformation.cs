using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheS.Casinova.Colors.Models
{
    /// <summary>
    /// ข้อมูลการลงพนันของผู้เล่นแต่ละครั้ง
    /// </summary>
    public class PlayerActionInformation
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
        /// ประเภทของการดำเนินการ
        /// </summary>
        public string ActionType { get; set; }

        /// <summary>
        /// จำนวนเงินที่ใช้ดำเนินการ
        /// </summary>
        public double Amount { get; set; }
    }
}
