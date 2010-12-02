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
        /// ข้อมูลโต๊ะเกมที่ต้องการผลเกม
        /// 1. RoundID รอบของโต๊ะเกม
        /// </summary>
        public GameRoundInformation GameRoundInfo { get; set; } 

        //output
        /// <summary>
        /// ข้อมูลผลการเล่นเกม
        /// </summary>
        public GameRoundInformation GameResultGameRoundInfo { get; set; } 
    }
}
