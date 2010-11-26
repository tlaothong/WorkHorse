using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.MagicNine.Commands;
using TheS.Casinova.MagicNine.Models;

namespace TheS.Casinova.MagicNine.BackServices
{
    public interface IAutoBetEngine
    {
        void StartAutoBet(GamePlayAutoBetInformation autorBetInfo, StartAutoBetCommand command);
        void StopAutoBet(GamePlayAutoBetInformation autorBetInfo, StopAutoBetCommand command);
    }
}
