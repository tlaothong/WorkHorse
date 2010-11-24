using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using TheS.Casinova.ColorsSvc;
using System.Linq;

namespace TheS.Casinova.Colors.Services
{
    public class ColorsServiceAdapter : TheS.Casinova.Colors.Services.IColorsServiceAdapter
    {
        #region Fields
        
        IColorsService _svc;
        Func<BetCommand, IObservable<BetCommand>> _fnBet;
        Func<IObservable<ListActiveGameRoundCommand>> _fnGetActiveGameRound;
        Func<GetGameResultCommand, IObservable<GetGameResultCommand>> _fnGetGameResult;
        Func<PayForColorsWinnerInfoCommand, IObservable<PayForColorsWinnerInfoCommand>> _fnGetWinnerInformation;
        Func<ListGamePlayInfoCommand, IObservable<ListGamePlayInfoCommand>> _fnGetListGamePlayInformation;

        #endregion Fields

        #region Constructors

        public ColorsServiceAdapter()
        {
            _svc = new ColorsServiceClient();

            var svc = _svc;
            _fnBet = Observable.FromAsyncPattern<BetCommand, BetCommand>
                (svc.BeginBet, svc.EndBet);

            _fnGetActiveGameRound = Observable.FromAsyncPattern<ListActiveGameRoundCommand>
                (svc.BeginGetListActiveGameRound, svc.EndGetListActiveGameRound);

            _fnGetGameResult = Observable.FromAsyncPattern<GetGameResultCommand, GetGameResultCommand>
                (svc.BeginGetGameResult, svc.EndGetGameResult);

            _fnGetWinnerInformation = Observable.FromAsyncPattern<PayForColorsWinnerInfoCommand, PayForColorsWinnerInfoCommand>
                (svc.BeginGetWinnerInformation, svc.EndGetWinnerInformation);

            _fnGetListGamePlayInformation = Observable.FromAsyncPattern<ListGamePlayInfoCommand, ListGamePlayInfoCommand>
                (svc.BeginGetListGamePlayInformation, svc.EndGetListGamePlayInformation);
        }

        #endregion Constructors

        #region IColorsServiceAdapter Members


        public IObservable<GetGameResultCommand> GetGameResult(GetGameResultCommand cmd)
        {
            return _fnGetGameResult(cmd);
        }

        public IObservable<ListGamePlayInfoCommand> GetListGamePlayInformation(ListGamePlayInfoCommand cmd)
        {
            return _fnGetListGamePlayInformation(cmd);
        }

        public IObservable<PayForColorsWinnerInfoCommand> GetWinnerInformation(PayForColorsWinnerInfoCommand cmd)
        {
            return _fnGetWinnerInformation(cmd);
        }

        public IObservable<BetCommand> Bet(BetCommand cmd)
        {
            return _fnBet(cmd);
        }

        public IObservable<ListActiveGameRoundCommand> GetListActiveGameRound()
        {
            return _fnGetActiveGameRound();
        }


        #endregion
    }
}
