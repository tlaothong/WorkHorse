using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using TheS.Casinova.Colors.Commands;
using TheS.Casinova.Colors.Models;

namespace SilverlightWeb.wsv
{
    public class ColorsService : IColorsService
    {
        #region IColorsService Members

        public ListActiveGameRoundCommand GetListActiveGameRound()
        {
            // TODO: Colors service GetListActiveGameRound
            throw new NotImplementedException();
        }

        public ListGamePlayInfoCommand GetListGamePlayInformation(ListGamePlayInfoCommand cmd)
        {
            // TODO: Colors service GetListGamePlayInformation
            throw new NotImplementedException();
        }

        public GetGameResultCommand GetGameResult(GetGameResultCommand cmd)
        {
            // TODO: Colors service GetGameResult
            throw new NotImplementedException();
        }

        public PayForColorsWinnerInfoCommand GetWinnerInformation(PayForColorsWinnerInfoCommand cmd)
        {
            // TODO: Colors service GetWinnerInformation
            throw new NotImplementedException();
        }

        public BetCommand Bet(BetCommand cmd)
        {
            // TODO: Colors service Bet
            throw new NotImplementedException();
        }

        #endregion
    }
}
