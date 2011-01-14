using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheS.Casinova.DevilSix.Models
{
    /// <summary>
    /// ข้อมูลโต๊ะเกม
    /// </summary>
    public partial class GameRoundInformation
    {
        /// <summary>
        /// รหัสโต๊ะเกม
        /// 1 = 6
        /// 2 = 66
        /// 3 = 666
        /// 4 = 6666
        /// </summary>
        public int RoundID { get; set; }

        /// <summary>
        /// แต้มที่จะชนะของเกม
        /// </summary>
        public double WinnerPoint { get; set; }

        /// <summary>
        /// สถานะของห้อง (True = ใช้งาน / False = ไม่ใช่งาน)
        /// </summary>
        public bool Active { get; set; }
    }
}
