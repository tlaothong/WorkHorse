using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.MagicNine.Models;

namespace TheS.Casinova.MagicNine.Commands
{
    /// <summary>
    /// ดึงข้อมูลโต๊ะเกม
    /// </summary>
    public class GetGameRoundInfoCommand
    {
        //input
        /// <summary>
        /// รหัสโต๊ะเกมที่จะดึงข้อมูล
        /// </summary>
        public int RoundID { get; set; }

        /// <summary>
        /// ข้อมูลโต๊ะเกม
        /// </summary>
        public GameRoundInformation GameRoundInfo { get; set; }
    }
}
