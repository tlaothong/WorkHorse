using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheS.Casinova.ChipExchange.Command
{
    /// <summary>
    /// command ดึงข้อมูลจำนวนโบนัส
    /// </summary>
    public class GetMultiLevelNetworkInfoCommand
    {
        //input
        /// <summary>
        /// ชื่อของผู้เล่น
        /// </summary>
        public string UserName { get; set; }

        //output
        /// <summary>
        /// จำนวนโบนัส
        /// </summary>
        public int Bunus { get; set; }
    }
}
