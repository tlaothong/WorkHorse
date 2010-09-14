using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerfEx.Demo.SimpleGame.Models
{
    public class GameRound
    {
        public int TableID { get; set; }
        public int RoundID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
