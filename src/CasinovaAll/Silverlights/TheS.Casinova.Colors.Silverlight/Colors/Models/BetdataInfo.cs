using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace TheS.Casinova.Colors.Models
{
    /// <summary>
    /// ข้อมูลการเล่นเกม
    /// </summary>
    public class BetdataInfo
    {
        #region Properties
        
        /// <summary>
        /// เวลาที่ลงพนัน
        /// </summary>
        public DateTime Time { get; set; }

        /// <summary>
        /// รอบ
        /// </summary>
        public int Round { get; set; }

        /// <summary>
        /// ผู้เล่นที่ชนะ
        /// </summary>
        public string Player { get; set; }

        /// <summary>
        /// จำนวนเงินที่ลง
        /// </summary>
        public double Bet { get; set; }

        /// <summary>
        /// White Pot ณ เวลาขณะนั้น
        /// </summary>
        public double WhitePot { get; set; }

        /// <summary>
        /// Black Pot ณ เวลาขณะนั้น
        /// </summary>
        public double BlackPot { get; set; }

        /// <summary>
        /// สีที่เลือก
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// สีที่ชนะ ณ เวลาขณะนั้น
        /// </summary>
        public string WinColor { get; set; }

        /// <summary>
        /// สีที่เลือกตรงกับสีที่ชนะหรือไม่
        /// </summary>
        public bool Match { get; set; }

        #endregion Properties
    }
}
