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
   public class CreateGameRoundConfigurationCommand
    {
       //input
       /// <summary>
       /// ข้อมูลเพื่อสร้างโต๊ะเกม
        /// 1. ConfigName ชื่อโต๊ะเกม
        /// 2. TableAmount จำนวนโต๊ะเกมที่ต้องการสร้าง
        /// 3. GameDuration ระยะเวลาของเกมแต่ละ round
        /// 4. Interval ระยะห่างในการเริ่มเกมแต่ละ round
       /// </summary>
        public GameRoundConfiguration GameRoundConfig { get; set; }
    }
}
