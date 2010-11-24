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
        /// ข้อมูลการสร้างโต๊ะเกม
        /// 1. ConfigName ชื่อข้อมูลการสร้างโต๊ะเกม
        /// </summary>
        public GameRoundConfiguration GameRoundConfigName { get; set; }
    }
}
