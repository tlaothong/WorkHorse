using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Demo.SimpleGame.Models;

namespace PerfEx.Demo.SimpleGame.Commands
{
    public class ListActiveGameRoundsCommand
    {
        public DateTime FromTime { get; set; }
        public IEnumerable<GameRound> Rounds { get; set; }


    }
}
