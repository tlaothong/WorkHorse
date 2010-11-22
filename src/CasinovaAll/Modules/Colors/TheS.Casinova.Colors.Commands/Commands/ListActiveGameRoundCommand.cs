using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.Colors.Models;

namespace TheS.Casinova.Colors.Commands
{
    /// <summary>
    /// list ข้อมูลโต๊ะเกมที่กำลัง active
    /// </summary>
   public class ListActiveGameRoundCommand
    {
       //Input:
       /// <summary>
        /// เวลาปัจจุบันที่ผู้เล่นเข้าห้องเกม
       /// </summary>
        public DateTime FromTime { get; set; } 

       //Output:
       /// <summary>
        /// ข้อมูลโต๊ะเกมที่ active
       /// </summary>
        public IEnumerable<GameRoundInformation> GameRoundInfo { get; set; } 

    }
}
