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
        /// ชื่อผู้เล่น
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// ข้อมูลบัญชีของผู้เล่น
        /// </summary>
        public IEnumerable<PlayerAccountInformation> PlayerAccountInfo { get; set; }

    }
}
