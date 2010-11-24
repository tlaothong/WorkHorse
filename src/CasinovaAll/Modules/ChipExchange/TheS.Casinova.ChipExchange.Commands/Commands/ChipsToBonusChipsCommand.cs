using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheS.Casinova.ChipExchange.Commands
{
    /// <summary>
    /// command แลกชิพตายด้วยชิพเป็น
    /// </summary>
    public class ChipsToBonusChipsCommand
    {
        //input
        /// <summary>
        /// ชื่อผู้เล่น
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// จำนวนชิพเป็น
        /// </summary>
        public int Amount { get; set; }
    }
}
