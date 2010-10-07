using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.Colors.Commands;

namespace TheS.Casinova.Colors.BackServices
{
    /// <summary>
    /// ส่งค่า command ไป back server 
    /// </summary>
    public interface IColorsGameBackService:
        IPayForWinner,
        IBet
    {}

    public interface IPayForWinner 
    {
        /// <summary>
        /// ส่งค่า command เพื่อ get winner
        /// </summary>
        /// <param name="cmd"></param>
        void PayForWinnerInfo(PayForColorsWinnerInfoCommand cmd);
    }

    public interface IBet
    {
        /// <summary>
        /// ส่งค่า command เพื่อลงเดิมพัน
        /// </summary>
        /// <param name="cmd"></param>
        void PlayerBet(BetCommand cmd);
    }
}
