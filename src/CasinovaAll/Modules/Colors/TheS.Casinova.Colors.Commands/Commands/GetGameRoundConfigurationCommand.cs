using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.TwoWins.Models;

namespace TheS.Casinova.TwoWins.Commands
{
    /// <summary>
    /// ดึงข้อมูลการตั้งค่าสำหรับสร้างโต๊ะเกม
    /// </summary>
    public class GetGameRoundConfigurationCommand
    {
        //input

        /// <summary>
        /// ชื่อ config ที่ต้องการดึงข้อมูล
        /// </summary>
        public string Name { get; set; }

        //output

        /// <summary>
        /// Config ที่ต้องการ
        /// </summary>
        public GameRoundConfiguration GameRoundConfiguration { get; set; }
    }
}
