using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.PlayerAccount.Models;

namespace TheS.Casinova.PlayerAccount.Commands
{
    /// <summary>
    /// command ดึงข้อมูลบัญชีของผู้เล่น
    /// </summary>
    public class GetPlayerAccountCommand
    {
        //output
        /// <summary>
        /// ข้อมูลบัญชีของผู้เล่น
        /// 1. UserName ชื่อผู้เล่น
        /// 2. AccountType ชนิดบัญชี
        /// </summary>
        public PlayerAccountInformation PlayerAccountInformation { get; set; }

        /// <summary>
        /// บัญชีผู้เล่นที่ต้องการดึงข้อมูล
        /// 1.UserName ชื่อผู้เล่น
        /// </summary>
        public PlayerAccountInformation PlayerAccountInfo { get; set; }
    }
}
