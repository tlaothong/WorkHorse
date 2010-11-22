using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.Colors.Models;

namespace TheS.Casinova.Colors.Commands
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
        public GameRoundConfiguration GameRoundConfigTableName { get; set; }

        //output

        /// <summary>
        /// Config ที่ต้องการ
        /// </summary>
        public GameRoundConfiguration GameRoundConfig { get; set; }
    }
}
