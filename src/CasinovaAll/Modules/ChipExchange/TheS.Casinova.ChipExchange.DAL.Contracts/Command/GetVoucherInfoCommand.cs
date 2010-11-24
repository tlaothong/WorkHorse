using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.ChipExchange.Models;

namespace TheS.Casinova.ChipExchange.Command
{
    /// <summary>
    /// command ดึงข้อมูลของคูปอง
    /// </summary>
    public class GetVoucherInfoCommand
    {
        //input
        /// <summary>
        /// ชื่อผู้เล่น
        /// </summary>
        public string UserNAme { get; set; }

        /// <summary>
        /// รหัสคูปอง
        /// </summary>
        public string VoucherCode { get; set; }

        //output
        /// <summary>
        /// ข้อมูลรหัสคูปอง
        /// </summary>
        public VoucherInformation VoucherInfo { get; set; }

    }
}
