using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.ChipExchange.Models;

namespace TheS.Casinova.ChipExchange.Commands
{
    /// <summary>
    /// command แลกชิพตายด้วยชิพเป็น
    /// </summary>
    public class ChipsToBonusChipsCommand
    {
        //input
        /// <summary>
        /// ข้อมูลการแลกชิฟตายด้วยชิพเป็น
        /// 1. UserName ชื่อผู้เล่น
        /// 2. Amount จำนวนเงิน
        /// </summary>
        public ExchangeInformation ExchangeInfo { get; set; }
    }
}
