using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.ChipExchange.Models;

namespace TheS.Casinova.ChipExchange.Commands
{
    /// <summary>
    /// ดึงข้อมูลคูปอง
    /// </summary>
    public class GetVoucherInfoCommand
    {
        //input
        /// <summary>
        /// รหัสคูปองที่ต้องการข้อมูล
        /// </summary>
        public string VoucherCode { get; set; }

        //output
        /// <summary>
        /// ข้อมูลคูปองที่ต้องการ
        /// </summary>
        public VoucherInformation VoucherInfo { get; set; }
    }
}
