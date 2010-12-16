using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.TwoWins.Models;

namespace TheS.Casinova.TwoWins.Commands
{
    /// <summary>
    /// command เพื่อดึงข้อมูลสถานะของโตีะเกม
    /// </summary>
    public class GetGameStatusCommand
    {
        //input
        /// <summary>
        /// ข้อมูลเพื่อดึงข้อมูล Game Status
        /// 1. RoundID รหัสโต๊ะเกม
        /// </summary>
        public RoundInformation RoundInfo { get; set; }

        //output
        /// <summary>
        /// ข้อมูลผู้ชนะระหว่างเกม
        /// </summary>
        public RoundInformation RoundInformation { get; set; }
    }
}
