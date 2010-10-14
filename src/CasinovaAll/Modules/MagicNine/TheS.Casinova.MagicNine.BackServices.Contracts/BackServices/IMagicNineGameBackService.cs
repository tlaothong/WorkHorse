using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.MagicNine.Commands;

namespace TheS.Casinova.MagicNine.BackServices
{
    public interface IMagicNineGameBackService :
        ISingleBet
    { }

    public interface ISingleBet
    {
        /// <summary>
        /// ส่งค่า command เพื่อ get winner
        /// </summary>
        /// <param name="cmd"></param>
        void SingleBet(SingleBetCommand cmd);
    }
}
