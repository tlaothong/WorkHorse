using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.TwoWins.Commands;

namespace TheS.Casinova.TwoWins.BackServices
{
    public interface ITwoWinsGameBackService
    {}

    public interface IChangeBetInfo
    {
        void ChengeBetInfo(ChangeBetInfoCommand cmd);
    }
}
