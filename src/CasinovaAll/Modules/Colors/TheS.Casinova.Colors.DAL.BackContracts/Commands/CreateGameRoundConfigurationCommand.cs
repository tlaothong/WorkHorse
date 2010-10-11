using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheS.Casinova.Colors.Commands
{
    public class CreateGameRoundConfigurationCommand
    {
        //Input

        /// <summary>
        /// ชื่อโต๊ะเกม
        /// </summary>
        public string ConfigName { get; set; }

        /// <summary>
        /// จำนวนโต๊ะเกมที่ต้องการสร้าง
        /// </summary>
        public int TableAmount { get; set; }

        /// <summary>
        /// ระยะเวลาของเกมแต่ละ round
        /// </summary>
        public int GameDuration { get; set; }

        /// <summary>
        /// ระยะห่างในการเริ่มเกมแต่ละ round
        /// </summary>
        public int IntervalTime { get; set; }
    }
}
