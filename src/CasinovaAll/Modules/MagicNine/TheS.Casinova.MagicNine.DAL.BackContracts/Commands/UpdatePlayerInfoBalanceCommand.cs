using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheS.Casinova.MagicNine.Commands
{
    /// <summary>
    /// อัพเดทยอดเงินของผู้เล่น
    /// </summary>
    public class UpdatePlayerInfoBalanceCommand 
        : SingleBetCommand
    {        
        //input
        /// <summary>
        /// จำนวนชิฟตาย
        /// </summary>
        public double NonRefundable { get; set; }

        /// <summary>
        /// จำนวนชิฟเป็น
        /// </summary>
        public double Refundable { get; set; }
    }
}
