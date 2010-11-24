using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheS.Casinova.MagicNine.Models
{
    /// <summary>
    /// ข้อมูลผู้เล่น
    /// </summary>
    public class PlayerInformation
    {
        /// <summary>
        /// ชื่อผู้เล่นเจ้าของเงิน
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// เงินที่ผ้เล่นใช้ในเกม
        /// </summary>       
        public double Balance { get; set; }
    }
}
