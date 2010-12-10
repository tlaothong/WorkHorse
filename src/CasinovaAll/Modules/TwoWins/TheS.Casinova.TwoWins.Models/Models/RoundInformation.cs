using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheS.Casinova.TwoWins.Models
{
    /// <summary>
    /// ข้อมูลเกมแต่ละโต๊ะ
    /// </summary>
    public class RoundInformation
    {
        /// <summary>
        /// รหัสโต๊ะเกม
        /// </summary>
        public int RoundID { get; set; }

        /// <summary>
        /// เวลาเริ่มเกม
        /// </summary>
        public DateTime FromDateTime { get; set; }

        /// <summary>
        /// เวลาจบเกม
        /// </summary>
        public DateTime ThruDateTime { get; set; }

        /// <summary>
        /// เวลาช่วง Critical
        /// </summary>
        public DateTime CriticalDateTime { get; set; }

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

        /// <summary>
        /// จำนวนชิฟทั้งหมดในโต๊ะเกม
        /// </summary>
        public double Pot { get; set; }

        /// <summary>
        /// จำนวนการลงพนันทั้งหมด
        /// </summary>
        public int HandsCount { get; set; }

        /// <summary>
        /// ช่วงของจำนวนการลงพนัน
        /// </summary>
        public string HandRange { get; set; }
    }
}
