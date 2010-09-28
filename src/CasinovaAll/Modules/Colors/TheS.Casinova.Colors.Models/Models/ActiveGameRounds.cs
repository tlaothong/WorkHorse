using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheS.Casinova.Colors.Models
{
   public class ActiveGameRounds
    {
       /// <summary>
       /// ข้อมูลโต๊ะเกมที่ active
       /// </summary>
        public int TableID { get; set; }
        public int RoundID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
