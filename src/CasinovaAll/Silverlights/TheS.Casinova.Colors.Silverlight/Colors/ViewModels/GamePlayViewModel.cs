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
using System.ComponentModel;
using PerfEx.Infrastructure;
using TheS.Casinova.Colors.Models;
using System.Collections.ObjectModel;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using TheS.Casinova.ColorsSvc;

namespace TheS.Casinova.Colors.ViewModels
{
    public class GamePlayViewModel : INotifyPropertyChanged
    {
        #region Fields

        private PropertyChangedNotifier _notify;
        private DateTime _gameTime;
        private string _winner;
        private string _winnerInformation;
        private string _totalAmountOfBlack;
        private string _totalAmountOfWhite;
        private ObservableCollection<GameTable> _tables;
        private IColorsService _svc;
        private Func<IObservable<ListActiveGameRoundCommand>> _activeGameRounds;
        private Func<GetGameResultCommand, IObservable<GetGameResultCommand>> _gameResult;
        private Func<ListGamePlayInfoCommand, IObservable<ListGamePlayInfoCommand>> _getListGamePlayInformation;
        private Func<PayForColorsWinnerInfoCommand, IObservable<Guid>> _getWinnerInformation;
        private Func<BetCommand, IObservable<Guid>> _bet;
        private int _roundID;
        private double _betAmount;

        #endregion Fields

        #region Properties

        public double BetAmount
        {
            get { return _betAmount; }
            set
            {
                if (_betAmount!=value)
                {
                    _betAmount = value;
                    _notify.Raise(() => BetAmount); 
                }
            }
        }

        public int RoundID
        {
            get { return _roundID; }
            set
            {
                if (_roundID!=value)
                {
                    _roundID = value;
                    _notify.Raise(() => RoundID); 
                }
            }
        }

        public ObservableCollection<GameTable> Tables
        {
            get { return _tables; }
            set
            {
                _tables = value;
                _notify.Raise(() => Tables);
            }
        }

        public string TotalAmountOfWhite
        {
            get { return _totalAmountOfWhite; }
            set
            {
                if (_totalAmountOfWhite != value)
                {
                    _totalAmountOfWhite = value;
                    _notify.Raise(() => TotalAmountOfWhite);
                }
            }
        }

        public string TotalAmountOfBlack
        {
            get { return _totalAmountOfBlack; }
            set
            {
                if (_totalAmountOfBlack != value)
                {
                    _totalAmountOfBlack = value;
                    _notify.Raise(() => TotalAmountOfBlack);
                }
            }
        }

        public string WinnerInformation
        {
            get { return _winnerInformation; }
            set
            {
                if (_winnerInformation != value)
                {
                    _winnerInformation = value;
                    _notify.Raise(() => WinnerInformation);
                }
            }
        }

        public string Winner
        {
            get { return _winner; }
            set
            {
                if (_winner != value)
                {
                    _winner = value;
                    _notify.Raise(() => Winner);
                }
            }
        }

        public DateTime GameTime
        {
            get { return _gameTime; }
            set
            {
                if (_gameTime != value)
                {
                    _gameTime = value;
                    _notify.Raise(() => GameTime);
                }
            }
        }

        internal ColorsSvc.IColorsService GameSvc
        {
            get
            {
                if (_svc == null)
                    _svc = new ColorsSvc.ColorsServiceClient();
                return _svc;
            }
            set { _svc = value; }
        }

        #endregion Properties

        #region Constructors

        public GamePlayViewModel()
        {
            _notify = new PropertyChangedNotifier(this, () => PropertyChanged);
            _tables = new ObservableCollection<GameTable>();

            #region Designer properties

            if (DesignerProperties.IsInDesignTool)
            {
                // Sample tables
                Tables.Add(new GameTable
                {
                    Name = "Colors",
                    Round = 1,
                    Amount = 0,
                    GameTime = new TimeSpan(0, 17, 7),
                    TotalBetBlack = 0,
                    TotalBetWhite = 0,
                    IsPlaying = false,
                    Winner = "Black"
                });
                Tables.Add(new GameTable
                {
                    Name = "Colors",
                    Round = 2,
                    Amount = 1,
                    GameTime = new TimeSpan(0, 32, 7),
                    TotalBetBlack = 0,
                    TotalBetWhite = 1,
                    IsPlaying = true,
                    Winner = "Black"
                });
                Tables.Add(new GameTable
                {
                    Name = "Colors",
                    Round = 3,
                    Amount = 8200,
                    GameTime = new TimeSpan(0, 47, 7),
                    TotalBetBlack = 620,
                    TotalBetWhite = 7580,
                    IsPlaying = true,
                    Winner = "White"
                });
                Tables.Add(new GameTable
                {
                    Name = "Colors",
                    Round = 4,
                    Amount = 0,
                    GameTime = new TimeSpan(1, 02, 7),
                    TotalBetBlack = 0,
                    TotalBetWhite = 0,
                    IsPlaying = false,
                    Winner = "Black"
                });
                Tables.Add(new GameTable
                {
                    Name = "Colors",
                    Round = 5,
                    Amount = 450,
                    GameTime = new TimeSpan(1, 17, 7),
                    TotalBetBlack = 10,
                    TotalBetWhite = 440,
                    IsPlaying = true,
                    Winner = "White"
                });
            }

            #endregion Designer properties
        }

