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
         /// ข้อมูลชื่อผู้เล่น
         /// 1. UserName ชื่อของผู้เล่น
         /// </summary>
         public GamePlayAutoBetInformation GamePlayAutoBetInfo { get; set; }

         
         //output
         /// <summary>
         /// ข้อมูลการลงเดิมพันแบบอัตโนมัติ
         /// </summary>
         public IEnumerable<GamePlayAutoBetInformation> GamePlayAutoBetInformation { get; set; }

    }
}


