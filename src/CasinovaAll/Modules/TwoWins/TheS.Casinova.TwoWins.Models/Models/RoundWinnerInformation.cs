using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheS.Casinova.TwoWins.Models
{
    /// <summary>
    /// ข้อมูลผู้ชนะของโต๊ะเกม
    /// </summary>
    public class RoundWinnerInformation
    {
        /// <summary>
        /// รหัสโต๊ะเกม
        /// </summary>
        public int RoundID { get; set; }

        /// <summary>
        /// จำนวนมือทั้งหมดที่ลงพนันในโต๊ะเกม
        /// </summary>
        public int HandCount { get; set; }

        /// <summary>
        /// ผู้ชนะสูงสุดในช่วงเวลาปกติ
        /// </summary>
        public string WinnerHightName { get; set; }

        /// <summary>
        /// ผู้ชนะต่ำสุดในช่วงเวลาปกติ
        /// </summary>
        public string WinnerLowName { get; set; }

        /// <summary>
        /// ช่วงจำนวนเงินสูงสุดที่ชนะ "จาก"
        /// </summary>
        public double FromWinnerHightRange { get; set; }

        /// <summary>
        /// ช่วงจำนวนเงินสูงสุดที่ชนะ "ถึง"
        /// </summary>
        public double ThruWinnerHightRange { get; set; }

        /// <summary>
        /// ช่วงจำนวนเงินต่ำสุดที่ชนะ "จาก"
        /// </summary>
        public double FromWinnerLowRange { get; set; }

        /// <summary>
        /// ช่วงจำนวนเงินต่ำสุดที่ชนะ "ถึง"
        /// </summary>
        public double ThruWinnerLowRange { get; set; }
    }
}
