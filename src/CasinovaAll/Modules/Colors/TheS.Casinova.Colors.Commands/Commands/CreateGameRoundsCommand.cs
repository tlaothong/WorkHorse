using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheS.Casinova.Colors.Commands
{
    /// <summary>
    /// สร้างโต๊ะเกมเพิ่ม
    /// </summary>
    public class CreateGameRoundsCommand
    {
        //input

        /// <summary>
        /// ชื่อ config ที่จะใช้สร้างโต๊ะเกม
        /// </summary>
        public string ConfigName { get; set; }
    }
}
