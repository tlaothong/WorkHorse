using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheS.Casinova.TwoWins.Commands
{
    /// <summary>
    ///คำนวณเงินรางวัลของผู้ชนะ
    /// </summary>
    public class CalculateGameRoundWinnerCommand
    {
        //input
        /// <summary>
        /// รหัสโต๊ะเกม
        /// </summary>
        public int RoundID { get; set; }
    }
}
