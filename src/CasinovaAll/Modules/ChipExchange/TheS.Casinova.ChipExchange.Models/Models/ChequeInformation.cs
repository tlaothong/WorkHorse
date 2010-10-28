using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheS.Casinova.ChipExchange.Models
{
    public class ChequeInformation
    {
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
    }
}
