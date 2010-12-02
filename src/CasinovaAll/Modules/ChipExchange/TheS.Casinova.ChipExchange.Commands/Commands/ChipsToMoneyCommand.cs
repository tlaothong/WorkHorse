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
        /// ชื่อผู้เล่น
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// ที่อยู่ผู้เล่น
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// จำนวนเงิน
        /// </summary>
        public int Amount { get; set; }

        //$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
        /// <summary>
        /// ข้อมูลการแลกชิฟเป็นเงิน
        /// </summary>
        public ChequeInformation ChequeInfo { get; set; }
        //$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
    }
}
