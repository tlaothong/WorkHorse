using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.ChipExchange.Models;

namespace TheS.Casinova.ChipExchange.Commands
{
    /// <summary>
    /// command เปลี่ยนชิพเป็น เป้นเงินห
    /// </summary>
    public class ChipsToMoneyCommand
    {
        //input
        /// <summary>
        /// ข้อมูลการแลกชิฟเป็นเงิน
        /// 1. UserName ชื่อผู้เล่น
        /// 2. Address ที่อยู่
        /// 3. Amount จำนวนเงิน
        /// </summary>
        public ChequeInformation ChequeInfo { get; set; }
    }
}
