using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheS.Casinova.TwoWins.Models
{
    public class TotalBetInformation
    {
        /// <summary>
        /// รหัสโต๊ะเกม
        /// </summary>
        public int RoundID { get; set; }

        /// <summary>
        /// จำนวนเงินทั้งหมดแต่ละโต๊ะที่ผู้เล่นเคยลงไว้
        /// </summary>
        public double TotalBet { get; set; }
    }
}
