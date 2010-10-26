using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.TwoWins.Models;

namespace TheS.Casinova.TwoWins.Commands
{
    /// <summary>
    /// command สร้างโต๊ะเกมตามที่ผู้ใช้ config
    /// </summary>
   public class CreateGameRoundConfigurationCommand
    {
       //input
        public GameRoundConfiguration Tables { get; set; } //ข้อมูลสำหรับสร้างโต๊ะเกม
    }
}
