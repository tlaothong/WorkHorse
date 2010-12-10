using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.TwoWins.Models;

namespace TheS.Casinova.TwoWins.Commands
{
    /// <summary>
    /// อัพเดทข้อมูลโต๊ะเกม
    /// </summary>
    public class UpdateRoundCommand
    {
        //input
        /// <summary>
        /// รหัสโต๊ะเกมที่จะอัพเดท
        /// 1.RoundID
        /// 2.Pot
        /// </summary>
        public RoundInformation RoundInfo { get; set; }
    }
}
