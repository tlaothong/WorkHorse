using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheS.Casinova.ChipExchange.Models
{
    public class VoucherInformation
    {
        /// <summary>
        /// ชื่อผู้เล่น
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// หมายเลขคูปอง
        /// </summary>
        public string VoucherCode { get; set; }

        /// <summary>
        /// จำนวนเงิน
        /// </summary>
        public double Amount { get; set; }

        /// <summary>
        /// สถานะการถูกใช้ (true : สามารถใช้ได้, false : ถูกใช้ไปแล้ว)
        /// </summary>
        public bool CanUse { get; set; }
    }
}
