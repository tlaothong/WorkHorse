using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.Colors.Models;

namespace TheS.Casinova.Colors.Commands
{
    /// <summary>
    /// ดึงข้อมูลผลเกม เมื่อจบเกม
    /// </summary>
    public class GetGameResultCommand
    {
        //input
        public int RoundID { get; set; } // username of player

        //output
        public GameRoundInformation GameResult { get; set; } //return data of game result
    }
}
