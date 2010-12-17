using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.TwoWins.Commands;

namespace TheS.Casinova.TwoWins.BackServices
{
    public interface ITwoWinsGameBackService :
        IChangeBetInfo,
        IRangeBet,
        ISingleBet
    {}

    /// <summary>
    /// ส่งค่า command เพื่อเปลี่ยนแปลงการลงพนัน
    /// </summary>
    public interface IChangeBetInfo
    {
        void ChengeBetInfo(ChangeBetInfoCommand cmd);
    }

    /// <summary>
    /// ส่งค่า command เพื่อลงพนันแบบทีละหลาย ๆ มือ
    /// </summary>
    public interface IRangeBet
    {
        void RangeBet(RangeBetCommand cmd);
    }

    /// <summary>
    /// ส่งค่า command เพื่อลงพนันแบบทีละมือ
    /// </summary>
    public interface ISingleBet
    {
        void SingleBet(SingleBetCommand cmd);
    }
}
