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
        public DateTime FromTime { get; set; } //เวลาปัจจุบันที่ผู้เล่นเข้าห้องเกม

       //Output:
        public IEnumerable<GameRoundInformation> ActiveRounds { get; set; } //ข้อมูลโต๊ะเกมที่ active

    }
}
