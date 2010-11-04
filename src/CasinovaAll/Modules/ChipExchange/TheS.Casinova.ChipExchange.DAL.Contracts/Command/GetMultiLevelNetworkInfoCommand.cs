using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.ChipExchange.Models;

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
        public MultiLevelNetworkInformation MultiLevelNetwork { get; set; }
    }
}
