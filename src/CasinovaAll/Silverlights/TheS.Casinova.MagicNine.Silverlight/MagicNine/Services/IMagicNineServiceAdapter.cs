using System;
using TheS.Casinova.MagicNineSvc;

namespace TheS.Casinova.MagicNine.Services
{
    public interface IMagicNineServiceAdapter
    {
        IObservable<ListActiveGameRoundInfoCommand> GetListActiveGameRound();

        IObservable<ListGamePlayAutoBetInfoCommand> GetListGamePlayAutoBetInformation(ListGamePlayAutoBetInfoCommand cmd);

        IObservable<ListBetLogCommand> GetListBetLog(ListBetLogCommand cmd);

        IObservable<SingleBetCommand> BetSingle(SingleBetCommand cmd);

        IObservable<StartAutoBetCommand> AutoBetOn(StartAutoBetCommand cmd);

        IObservable<StopAutoBetCommand> AutoBetOff(StopAutoBetCommand cmd);
    }
}
