using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.Colors.Models;

namespace TheS.Casinova.Colors.Commands
{
    /// <summary>
    /// ดึงข้อมูลผู้เล่น
    /// </summary>
    public class GetPlayerInfoCommand
    {
        //input
        public string UserName { get; set; }

        //output
        public PlayerInformation PlayerInfo { get; set; }
    }
}
