using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.TwoWins.Models;

namespace TheS.Casinova.TwoWins.Commands
{
    /// <summary>
    /// ดึงข้อมูลผลเกม เมื่อจบเกม
    /// </summary>
    public class GetGameResultCommand
    {
        //input
        /// <summary>
        /// รหัสโต๊ะเกม
        /// </summary>
        public int RoundID { get; set; } 

        //output
        /// <summary>
        /// ข้อมูลผลการเล่นเกม
        /// </summary>
        public GameRoundInformation GameResult { get; set; } 
    }
}
