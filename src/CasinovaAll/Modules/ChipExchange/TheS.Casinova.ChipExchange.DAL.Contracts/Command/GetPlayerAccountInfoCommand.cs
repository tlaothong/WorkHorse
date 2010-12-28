using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.PlayerAccount.Models;

namespace TheS.Casinova.ChipExchange.Command
{
    /// <summary>
    /// command ดึงข้อมูลบัญชีผู้ใช้
    /// </summary>
    public class GetPlayerAccountInfoCommand
    {
        //input
        /// <summary>
        /// ข้อมูลใช้ดึงข้อมูลบัญชีบัตรเครดิต
        /// 1. AccountType ประเภทของบัญชี
        /// 2. UserName ชื่อผู้เล่น
        /// </summary>
        public PlayerAccountInformation PlayerAccount { get; set; }

        //output
        /// <summary>
        /// ข้อมูลบัญชีบัตรเครดิต
        /// </summary>
        public PlayerAccountInformation PlayerAccountInfo { get; set; }

    }
}
