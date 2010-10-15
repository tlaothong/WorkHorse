using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.MagicNine.Commands;

namespace TheS.Casinova.MagicNine.BackServices
{
    public interface IAutoBetEngine
    {
        void StartAutoBet(StartAutoBetCommand command);
        void StopAutoBet(StopAutoBetCommand command);
    }
}
