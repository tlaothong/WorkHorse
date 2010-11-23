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
using TheS.Casinova.Colors.Services;
using System.Concurrency;
using PerfEx.Infrastructure.LotUpdate;

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

        private ObservableCollection<PayLog> _paylogs;
        private IColorsServiceAdapter _sva;
        private IScheduler _scheduler;
        private IStatusTracker _statusTracker;
        private int _roundID;
        private double _betAmount;
        private GameStatisticsViewModel _gameResult;
        private bool _isSecondGetWinnerInformation;
        private double _costWinnerInformation;

        #endregion Fields

        #region Properties

        internal ObservableCollection<PayLog> Paylogs
        {
            get { return _paylogs; }
            set { _paylogs = value; }
        }

        public GameStatisticsViewModel GameResult
        {
            get { return _gameResult; }
            set
            {
                if (_gameResult!=value)
                {
                    _gameResult = value;
                    _notify.Raise(() => GameResult); 
                }
            }
        }

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

        internal Services.IColorsServiceAdapter GameService
        {
            get
            {
                if (_sva == null)
                {
                    _sva = new ColorsServiceAdapter();
                }
                return _sva;
            }
            set { _sva = value; }
        }

        internal IScheduler Scheduler
        {
            get { return _scheduler; }
            set { _scheduler = value; }
        }

        internal System.Windows.Threading.Dispatcher Dispatcher
        {
            set { _scheduler = new DispatcherScheduler(value); }
        }

        internal IStatusTracker StatusTracker
        {
            get { return _statusTracker; }
            set { _statusTracker = value; }
        }

        #endregion Properties

        #region Constructors

        public GamePlayViewModel()
        {
            _notify = new PropertyChangedNotifier(this, () => PropertyChanged);
            _tables = new ObservableCollection<GameTable>();
            _paylogs = new ObservableCollection<PayLog>();

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

        public void GetListActiveGameRounds()
        {
            var svc = GameService;

            IDisposable disposeGameRounds = null;
            disposeGameRounds = svc.GetListActiveGameRound().ObserveOn(Scheduler).Subscribe(
                next =>
                {
                    foreach (var table in next.ActiveRounds)
                        Tables.Add(new GameTable
                        {
                            Name = "Colors",
                            Round = table.RoundID,
                            StartTime = table.StartTime,
                            EndTime = table.EndTime,
                        });
                },
                error =>
                {
                    // TODO: Colors RX GetListActiveGameRounds error
                },
                () => disposeGameRounds.Dispose()
                );
        }

        public void GetListGamePlayInformation()
        {
            var svc = GameService;
            IDisposable disposeGamePlayInformation = null;
            disposeGamePlayInformation = svc.GetListGamePlayInformation(new ListGamePlayInfoCommand()).
                ObserveOn(Scheduler).Subscribe(
                next =>
                {
                    foreach (var table in next.GamePlayInfos)
                    {
                        if (Tables.Any(round => round.Round.Equals(table.RoundID)))
                        {
                            // update game round information
                            var update = Tables.First(round => round.Round.Equals(table.RoundID));
                            var blackPot = table.TotalBetAmountOfBlack - update.TotalBetBlack;
                            var whitePot = table.TotalBetAmountOfWhite - update.TotalBetWhite;

                            update.TotalBetBlack += blackPot;
                            update.TotalBetWhite += whitePot;
                            update.TrackingID = table.TrackingID;
                            update.OnGoingTrackingID = table.OnGoingTrackingID;
                            update.Amount = (table.TotalBetAmountOfBlack + table.TotalBetAmountOfWhite) - update.Amount;
                        }
                        else
                        {
                            // add new game round information
                            Tables.Add(new GameTable
                            {
                                Round = table.RoundID,
                                TotalBetBlack = table.TotalBetAmountOfBlack,
                                TotalBetWhite = table.TotalBetAmountOfWhite,
                                TrackingID = table.TrackingID,
                                OnGoingTrackingID = table.OnGoingTrackingID
                            });
                        }

                        // Check TrackingID and OnGoingTrackingID not match 
                        if (!table.TrackingID.Equals(table.OnGoingTrackingID))
                        {
                            // HACK: Test looking TrackingID and OnGoingTrackingID
                            //GetListGamePlayInformation();
                        }
                    }
                },
                error =>
                {
                    // TODO: Colors RX GetListGamePlayInformation error
                },
                () => disposeGamePlayInformation.Dispose()
                );
        }

        public void GetWinnerInformation()
        {
            // TODO: Sub account balance
            Paylogs.Add(new PayLog
            {
                RoundID = RoundID,
                Amount = _costWinnerInformation
            });
            var svc = GameService;

            // TODO: Colors RX GetWinnerInformation
            IDisposable disposeGetWinnerInformation = null;
            disposeGetWinnerInformation = svc.GetWinnerInformation(new PayForColorsWinnerInfoCommand { RoundID = RoundID })
                .ObserveOn(Scheduler).Subscribe(
                next =>
                {
                    // TODO: Colors observer follow trackingID
                    ColorsTrackingObserver observer = new ColorsTrackingObserver(() => { });
                    observer.Initialize(StatusTracker);
                    observer.SetTrackingID(next.OnGoingTrackingID);

                    // Display TotalAmountOfBlack, TotalAmountOfWhite, Winner
                    //var result = Tables.FirstOrDefault(c => c.Round.Equals(RoundID));
                    //Winner = result.Winner;
                    //TotalAmountOfBlack = result.TotalBetBlack.ToString();
                    //TotalAmountOfWhite = result.TotalBetWhite.ToString();

                    // TODO: Delete PayLog where TrackingID match
                    // TODO: if trackingID = empty remove waiting status
                },
                error =>
                {
                    // TODO: Colors RX GetWinnerInformation error
                },
                () => disposeGetWinnerInformation.Dispose()
                );

            _isSecondGetWinnerInformation = true;
        }

        public void GetGameResult()
        {
            var svc = GameService;

            IDisposable disposeGameResult = null;
            disposeGameResult = svc.GetGameResult(new GetGameResultCommand { RoundID = RoundID })
                .ObserveOn(Scheduler).Subscribe(
                next =>
                {
                    var result = next.GameResult;
                    if (result != null)
                    {
                        string winner = "Black";
                        if (result.WhitePot <= result.BlackPot) winner = "White";
                        GameResult = new GameStatisticsViewModel
                        {
                            Winner = winner,
                            Hands = result.HandCount,
                            BlackPot = result.BlackPot,
                            WhitePot = result.WhitePot,
                        };
                    }
                },
                error =>
                {
                    // TODO: Colors RX GetGameResult error
                },
                () => disposeGameResult.Dispose()
                );
        }

        public void BetBlack()
        {
            bet();
        }

        public void BetWhite()
        {
            const bool betWhite = false;
            bet(betWhite);
        }

        private void bet(bool betBlack = true)
        {
            const string BetInBlack = "Black";
            const string BetInWhite = "White";
            string selectColor = BetInWhite;
            if (betBlack) selectColor = BetInBlack;

            var paylog = new PayLog
            {
                Amount = BetAmount,
                RoundID = RoundID,
                Colors = selectColor
            };
            Paylogs.Add(paylog);

            var svc = GameService;

            IDisposable disposeBet = null;
            disposeBet = svc.Bet(new BetCommand
            {
                Amount = BetAmount,
                Color = selectColor,
                RoundID = RoundID,
            }).ObserveOn(Scheduler).Subscribe(
                next =>
                {
                    // TODO: Colors RX Bet
                    // Sent to observer follow this OnGoingTrackingID
                    ColorsTrackingObserver observer = new ColorsTrackingObserver(() => { });
                    observer.Initialize(StatusTracker);
                    observer.SetTrackingID(next.TrackingID);

                    // Display TotalBetAmountOfBlack, TotalBetAmountOfWhite, Winner
                    // Check TrackingID and OnGoingTrackingID
                    // Delete PayLog in TrackingID
                    // If Paylog empty remove waiting
                },
                error =>
                {
                    // TODO: Colors RX Bet error
                },
                () => disposeBet.Dispose()
                );
        }

        #endregion Methods

        #region INotifyPropertyChanged member

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion INotifyPropertyChanged member
    }
}
