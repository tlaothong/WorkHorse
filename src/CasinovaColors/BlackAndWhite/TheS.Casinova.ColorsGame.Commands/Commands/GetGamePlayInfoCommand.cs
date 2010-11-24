using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.ColorsGame.Models;

namespace TheS.Casinova.ColorsGame.Commands
{
    //get information data of game playable by username and return GameplayInfos type IEnumarable<GamePlayInformation>
    public class GetGamePlayInfoCommand
    {
        //input
        public string UserName { get; set; } // username of player

        //output
        public IEnumerable<GamePlayInformation> GamePlayInfos { get; set; } //return data of game playable information
    }
}
