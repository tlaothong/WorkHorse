using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheS.Casinova.TwoWins.Models
{
    public class SettingInformation
    {
        /// <summary>
        /// ระยะห่างเพื่อคำนวน range ของการลงเดิมพัน
        /// </summary>
        public int BetInterval { get; set; }

        /// <summary>
        /// ระยะห่างเพื่อคำนวน range ของมือที่ลงเดิมพัน
        /// </summary>
        public int HandCountInterval { get; set; }
    }
}
