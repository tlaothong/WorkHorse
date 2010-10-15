using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.MagicNine.Commands;

namespace TheS.Casinova.MagicNine.BackServices
{
    public interface IAutoBetEngine
    {
        public void StartAutoBet(StartAutoBetCommand command);
        public void StopAutoBet(StopAutoBetCommand command);
    }
}
