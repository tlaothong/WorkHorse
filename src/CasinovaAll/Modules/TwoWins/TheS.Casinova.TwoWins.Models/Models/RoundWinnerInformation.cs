using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheS.Casinova.TwoWins.Models
{
    /// <summary>
    /// ข้อมูลผู้ชนะของโต๊ะเกม
    /// </summary>
    public  partial class RoundWinnerInformation
    {
        /// <summary>
        /// รหัสโต๊ะเกม
        /// </summary>
        public int RoundID { get; set; }

        /// <summary>
        /// จำนวนเงินสูงสุดที่ผู้เล่นลงเดิมพันชนะในช่วง normal
        /// </summary>
        public double WinnerHightNormalAmount { get; set; }

        /// <summary>
        /// จำนวนการลงพนันที่ซ้ำกัน
        /// </summary>
        public int WinnerHightNormalCount { get; set; }

        /// <summary>
        /// จำนวนเงินต่ำสุดที่ผู้เล่นลงเดิมพันชนะในช่วง normal
        /// </summary>
        public double WinnerLowNormalAmount { get; set; }

        /// <summary>
        /// จำนวนการลงพนันที่ซ้ำกัน
        /// </summary>
        public int WinnerLowNormalCount { get; set; }

        /// <summary>
        /// จำนวนเงินสูงสุดที่ผู้เล่นลงเดิมพันชนะในช่วง critical
        /// </summary>
        public double WinnerHightCriticalAmount { get; set; }

        /// <summary>
        /// จำนวนการลงพนันที่ซ้ำกัน
        /// </summary>
        public int WinnerHightCriticalCount { get; set; }
        
        /// <summary>
        /// จำนวนเงินต่ำสุดที่ผู้เล่นลงเดิมพันชนะในช่วง critical
        /// </summary>
        public double WinnerLowCriticalAmount { get; set; }

        /// <summary>
        /// จำนวนการลงพนันที่ซ้ำกัน
        /// </summary>
        public int WinnerLowCriticalCount { get; set; }
    }
}
