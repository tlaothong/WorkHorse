using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.Colors.Models;

namespace TheS.Casinova.Colors.Commands
{
    /// <summary>
    /// command สร้างโต๊ะเกมตามที่ผู้ใช้ config
    /// </summary>
   public class CreateGameRoundConfigurationsCommand
    {
       //input
        public GameRoundConfiguration Tables { get; set; } //ข้อมูลสำหรับสร้างโต๊ะเกม
    }
}
