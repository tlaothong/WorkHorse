using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheS.Casinova.Colors.Models
{
    /// <summary>
    /// Config โต๊ะเกม
    /// </summary>
   public class GameRoundConfiguration
    {
       private int bufferRound = 3; //จำนวนโต๊ะเกมสำรอง
       /// <summary>
       /// ชื่อโต๊ะเกม
       /// </summary>
       public string Name { get; set; }

       /// <summary>
       /// จำนวนโต๊ะเกมที่ต้องการสร้าง
       /// </summary>
        public int TableAmount { get; set; }

       /// <summary>
       /// ระยะเวลาของเกมแต่ละ round
       /// </summary>
        public int GameDuration { get; set; }

       /// <summary>
       /// ระยะห่างในการเริ่มเกมแต่ละ round
       /// </summary>
        public int Interval { get; set; }

       /// <summary>
       /// จำนวนโต๊ะเกมสำรอง
       /// </summary>
        public int BufferRoundsCount 
        {
            get 
            {
                return bufferRound;
            }
        }
    }
}