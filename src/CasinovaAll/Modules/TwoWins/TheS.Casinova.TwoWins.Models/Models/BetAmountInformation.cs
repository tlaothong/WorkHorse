using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheS.Casinova.TwoWins.Models
{
    /// <summary>
    /// ข้อมูลการลงพนันของแต่ละค่าเงินที่ลง
    /// </summary>
    public class BetAmountInformation
    {
        /// <summary>
        /// จำนวนเงินที่ลง
        /// </summary>
        public double Amount { get; set; }

        /// <summary>
        /// จำนวนที่ซ้ำ
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// สถานะการลงของแต่ละมือ
        /// </summary>
        public string HandStatus { get; set; }
    }
}
