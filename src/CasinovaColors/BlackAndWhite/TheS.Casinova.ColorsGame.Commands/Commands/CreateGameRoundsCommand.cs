using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.ColorsGame.Models;

namespace TheS.Casinova.ColorsGame.Commands
{
    public class CreateGameRoundCommand
    {
        public string Name { get; set; }
        public int BufferRoundsCount { get; set; }
        public GameRoundInformation GameRoundInformation { get; set; }
    }
}
