using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheS.Casinova.ChipExchange.Models
{
    public class MultiLevelNetworkInformation
    {
        /// <summary>
        /// ชื่อผู้เล่น
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// จำนวนโบนัส
        /// </summary>
        public int Bonus { get; set; }
    }
}
