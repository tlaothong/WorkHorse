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
        /// ผู้ชนะสูงสุดในช่วงเวลาปกติ
        /// </summary>
        public string WinnerHightName { get; set; }

        /// <summary>
        /// ผู้ชนะต่ำสุดในช่วงเวลาปกติ
        /// </summary>
        public string WinnerLowName { get; set; }

        /// <summary>
        /// ช่วงจำนวนเงินของผู้ชนะสูงสุด
        /// </summary>
        public string WinnerHightRange { get; set; }

        /// <summary>
        /// ช่วงจำนวนเงินของผู้ชนะต่ำสุด
        /// </summary>
        public string WinnerLowRange { get; set; }

        /// <summary>
        /// ผู้ชนะสูงสุดในช่วงเวลาวิกฤต
        /// </summary>
        public string WinnerHightNameCritical { get; set; }

        /// <summary>
        /// ผู้ชนะต่ำสุดในช่วงเวลาวิกฤต
        /// </summary>
        public string WinnerLowNameCritical { get; set; }
    }
}
