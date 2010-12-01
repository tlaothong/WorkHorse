using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.PlayerProfile.Models;

namespace TheS.Casinova.PlayerProfile.Commands
{
    /// <summary>
    /// command ดึงข้อมูล log event
    /// </summary>
   public class ListActionLogCommand
    {
       //input
        //public string UserName { get; set; }

        /// <summary>
        /// ข้อมูลการลิสต์ action log
        /// 1.UserName ชื่อของผู้เล่น
        /// </summary>
        public ActionLog ListActionLogInfo { get; set; }

       //output
       /// <summary>
       /// ข้อมูล action log ของผู้เล่น
       /// </summary>
        public IEnumerable<ActionLog> UserActionLog { get; set; }
    }
}
