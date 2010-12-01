using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.PlayerAccount.Models;

namespace TheS.Casinova.PlayerAccount.Commands
{
    /// <summary>
    /// command ดึงข้อมูลบัญชีผู้เล่น
    /// </summary>
    public class ListPlayerAccountCommand
    {
        /// <summary>
        /// ข้อมูลเพื่อการดึงข้อมูลบัญชีของผู้เล่น
        /// 1. ชื่อผู้เล่น
        public PlayerAccountInformation ListPlayerAccountInput { get; set; }

        /// <summary>
        /// ข้อมูลบัญชีของผู้เล่น
        /// </summary>
        public IEnumerable<PlayerAccountInformation> PlayerAccountInformation { get; set; }

    }
}
