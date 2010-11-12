using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.MagicNine.Models;

namespace TheS.Casinova.MagicNine.Commands
{
     public class ListGamePlayAutoBetInfoCommand
    {
         //input
         /// <summary>
         /// ชื่อของผู้เล่น
         /// </summary>
         public string UserName { get; set; }
         
         //output
         /// <summary>
         /// ข้อมูลการลงเดิมพันแบบอัตโนมัติ
         /// </summary>
         public IEnumerable<GamePlayAutoBetInformation> GamePlayAutoBet { get; set; }

    }
}


