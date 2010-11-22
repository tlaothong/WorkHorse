using System;
using TheS.Casinova.ColorsSvc;
namespace TheS.Casinova.Colors.Services
{
    public interface IColorsServiceAdapter
    {
        IObservable<BetCommand> Bet(BetCommand cmd);
        IObservable<ListActiveGameRoundCommand> GetListActiveGameRound();
        IObservable<GetGameResultCommand> GetGameResult(GetGameResultCommand cmd);
        IObservable<ListGamePlayInfoCommand> GetListGamePlayInformation(ListGamePlayInfoCommand cmd);
        IObservable<PayForColorsWinnerInfoCommand> GetWinnerInformation(PayForColorsWinnerInfoCommand cmd);
    }
}
