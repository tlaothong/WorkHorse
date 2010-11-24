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
    public class ListGamePlayInfoCommand
    {
        //input
        /// <summary>
        /// ข้อมูลชื่อของผู้เล่น
        /// 1. UserName ชื่อผู้เล่น
        /// </summary>
        public GamePlayInformation GamePlayInfo { get; set; } 

        //output
        /// <summary>
        /// ข้อมูลการเล่นเกมของผู้เล่น
        /// </summary>
        public IEnumerable<GamePlayInformation> GamePlayInformation { get; set; } 
    }
}
