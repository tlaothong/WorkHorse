using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SilverlightWeb.wsv
{
    public class MagicNineService : IMagicNineService
    {
        #region IMagicNineService Members

        public TheS.Casinova.MagicNine.Commands.ListActiveGameRoundInfoCommand GetListActiveGameRound()
        {
            // TODO: Magic 9 Service GetListActiveGameRound
            throw new NotImplementedException();
        }

        public TheS.Casinova.MagicNine.Commands.ListGamePlayAutoBetInfoCommand GetListGamePlayAutoBetInformation(TheS.Casinova.MagicNine.Commands.ListGamePlayAutoBetInfoCommand cmd)
        {
            // TODO: Magic 9 Service GetListGamePlayAutoBetInformation
            throw new NotImplementedException();
        }

        public TheS.Casinova.MagicNine.Commands.ListBetLogCommand GetListBetLog(TheS.Casinova.MagicNine.Commands.ListBetLogCommand cmd)
        {
            // TODO: Magic 9 Service GetListBetLog
            throw new NotImplementedException();
        }

        public TheS.Casinova.MagicNine.Commands.SingleBetCommand BetSingle(TheS.Casinova.MagicNine.Commands.SingleBetCommand cmd)
        {
            // TODO: Magic 9 Service BetSingle
            throw new NotImplementedException();
        }

        public TheS.Casinova.MagicNine.Commands.StartAutoBetCommand AutoBetOn(TheS.Casinova.MagicNine.Commands.StartAutoBetCommand cmd)
        {
            // TODO: Magic 9 Service AutoBetOn
            throw new NotImplementedException();
        }

        public TheS.Casinova.MagicNine.Commands.StopAutoBetCommand AutoBetOff(TheS.Casinova.MagicNine.Commands.StopAutoBetCommand cmd)
        {
            // TODO: Magic 9 Service AutoBetOff
            throw new NotImplementedException();
        }

        #endregion
    }
}
