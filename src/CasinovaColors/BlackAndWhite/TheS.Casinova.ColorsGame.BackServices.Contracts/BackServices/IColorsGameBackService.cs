using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.ColorsGame.Commands;

namespace TheS.Casinova.ColorsGame.BackServices
{
    public interface IColorsGameBackService
    {
        void PayForWinnerInfo(PayForColorsWinnerInfoCommand cmd);
    }
}
