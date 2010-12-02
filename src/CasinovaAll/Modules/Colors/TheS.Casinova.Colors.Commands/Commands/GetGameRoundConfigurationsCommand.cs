using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.Colors.Models;

namespace TheS.Casinova.Colors.Commands
{
    /// <summary>
    /// command ดึงค่าข้อมูลการสร้างจำนวนโต๊ะเกม
    /// </summary>
   public class GetGameRoundConfigurationsCommand
    {
        //input
        public string Name { get; set; } 

        //output
        public GameRoundConfiguration GameRoundConfigInfo { get; set; }
    }
}
