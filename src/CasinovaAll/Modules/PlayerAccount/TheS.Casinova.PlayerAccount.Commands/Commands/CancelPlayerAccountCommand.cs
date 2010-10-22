using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheS.Casinova.PlayerAccount.Commands
{
    /// <summary>
    /// ยกเลิกบัญชีของผู้เล่น
    /// </summary>
    public class CancelPlayerAccountCommand
    {
        /// <summary>
        /// ชื่อผู้เล่นที่จะยกเลิกบัญชี
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// รหัสบัญชีที่จะยกเลิก
        /// </summary>
        public int PlayerAccoundID { get; set; }
    }
}
