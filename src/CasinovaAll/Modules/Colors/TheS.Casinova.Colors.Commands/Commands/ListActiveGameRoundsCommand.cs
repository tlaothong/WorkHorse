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
   public class ListActiveGameRoundsCommand
    {
       //Input:
        public DateTime FromTime { get; set; }

       //Output:
        public IEnumerable<ActiveGameRounds> ActiveRounds { get; set; }

    }
}
