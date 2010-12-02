using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.Colors.Models;

namespace TheS.Casinova.Colors.Commands
{
    /// <summary>
    /// เพิ่มประวัติการดำเนินการของผู้เล่น
    /// </summary>
    public class CreatePlayerActionInfoCommand
    {
        //input
        /// <summary>
        /// ข้อมูลการดำเนินการของผู้เล่น
        /// </summary>
        public PlayerActionInformation PlayerActionInfo { get; set; }
    }
}
