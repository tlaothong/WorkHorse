using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheS.Casinova.TwoWins.Commands
{
    /// <summary>
    /// สร้างโต๊ะเกมเพิ่ม
    /// </summary>
    public class CreateGameRoundCommand
    {
        //input

        /// <summary>
        /// ชื่อ config ที่จะใช้สร้างโต๊ะเกม
        /// </summary>
        public string ConfigName { get; set; }
    }
}
