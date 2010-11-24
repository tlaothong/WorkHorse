using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheS.Casinova.ChipExchange.Commands
{
    /// <summary>
    /// command แลกชิพตายด้วยเงิน
    /// </summary>
    public class MoneyToBonusChipsCommand
    {
        //input
        /// <summary>
        /// ชื่อผู้เล่น
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// จำนวนเงิน
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// ประเภทบัญชี
        /// </summary>
        public string AccountType { get; set; }
    }
}
