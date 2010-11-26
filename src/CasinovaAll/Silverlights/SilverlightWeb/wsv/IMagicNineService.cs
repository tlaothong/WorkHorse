using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using TheS.Casinova.MagicNine.Commands;

namespace SilverlightWeb.wsv
{
    [ServiceContract]
    public interface IMagicNineService
    {
        [OperationContract]
        ListActiveGameRoundInfoCommand GetListActiveGameRound();

        [OperationContract]
        ListGamePlayAutoBetInfoCommand GetListGamePlayAutoBetInformation(ListGamePlayAutoBetInfoCommand cmd);

        [OperationContract]
        ListBetLogCommand GetListBetLog(ListBetLogCommand cmd);

        [OperationContract]
        SingleBetCommand BetSingle(SingleBetCommand cmd);

        [OperationContract]
        StartAutoBetCommand AutoBetOn(StartAutoBetCommand cmd);

        [OperationContract]
        StopAutoBetCommand AutoBetOff(StopAutoBetCommand cmd);
    }
}
