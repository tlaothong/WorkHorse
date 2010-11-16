using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.Colors.Models;

namespace TheS.Casinova.Colors.Commands
{
    /// <summary>
    /// สร้างโต๊ะเกมเพิ่ม
    /// </summary>
    public class CreateGameRoundCommand
    {
        //input
        //public string GameRoundConfigName { get; set; } //ชื่อ config ที่จะใช้สร้างโต๊ะเกม

        //ชื่อ config ที่จะใช้สร้างโต๊ะเกม
        public GameRoundConfiguration GameRoundConfig { get; set; }
    }
}