        #endregion Constructors

        #region Methods

        public void BetBlack()
        {
            bet();
        }

        public void BetWhite()
        {
            const bool betWhite = false;
            bet(betWhite);
        }

        public void GetListActiveGameRounds()
        {
            var ccs = GameSvc;
            _activeGameRounds = Observable.FromAsyncPattern<ListActiveGameRoundCommand>(
                ccs.BeginGetListActiveGameRound, ccs.EndGetListActiveGameRound);

            // TODO: Colors RX GetListActiveGameRounds
            IDisposable disposeGameRounds = null;
            disposeGameRounds = _activeGameRounds().ObserveOnDispatcher().Subscribe(
                next =>
                {
                    foreach (var table in next.ActiveRounds)
                    {
                        Tables.Add(new GameTable
                        {
                            Round = table.RoundID,
                        });
                    }
                    if (Tables.Count <= 0)
                        Tables.Add(new GameTable());
                },
                error => { },
                () => { }
                );
        }

        public void GetListGamePlayInformation()
        {
            var ccs = GameSvc;
            _getListGamePlayInformation = Observable.FromAsyncPattern<ListGamePlayInfoCommand, ListGamePlayInfoCommand>(
                ccs.BeginGetListGamePlayInformation, ccs.EndGetListGamePlayInformation);

            // TODO: Colors RX GetListGamePlayInformation
            IDisposable disposeGamePlayInformation = null;
            disposeGamePlayInformation = _getListGamePlayInformation(new ListGamePlayInfoCommand()).Subscribe(
                next => { },
                error => { },
                () => { }
                );
        }

        public void GetWinnerInformation()
        {
            var ccs = GameSvc;
            _getWinnerInformation = Observable.FromAsyncPattern<PayForColorsWinnerInfoCommand, Guid>(
                ccs.BeginGetWinnerInformation, ccs.EndGetWinnerInformation);

            // TODO: Colors RX GetWinnerInformation
            IDisposable disposeGetWinnerInformation = null;
            disposeGetWinnerInformation = _getWinnerInformation(new PayForColorsWinnerInfoCommand { RoundID = RoundID })
                .Subscribe(
                next => { },
                error => { },
                () => { }
                );

        }

        public void GetGameResult()
        {
            var ccs = GameSvc;
            _gameResult = Observable.FromAsyncPattern<GetGameResultCommand, GetGameResultCommand>(
                ccs.BeginGetGameResult, ccs.EndGetGameResult);

            // TODO: Colors RX GetGameResult
            IDisposable disposeGameResult = null;
            disposeGameResult = _gameResult(new GetGameResultCommand { RoundID = RoundID }).Subscribe(
                next => { },
                error => { },
                () => { }
                );
        }

        private void bet(bool betBlack = true)
        {
            const string BetInBlack = "Black";
            const string BetInWhite = "White";
            string selectColor = BetInWhite;
            if (betBlack) selectColor = BetInBlack;

            var ccs = GameSvc;
            _bet = Observable.FromAsyncPattern<BetCommand, Guid>(
                ccs.BeginBet,ccs.EndBet);

            // TODO: Colors RX Bet
            IDisposable disposeBet = null;
            disposeBet = _bet(new BetCommand{
                Color = selectColor,
                RoundID = RoundID,
                Amount = BetAmount
            }).Subscribe(
                next => { },
                error => { },
                () => { }
                );
        }

        #endregion Methods

        #region INotifyPropertyChanged member

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion INotifyPropertyChanged member
    }
}
