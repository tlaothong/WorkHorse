using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheS.Casinova.TwoWins.Models
{
    public partial class TotalBetInformation
    {
        /// <summary>
        /// รหัสโต๊ะเกม
        /// </summary>
        public int RoundID { get; set; }

        /// <summary>
        /// ชื่อผู้เล่น
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// จำนวนเงินทั้งหมดแต่ละโต๊ะที่ผู้เล่นเคยลงไว้
        /// </summary>
        public double TotalBet { get; set; }
    }
}
