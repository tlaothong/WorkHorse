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
    /// Game result model
    /// </summary>
    public class GameResult
    {
        #region Properties
        
        /// <summary>
        /// Game round id
        /// </summary>
        public int RoundID { get; set; }

        /// <summary>
        /// จำนวนเงินที่ถูกลงในสีขาวทั้งหมดในรอบนี้
        /// </summary>
        public string WhitePot { get; set; }

        /// <summary>
        /// จำนวนเงินที่ถูกลงในสีดำทั้งหมดในรอบนี้
        /// </summary>
        public string BlackPot { get; set; }

        /// <summary>
        /// จำนวนมือทั้งหมดที่ลงในรอบนี้
        /// </summary>
        public int Hands { get; set; }

        /// <summary>
        /// สีที่ชนะในรอบนี้
        /// </summary>
        public string Winner { get; set; }

        #endregion Properties
    }
}
