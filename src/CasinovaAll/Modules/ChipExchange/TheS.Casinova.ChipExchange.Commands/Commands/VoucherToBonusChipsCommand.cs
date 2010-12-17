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
        /// ข้อมูลคูปองเพื่อเพิ่มชิพตาย
        /// 1. UserName ชื่อผู้เล่น
        /// 2. VoucherCode หมายเลขคูปอง
        /// </summary>
        /// 
        public VoucherInformation VoucherInformation { get; set; }
    }
}
