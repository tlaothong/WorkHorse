using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.ChipExchange.Models;
using TheS.Casinova.PlayerAccount.Models;

namespace TheS.Casinova.ChipExchange.Commands
{
    /// <summary>
    /// ดึงข้อมูลบัญชีของผู้เล่น
    /// </summary>
    public class GetPlayerAccountInfoCommand
    {
        //input
        /// <summary>
        /// ชื่อผู้เล่น
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// ประเภทบัญชีของผู้เล่น (Primary/Secondary)
        /// </summary>
        public string AccountType { get; set; }

        //output
        /// <summary>
        /// ข้อมูลบัญชีผู้เล่น
        /// </summary>
        public PlayerAccountInformation PlayerAccountInfo { get; set; }
    }
}
