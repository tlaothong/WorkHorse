using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheS.Casinova.TwoWins.Models
{
    public class RangeBetInformation
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
        /// จำนวนเงินเริ่มต้นการลงพนัน
        /// </summary>
        public double FromAmount { get; set; }

        /// <summary>
        /// จำนวนเงินสิ้นสุดการลงเดิมพัน
        /// </summary>
        public double ThruAmount { get; set; }

        /// <summary>
        /// เวลาที่ทำการลงเดิมพัน
        /// </summary>
        public DateTime RangeBetDateTime { get; set; }
    }
}
