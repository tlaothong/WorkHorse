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
        /// จำนวนการลงพนันในโต๊ะเกม
        /// </summary>
        public int HandCount { get; set; }

        /// <summary>
        /// ผู้ชนะสูงสุดในช่วงเวลาปกติ
        /// </summary>
        public string WinnerHiNormal { get; set; }

        /// <summary>
        /// ผู้ชนะต่ำสุดในช่วงเวลาปกติ
        /// </summary>
        public string WinnerLoNormal { get; set; }

        /// <summary>
        /// ผู้ชนะสูงสุดในช่วงเวลา Critical
        /// </summary>
        public string WinnerHiCritical { get; set; }

        /// <summary>
        /// ผู้ชนะต่ำสุดในช่วงเวลา Critical
        /// </summary>
        public string WinnerLoCritical { get; set; }
    }
}
