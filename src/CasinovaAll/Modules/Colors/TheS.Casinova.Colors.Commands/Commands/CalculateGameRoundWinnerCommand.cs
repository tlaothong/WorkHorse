using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheS.Casinova.Colors.Commands
{
    /// <summary>
    /// หาผู้ชนะพร้อมทั้งคำนวณรางวัลที่จะคืนให้ผู้เล่น
    /// </summary>
    public class CalculateGameRoundWinnerCommand
    {
        //input
        /// <summary>
        /// รหัสโต๊ะเกมที่จบเกม
        /// </summary>
        public int RoundID { get; set; }
    }
}
