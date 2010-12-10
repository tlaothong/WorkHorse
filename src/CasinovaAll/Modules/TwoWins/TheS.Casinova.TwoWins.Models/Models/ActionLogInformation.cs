using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheS.Casinova.TwoWins.Models
{
    public class ActionLogInformation
    {
        /// <summary>
        /// รหัสโต๊ะเกม
        /// </summary>
        public int RoundID { get; set; }

        /// <summary>
        /// ชื่อผู้เล่น
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// รหัสการลงเดิมพัน
        /// </summary>
        public int HandID { get; set; }

        /// <summary>
        /// สิ่งที่ทำ
        /// </summary>
        public string Action { get; set; }

        /// <summary>
        /// จำนวนเงินที่ลงพนัน
        /// </summary>
        public double Amount { get; set; }

        /// <summary>
        /// จำนวนเงินเดิมที่ลงไว้แล้วต้องการเปลี่ยน
        /// </summary>
        public double OldAmount { get; set; }

        /// <summary>
        /// สถานะเวลาของมือที่ลงพนัน
        /// </summary>
        public string HandStatus { get; set; }

        /// <summary>
        /// สถานะการอนุญาตให้เปลี่ยนค่าที่ลงเดิมพัน
        /// </summary>
        public bool CanChange { get; set; }

        /// <summary>
        /// เงินรางวัล
        /// </summary>
        public double Reward { get; set; }

        /// <summary>
        /// เวลาที่ลงพนัน
        /// </summary>
        public DateTime DateTime { get; set; }
    }
}
