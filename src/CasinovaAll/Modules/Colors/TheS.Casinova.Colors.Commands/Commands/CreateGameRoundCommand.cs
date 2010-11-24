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
        /// <summary>
        /// 1. TableName ชื่อโต๊ะเกมที่ต้องการสร้าง
        /// </summary>
        public GameRoundConfiguration GameRoundConfig { get; set; }
    }
}
