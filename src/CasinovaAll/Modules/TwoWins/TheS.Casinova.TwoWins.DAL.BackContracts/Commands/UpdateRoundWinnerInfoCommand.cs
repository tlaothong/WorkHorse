using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.TwoWins.Models;

namespace TheS.Casinova.TwoWins.Commands
{
    /// <summary>
    /// อัพเดทผู้ชนะของโต๊ะเกม
    /// </summary>
    public class UpdateRoundWinnerInfoCommand
    {
        //input
        /// <summary>
        /// ข้อมูลผู้ชนะของโต๊ะเกมที่จะอัพเดท
        /// </summary>
        public RoundWinnerInformation RoundWinnerInfo { get; set; }
    }
}
