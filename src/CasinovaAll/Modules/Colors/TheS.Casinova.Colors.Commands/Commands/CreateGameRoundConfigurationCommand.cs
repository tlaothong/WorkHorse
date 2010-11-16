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
        /// ชื่อโต๊ะเกม
        /// </summary>
        //public string Name { get; set; }
        /// <summary>
        /// จำนวนโต๊ะเกมที่ต้องการสร้าง
        /// </summary>
        //public int TableAmount { get; set; }
        /// <summary>
        /// ระยะเวลาของเกมแต่ละ round
        /// </summary>
        //public int GameDuration { get; set; }
        /// <summary>
        /// ระยะห่างในการเริ่มเกมแต่ละ round
        /// </summary>
        //public int Interval { get; set; }

       /// <summary>
       /// ข้อมูลเพื่อสร้างโต๊ะเกม
       /// </summary>
        public GameRoundConfiguration GameRoundConfig { get; set; }
    }
}
