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

        private int _roundID;
        private bool _isSecondGetWinnerInformation;
        private string _winnerInformation;
        private double _betAmount;
        private double _costWinnerInformation;
        private IScheduler _scheduler;
        private IColorsServiceAdapter _sva;
        private IStatusTracker _statusTracker;
        private PropertyChangedNotifier _notify;
        private GameStatisticsViewModel _gameResult;
        private ObservableCollection<GameTable> _tables;
        private ObservableCollection<PayLog> _paylogs;

        #endregion Fields

        #region Properties

        /// <summary>
        /// เงินที่ลงทั้งหมดในสีดำ
        /// </summary>
        public double TotalBetBlack
        {
            get { return _tables.First(c => c.Round.Equals(_roundID)).TotalBetBlack; }
        }
        
        /// <summary>
        /// เงินที่ลงทั้งหมดในสีขาว
        /// </summary>
        public double TotalBetWhite
        {
            get { return _tables.First(c => c.Round.Equals(_roundID)).TotalBetWhite; }
        }

        /// <summary>
        /// เวลาที่เหลือในเกม
        /// </summary>
        public TimeSpan GameTime
        {
            get { return _tables.First(c => c.Round.Equals(_roundID)).GameTime; }
        }

        /// <summary>
        /// สีที่ชนะ
        /// </summary>
        public string Winner
        {
            get { return _tables.First(c => c.Round.Equals(_roundID)).Winner; }
        }

        /// <summary>
        /// ผลลัพท์
        /// </summary>
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

        /// <summary>
        /// ค่าใช้จ่ายในการขอดูข้อมูล Winner
        /// </summary>
        public double CostWinnerInformation
        {
            get { return _costWinnerInformation; }
            set
            {
                if (_costWinnerInformation!=value)
                {
                    _costWinnerInformation = value;
                    _notify.Raise(() => CostWinnerInformation); 
                }
            }
        }

        /// <summary>
        /// จำนวนที่ทำการลงเงินพนัน
        /// </summary>
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

        /// <summary>
        /// Game round identify
        /// </summary>
        public int RoundID
        {
            get { return _roundID; }
            set
            {
                if (_roundID!=value)
                {
                    _roundID = value; 
                }
            }
        }

        /// <summary>
        /// Game tables
        /// </summary>
        public ObservableCollection<GameTable> Tables
        {
            get { return _tables; }
            set
            {
                if (_tables!=value)
                {
                    _tables = value; 
                }
            }
        }

        /// <summary>
        /// ข้อมูลที่แสดงวิธีการใช้งานการขอดู Winner
        /// </summary>
        public string WinnerInformation
        {
            get { return _winnerInformation; }
            set
            {
                if (_winnerInformation!=value)
                {
                    _winnerInformation = value;
                    _notify.Raise(() => WinnerInformation); 
                }
            }
        }

        internal ObservableCollection<PayLog> Paylogs
        {
            get { return _paylogs; }
            set
            {
                if (_paylogs!=value)
                {
                    _paylogs = value; 
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

        private GameTable ThisGameTableInformation
        {
            get { return _tables.First(c => c.Round.Equals(_roundID)); }
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
            var svc = _sva;

            IDisposable disposeGameRounds = null;
            disposeGameRounds = svc.GetListActiveGameRound().ObserveOn(Scheduler).Subscribe(
                next =>
                {
                    Tables.Clear();
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
            var svc = _sva;
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

                        // Check TrackingID and OnGoingTrackingID
                        if (!table.TrackingID.Equals(table.OnGoingTrackingID))
                            GetListGamePlayInformation();
                    }

                    // TODO: Display TotalAmountOfBlack, TotalAmountOfWhite, Winner
                    const int PayLogEmpty = 0;
                    if (_paylogs.Count == PayLogEmpty)
                    {
                        // TODO: if PayLog = empty remove waiting status
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
            // TODO: Colors Sub account balance UI
            var svc = _sva;

            var log = new PayLog
            {
                RoundID = RoundID,
                Amount = _costWinnerInformation,
            };

            ColorsTrackingObserver observer = new ColorsTrackingObserver(() =>
            {
                Paylogs.Remove(log);
                GetListGamePlayInformation();
            });
            Paylogs.Add(log);
            observer.Initialize(StatusTracker);

            IDisposable disposeGetWinnerInformation = null;
            disposeGetWinnerInformation = svc.GetWinnerInformation(new PayForColorsWinnerInfoCommand { RoundID = RoundID })
                .ObserveOn(Scheduler).Subscribe(
                next => observer.SetTrackingID(next.OnGoingTrackingID),
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
            var svc = _sva;

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
            // TODO: Colors Sub account balance UI
            var svc = _sva;

            const string BetInBlack = "Black";
            const string BetInWhite = "White";
            string selectColor = BetInWhite;
            if (betBlack) selectColor = BetInBlack;

            var log = new PayLog
            {
                Amount = BetAmount,
                RoundID = RoundID,
                Colors = selectColor
            };

            ColorsTrackingObserver observer = new ColorsTrackingObserver(() =>
            {
                Paylogs.Remove(log);
                GetListGamePlayInformation();
            });
            Paylogs.Add(log);
            observer.Initialize(StatusTracker);

            IDisposable disposeBet = null;
            disposeBet = svc.Bet(new BetCommand
            {
                Amount = BetAmount,
                Color = selectColor,
                RoundID = RoundID,
            }).ObserveOn(Scheduler).Subscribe(
                next => observer.SetTrackingID(next.TrackingID),
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
