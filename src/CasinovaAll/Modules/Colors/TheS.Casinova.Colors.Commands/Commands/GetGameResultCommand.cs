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
        /// <summary>
        /// รหัสโต๊ะเกม
        /// </summary>
        public GameRoundInformation GameRoundInfoRoundID { get; set; } 

        //output
        /// <summary>
        /// ข้อมูลผลการเล่นเกม
        /// </summary>
        public GameRoundInformation GameRoundInfo { get; set; } 
    }
}
