using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheS.Casinova.MagicNine.Models
{
    /// <summary>
    /// ข้อมูลโต๊ะเกม
    /// </summary>
    public class GameRoundInformation
    {
        /// <summary>
        /// รหัสโต๊ะเกม
        /// </summary>
        public int RoundID { get; set; }

        /// <summary>
        /// เวลาเริ่มเกม
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// เวลาจบเกม
        /// </summary>
        public DateTime EndTime { get; set; }

        /// <summary>
        /// แต้มที่จะชนะของเกม
        /// </summary>
        public int WinnerPoint { get; set; }

        /// <summary>
        /// เงินในกองของเกม
        /// </summary>
        public double GamePot { get; set; }    
    }
}
