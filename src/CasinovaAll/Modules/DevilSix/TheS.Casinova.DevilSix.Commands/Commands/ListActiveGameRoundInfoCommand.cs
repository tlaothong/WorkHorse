using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.DevilSix.Models;


namespace TheS.Casinova.DevilSix.Commands
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
        /// ข้อมูลโต๊ะเกมทั้งหมดที่ Active
        /// </summary>
        public IEnumerable<GameRoundInformation> ActiveGameRoundInfo { get; set; }
    }
}
