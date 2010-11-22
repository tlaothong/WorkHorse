using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.MagicNine.Models;

namespace TheS.Casinova.MagicNine.Commands
{
    /// <summary>
    /// ดึงข้อมูลโต๊ะเกม
    /// </summary>
    public class ListActiveGameRoundInfoCommand
    {
        //input
        /// <summary>
        /// สถานะที่ Active
        /// </summary>
        public bool Active { get; set; }
         
        //output

        /// <summary>
        /// ข้อมูลโต๊ะเกมทั้งหมด
        /// </summary>
        public IEnumerable<GameRoundInformation> GameRoundInfo { get; set; }
    }
}
