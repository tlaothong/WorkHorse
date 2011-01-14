using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.DevilSix.Commands;


namespace TheS.Casinova.DevilSix.BackServices
{
    public interface IDevilSixGameBackService :
        ISingleBet,
        IStartAutoBet,
        IStopAutoBet
    { }

    /// <summary>
    /// ส่งค่า command เพื่อลงเดิมพัน
    /// </summary>
    public interface ISingleBet
    {
        void SingleBet(SingleBetCommand cmd);
    }

    /// <summary>
    /// ส่งค่า command เพื่อลงเดิมพันแบบอัตโนมัติ
    /// </summary>
    public interface IStartAutoBet
    {
        void StartAutoBet(StartAutoBetCommand cmd);
    }

    /// <summary>
    /// ส่งค่า command เพื่อหยุดการลงเดิมพันแบบอัตโนมัติ
    /// </summary>
    public interface IStopAutoBet
    {
        void StopAutoBet(StopAutoBetCommand cmd);
    }
}
