using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.ChipExchange.Models;

namespace TheS.Casinova.ChipExchange.Commands
{
    /// <summary>
    /// command แลกชิพตายด้วยเงิน
    /// </summary>
    public class MoneyToBonusChipsCommand
    {
        //input
        /// <summary>
        /// ข้อมูลการแลกชิฟ
        /// 1.UserName ชื่อผู้แลก
        /// 2.Amount จำนวนเงินที่แลก
        /// 3.AccountType บัญชีที่ใช้แลก
        /// </summary>
        public ExchangeInformation ExchangeInformation { get; set; }
    }
}
