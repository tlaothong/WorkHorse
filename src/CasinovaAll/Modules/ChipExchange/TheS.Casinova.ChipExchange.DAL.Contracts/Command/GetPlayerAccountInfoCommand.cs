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
        /// ชนิดของบัญชี
        /// </summary>
        public string CardType { get; set; }

        /// <summary>
        /// ชื่อผู้เล่น
        /// </summary>
        public string UserName { get; set; }

        //output
        /// <summary>
        /// ข้อมูลบัญชีบัตรเครดิต
        /// </summary>
        public PlayerAccountInformation PlayerAccountInfo { get; set; }

    }
}
