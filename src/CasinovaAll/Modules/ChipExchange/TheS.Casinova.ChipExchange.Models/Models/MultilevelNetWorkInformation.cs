using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheS.Casinova.ChipExchange.Models
{
    public class MultilevelNetWorkInformation
    {
        /// <summary>
        /// ชื่อผู้เล่น
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// จำนวนโบนัส
        /// </summary>
        public int Bonus { get; set; }
    }
}
