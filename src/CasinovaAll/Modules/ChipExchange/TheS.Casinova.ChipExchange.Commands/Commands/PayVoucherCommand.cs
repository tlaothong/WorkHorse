﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.ChipExchange.Models;

namespace TheS.Casinova.ChipExchange.Commands
{
    /// <summary>
    /// command ซื้อคูปองด้วยชิพ
    /// </summary>
    public class PayVoucherCommand
    {
        //input
        /// <summary>
        /// ข้อมูลการซื้อคูปอง
        /// 1.UserName ชื่อผู้เล่นที่ซื้อคูปอง
        /// 2.Amount จำนวนเงินที่ซื้อ
        /// </summary>
        public VoucherInformation VoucherInformation { get; set; }
    }
}
