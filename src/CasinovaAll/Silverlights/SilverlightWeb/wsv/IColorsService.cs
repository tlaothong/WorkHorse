using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using TheS.Casinova.Colors.Commands;

namespace SilverlightWeb.wsv
{
    [ServiceContract]
    public interface IColorsService
    {
        [OperationContract]
        ListActiveGameRoundCommand GetListActiveGameRound();

        [OperationContract]
        GetGameResultCommand GetGameResult(GetGameResultCommand cmd);

        [OperationContract]
        ListGamePlayInfoCommand GetListGamePlayInformation(ListGamePlayInfoCommand cmd);

        [OperationContract]
        Guid GetWinnerInformation(PayForColorsWinnerInfoCommand cmd);

        [OperationContract]
        Guid Bet(BetCommand cmd);
    }
}
