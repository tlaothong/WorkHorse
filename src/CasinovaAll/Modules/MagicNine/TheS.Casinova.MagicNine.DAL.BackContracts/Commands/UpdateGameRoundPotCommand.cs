using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheS.Casinova.MagicNine.Commands
{
    /// <summary>
    /// อัพเดทข้อมูลเงินกองกลางของโต๊ะเกม
    /// </summary>
    public class UpdateGameRoundPotCommand
        : SingleBetCommand
    {
        //input

        /// <summary>
        /// เงินกองกลางของโต๊ะที่จะอัพเดท
        /// </summary>
        public int GamePot { get; set; }
    }
}
