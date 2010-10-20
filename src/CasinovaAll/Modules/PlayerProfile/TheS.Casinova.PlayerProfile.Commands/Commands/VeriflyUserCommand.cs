using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheS.Casinova.PlayerProfile.Commands
{
    /// <summary>
    /// ยืนยันการสมัครสมาชิก
    /// </summary>
    public class VeriflyUserCommand
    {
        //input
        /// <summary>
        /// ชื่อผู้เล่น
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// รหัสสำหรับยืนยัน
        /// </summary>
        public string VeriflyCode { get; set; }
    }
}
