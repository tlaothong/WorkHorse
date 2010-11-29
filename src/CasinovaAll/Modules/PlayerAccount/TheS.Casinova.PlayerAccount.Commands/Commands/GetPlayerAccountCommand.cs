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
        //input
        /// <summary>
        /// ชื่อของผู้เล่น
        /// </summary>
        public string UserName { get; set; }

        //output
        /// <summary>
        /// ข้อมูลบัญชีของผู้เล่น
        /// </summary>
        public PlayerAccountInformation PlayerAccountInfo { get; set; }

        /// <summary>
        /// บัญชีผู้เล่นที่ต้องการดึงข้อมูล
        /// 1.UserName ชื่อผู้เล่น
        /// </summary>
        public PlayerAccountInformation PlayerAccountInfoInput { get; set; }
    }
}
