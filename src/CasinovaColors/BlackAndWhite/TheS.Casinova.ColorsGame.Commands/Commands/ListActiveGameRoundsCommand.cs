using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.ColorsGame.Models;

namespace TheS.Casinova.ColorsGame.Commands
{
    public class ListActiveGameRoundsCommand
    {
        public DateTime FromTime { get; set; }
        public IEnumerable<GameRoundInformation> ActiveRounds { get; set; }
    }
}
