using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.ChipExchange.Models;

namespace TheS.Casinova.ChipExchange.Commands
{
    /// <summary>
    /// command เพิ่มชิพตายจากคูปอง
    /// </summary>
    public class VoucherToBonusChipsCommand
    {
        //input
        /// <summary>
        /// ชื่อผู้เล่น
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// หมายเลขคูปอง
        /// </summary>
        public string VoucherCode { get; set; }
    }
}
