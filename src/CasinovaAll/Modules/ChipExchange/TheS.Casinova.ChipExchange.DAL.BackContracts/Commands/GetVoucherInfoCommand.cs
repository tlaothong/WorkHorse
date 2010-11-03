using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.ChipExchange.Models;

namespace TheS.Casinova.ChipExchange.Commands
{
    /// <summary>
    /// ดึงข้อมูลคูปองจากรหัสคูปอง
    /// </summary>
    public class GetVoucherInfoCommand
    {
        //input
        /// <summary>
        /// หมายเลขคูปอง
        /// </summary>
        public string VoucherCode { get; set; }

        //output
        /// <summary>
        /// ข้อมูลคูปอง
        /// </summary>
        public VoucherInformation VoucherInfo { get; set; }
    }
}
