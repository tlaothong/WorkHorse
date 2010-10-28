using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheS.Casinova.PlayerAccount.Commands
{
    /// <summary>
    /// command ยกเลิกการใช้งานบัตรเครดิต
    /// </summary>
    public class CancelPlayerAccountCommand
    {
        //input
        /// <summary>
        /// รหัสบัญชีของผู้เล่น
        /// </summary>
        public int PlayerAccountID { get; set; }
    }
}
