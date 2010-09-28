using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.Colors.Models;

namespace TheS.Casinova.Colors.Commands
{
    /// <summary>
    /// get information data of game playable(active rounds) by username and return GameplayInfos type IEnumarable(GamePlayInformation)
    /// </summary>
    public class GetGamePlayInfoCommand
    {
        //input
        public string UserName { get; set; } // username of player

        //output
        public IEnumerable<GamePlayInformation> GamePlayInfos { get; set; } //return data of game playable information
    }
}
